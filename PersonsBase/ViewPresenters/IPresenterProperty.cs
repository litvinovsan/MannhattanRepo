using PersonsBase.data.Abonements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.ViewPresenters
{
   public interface IPresenterProperty
   {
      AbonementBasic AbonementCurent { get; set; }

   }
}
