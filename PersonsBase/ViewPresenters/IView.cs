using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.ViewPresenters
{
   // общие методы для всех представлений
   public interface IView
   {
      void Show();
      void Close();
   }
}
