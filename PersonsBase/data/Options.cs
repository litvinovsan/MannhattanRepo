using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PBase
{

   /// <summary>
   /// Хранятся настройки приложения, а так же общие структуры, списки,и прочие данные.
   /// </summary>
   [Serializable]
   public class Options
   {
      public Administrator adminCurrent;
      public List<Administrator> adminsList;
      public List<Trener> trenersList;
      всегда null
      public readonly string passwordRootString = "1234";

      private bool _isPasswordValid = false;

      ////////////////  События ///////////////////////////////////////
      [field: NonSerialized()]
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
         return (inputPass == passwordRootString);
      }
   }
}
