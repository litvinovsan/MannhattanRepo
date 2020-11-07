using System.Collections.Generic;
using System.Linq;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.Converter
{
    public static class DbConverter
    {
        public static List<AbonementBasic> GetPersonAbonements(Person person)
        {
            var resultList = new List<AbonementBasic>();
            if (person?.AbonementCurent != null) resultList.Add(person.AbonementCurent);
            if (person?.AbonementsQueue?.Count != 0)
            {
                var q = person?.AbonementsQueue?.Select(x => x).ToArray();
                if (q != null) resultList.AddRange(q);
            }

            return resultList;
        }

        /// <summary>
        /// Сохраняет все абонементы Клиента в АбонементКонтроллер
        /// </summary>
        /// <param name="persons"></param>
        public static Dictionary<string, List<AbonementBasic>> Convert(IEnumerable<Person> persons)
        {
            // original list: var persons = DataBaseLevel.GetPersonsList().Select(x => x.Value).ToList();
            var abonContr = AbonementController.GetInstance();
            abonContr.GetPersonsDictn().Clear();
            
            foreach (var person in persons)
            {
                var abonements = GetPersonAbonements(person);

                if (abonements.Count == 0)
                {
                    abonContr.AddNewPerson(person.Name);
                }

                foreach (var abonement in abonements)
                {
                    abonContr.AddAbonement(person.Name, abonement);
                }
            }

            return abonContr.GetPersonsDictn();
        }


    }
}