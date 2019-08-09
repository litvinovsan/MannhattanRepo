using System;
using System.Collections.Generic;
// ReSharper disable All

namespace PBase
{

   /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
   /// Использовать выборочное сохранение обьектов в Options. Весь класс сериализовать не рекомендуется т.к. перетирается пароль
   //  Methods.DeSerialize(ref _options, "Option.bin");
   //  FIXME проверка если опшин пароль равен нулю - прописать ручками умолчальный
   [Serializable]
   public class Options
   {
      public Administrator adminCurrent;
      public List<Administrator> adminsList;
      public List<Trener> trenersList;

      [field: NonSerialized]
      private string _passwordRootString;

      private bool _isPasswordValid;

      public Options()
      {
         _isPasswordValid = false;
         _passwordRootString = "1234";
      }

      ////////////////  События ///////////////////////////////////////
      [field: NonSerialized]
      public event EventHandler PasswordChangedEvent;
      public void OnPwdRootChanged()
      {
         PasswordChangedEvent?.Invoke(this, EventArgs.Empty);
      }

      ////////////////  Свойства ///////////////////////////////////////
      public bool IsPasswordValid
      {
         get
         {
            return _isPasswordValid;
         }
         set
         {
            _isPasswordValid = value;
            OnPwdRootChanged();
         }
      }

      ////////////////  Методы ///////////////////////////////////////
      public bool CheckPassword(string inputPass)
      {
         return (inputPass == _passwordRootString);
      }
   }
}
