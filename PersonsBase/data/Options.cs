using System;
using System.Collections.Generic;
// ReSharper disable All

namespace PBase
{

    /// <summary>
    /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
    /// Использовать выборочное сохранение обьектов в Options. Весь класс сериализовать не рекомендуется т.к. перетирается пароль
    //  HelperMethods.DeSerialize(ref _options, "Option.bin");
    //  FIXME проверка если опшин пароль равен нулю - прописать ручками умолчальный
    /// </summary>
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
          _passwordRootString= "1234";
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
      public  bool CheckPassword(string inputPass)
      {
         return (inputPass == _passwordRootString);
      }
   }
}
