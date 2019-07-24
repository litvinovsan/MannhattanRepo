using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBase;

namespace TestProj
{
   public static class MyUnitTests
   {
      static void checking<T1, T2, T3>(T1 expected, T2 currentResult, T3 nameTest)
      {
         if (expected.Equals(currentResult)) Console.WriteLine($" Pass {nameTest}");
         else Console.WriteLine($" !!!  FAIL {nameTest}");
      }

      static void checkIsNull(Person personResult, string testName)
      {
         if (personResult == null) Console.WriteLine(" Pass " + testName);
         else Console.WriteLine(" !!!  FAIL " + testName);
      }

      static bool result =true;

      public static void RunTests()
      {
         ///////// Unit TEST //////
         //1. AddPerson 
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            ResponseCode expectedResult = ResponseCode.Success;
            var list = dbInstance.GetCollectionRW();

            // var list = dbInstance.GetCollInstanceRW();
            ResponseCode result = dbInstance.AddPerson(new Person());

            checking(expectedResult, result, "1.1");

            //1.2
            result = dbInstance.AddPerson(new Person());
            checking(expectedResult, result, "1.2");

            //1.3
            list.Clear();
            result = dbInstance.AddPerson(new Person("aa ff dd"));
            checking(expectedResult, result, "1.3");
            result = dbInstance.AddPerson(new Person("Aa ff dd"));
            checking(ResponseCode.KeyExist, result, "1.3.1");
            checking(1, list.Count, "1.3.2");
            //1.4
            list["Aa Ff dd"].Passport = "12345";
            Person p = new Person();
            p.Passport = "12345";
            result = dbInstance.AddPerson(p);
            checking(ResponseCode.PassportExist, result, "1.4.1");
            checking(1, list.Count, "1.4.2");
         }

         //2. RemovePerson
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            ResponseCode expectedResult = ResponseCode.Fail;
            var list = dbInstance.GetCollectionRW();
            int tmpCnt = list.Count;
            dbInstance.AddPerson(new Person());
            dbInstance.RemovePerson(list.Values[0].Key);
            checking(tmpCnt, list.Count, "2.1");

            tmpCnt = list.Count;
            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person());
            checking(tmpCnt + 3, list.Count, "2.2");

            expectedResult = ResponseCode.Fail;
            var result = dbInstance.RemovePerson("dssd dsd");
            checking(expectedResult, result, "2.3");
         }
         //3 FindByDriveId
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();

            var result = DataMethods.FindByDriveId(list, "123");
            if (result == null) Console.WriteLine(" Pass 3.1");
            else Console.WriteLine(" Fail 3.1");

            SortedList<string, Person> tempList = new SortedList<string, Person>();
            tempList.Add("qwe asd", new Person("qwe asd"));
            tempList.Add("zxze rrr", new Person("zxze rrr"));
            tempList.Add("123 123", new Person("123 123"));

            tempList["zxze rrr"].DriverIdNum = "123";
            result = DataMethods.FindByDriveId(tempList, "123");
            checking(tempList["zxze rrr"], result, "3.2");

            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person("Qwe Asd"));
            var aa = list.ElementAt(2);
            aa.Value.DriverIdNum = "222";

            result = DataMethods.FindByDriveId(list, "222");
            checking(aa.Value, result, "3.3");

         }

         //4. FindByPersonalNumber
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();
            Person resultPerson = null;
            resultPerson = DataMethods.FindByPersonalNumber(list, 1234);
            if (resultPerson == null) Console.WriteLine(" Pass 4.1 ");
            else Console.WriteLine("4.1 Fail");

            var aaa = list.ElementAt(3);
            var name = aaa.Key;
            list[name].PersonalNumber = 1234;
            resultPerson = DataMethods.FindByPersonalNumber(list, 1234);
            checking(resultPerson, list[name], "4.2");
            checking(name, resultPerson.Key, "4.3");
         }

         //5. FindByName
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();
            list.Clear();
            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person("Qww weq"));
            dbInstance.AddPerson(new Person("литвинов александр"));
            dbInstance.AddPerson(new Person("zzz ddd"));
            Person result = null;
            result = DataMethods.FindByName(list, "л");
            checkIsNull(result, "5.1");

            result = DataMethods.FindByName(list, "литвинов александр");
            checking(list["литвинов александр"], result, "5.2");

            result = DataMethods.FindByName(list, "");
            checkIsNull(result, "5.3");

            result = DataMethods.FindByName(list, "zzz ddd");
            result.Phone = "222999";
            checking(list["zzz ddd"].Phone, "222999", "5.4");
         }
         //6. EditName
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();
            list.Clear();

            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person("Qww weq"));
            dbInstance.AddPerson(new Person("литвинов александр"));
            dbInstance.AddPerson(new Person("zzz ddd"));

            int expected = dbInstance.GetCollectionRW().Count;
            list["Литвинов Александр"].Passport = "12345678";
            var bresult = DataMethods.EditName(ref list, "литвинов александр", "литвинов александр александрович");

            checking(true, bresult, "6.1");

            int resCount = dbInstance.GetCollectionRW().Count;
            checking(expected, resCount, "6.2");

            checking("12345678", list["Литвинов Александр Александрович"].Passport, "6.3");

            bresult = DataMethods.EditName(ref list, "литв", "литвинов александр александрович");
            checking(false, bresult, "6.4");
         }

         //7. FindByPassport EditPassport
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();
            list.Clear();

            dbInstance.AddPerson(new Person());
            dbInstance.AddPerson(new Person("Qww weq"));
            dbInstance.AddPerson(new Person("Литвинов Александр"));
            dbInstance.AddPerson(new Person("zzz ddd"));

            Person resultPerson;
            resultPerson = DataMethods.FindByPassport(list, "12345678");
            checkIsNull(resultPerson, "7.1");

            list["Литвинов Александр"].Passport = "12345678";
            resultPerson = DataMethods.FindByPassport(list, "12345678");
            checking(true, list.ContainsValue(resultPerson), "7.2");
            checking("12345678", resultPerson.Passport, "7.3");

            //EditPassport
            var resulted = DataMethods.EditPassport(ref resultPerson, "9876");
            checking(true, resulted, "7.4");

            checking("9876", resultPerson.Passport, "7.5");
            checking("9876", list["Литвинов Александр"].Passport, "7.6");
         }

         //8. SelectByGender   SelectByStatus
         {
            DataBaseClass dbInstance = DataBaseClass.getInstance();
            var list = dbInstance.GetCollectionRW();
            list.Clear();
            
            dbInstance.AddPerson(new Person("Симпсон Гомер") { GenderType = Gender.Мужской, Status = StatusPerson.Активный });
            dbInstance.AddPerson(new Person("Литвинов Александр") { GenderType = Gender.Мужской, Status = StatusPerson.Не_Активный });
            dbInstance.AddPerson(new Person("Симпсон Барт") { GenderType = Gender.Мужской, Status = StatusPerson.Не_Активный });
            dbInstance.AddPerson(new Person("Скиннер Директор") { GenderType = Gender.Мужской, Status = StatusPerson.Не_Активный });
            dbInstance.AddPerson(new Person("Мелхаус ") { GenderType = Gender.Мужской, Status = StatusPerson.Запрещён });
            dbInstance.AddPerson(new Person("Мардж Симпсон") { GenderType = Gender.Женский, Status = StatusPerson.Активный });
            dbInstance.AddPerson(new Person("Симпсон Лиза") { GenderType = Gender.Женский, Status = StatusPerson.Не_Активный });
            dbInstance.AddPerson(new Person("Симпсон Мэгги") { GenderType = Gender.Женский, Status = StatusPerson.Запрещён });

            var selectedGender = DataMethods.SelectByGender(list.Values, Gender.Мужской);
            int cntResult = selectedGender.Count();
            checking(5, cntResult, "8.1");

            var listPerson = selectedGender.ToList<Person>();

            var selectedStatus = DataMethods.SelectByStatus(list.Values, StatusPerson.Запрещён);
            cntResult = selectedStatus.Count();
            checking(2, cntResult, "8.2");

            var result2 = DataMethods.SelectByStatus(selectedGender, StatusPerson.Не_Активный);
            cntResult = result2.Count();
            checking(3, cntResult, "8.3");

            result2 = DataMethods.SelectByStatus(selectedGender, StatusPerson.Вероятный_Клиент);
            cntResult = result2.Count();
            checking(0, cntResult, "8.4");


            //9.  SelectBDateToday
            {
               list["Литвинов Александр"].BirthDate = new DateTime(2009, 5, 5);
               list["Мардж Симпсон"].BirthDate = DateTime.Now.Date;
               list["Скиннер Директор"].BirthDate = DateTime.Now.Date;
               var bdayResult = DataMethods.SelectBDateToday(list.Values);
               if (bdayResult.ToList().Count == 2)
               {
                  Console.WriteLine(" Pass 9.1");
               }
               else Console.WriteLine(" Fail 9.1");


               //SelectEndInXdays
               //list["Симпсон Гомер"].FinishDate = DateTime.Now.AddDays(4);
               //list["Симпсон Лиза"].FinishDate = DateTime.Now.AddDays(4);
               //list["Литвинов Александр"].FinishDate = DateTime.Now.AddDays(3);
               //var xDays = DataMethods.SelectEndInXdays(list.Values, 3);
               //checking(1, xDays.ToList().Count, "9.2");

               //xDays = DataMethods.SelectEndInXdays(list.Values, 4);
               //checking(2, xDays.ToList().Count, "9.3");

               //xDays = DataMethods.SelectEndInXdays(list.Values, 5);
               //checking(0, xDays.ToList().Count, "9.4");
            }


            //10.  Serialize Deserialize
            {
               var cntBefore=dbInstance.GetNumberOfPersons();
               if(cntBefore !=0)
               {
                  Console.WriteLine($" Pass 10.1     {cntBefore} клиентов");
               }
               else
               {
                  Console.WriteLine($" !!!  FAIL 10.1");
               }

            //   var serResult= dbInstance.Serialize();
               //checking(true, serResult, "10.2");
               //var listPersons = dbInstance.GetCollectionRW();
               //listPersons.Clear();
               //var cntAfter = dbInstance.GetNumberOfPersons();
               //checking(0, cntAfter, "10.3");

               //dbInstance.AddPerson(new Person("Serial Deserial"));

               //serResult = dbInstance.DeSerialize();
               //checking(true, serResult, "10.4");
               //cntAfter = dbInstance.GetNumberOfPersons();
               //checking(cntBefore, cntAfter, "10.5");
               //listPersons = dbInstance.GetCollectionRW();


            }

         }

      }
   }
}
