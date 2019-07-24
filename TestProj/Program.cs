using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBase;

namespace TestProj
{
   class Program
   {

      static void Main(string[] args)
      {

         MyUnitTests.RunTests();
         Console.ReadLine();

         var ss=DataBaseClass.getInstance();
         
      }
   }
}