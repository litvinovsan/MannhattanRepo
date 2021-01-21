using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace MyServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ConnectService" in both code and config file together.
    public class ConnectService : IConnectService
    {
        private string _t="Testing";

        public string T
        {
            get { return _t; }
            set
            {
                _t = value;
            }
        }


        public string GetData(string value)
        {
            return $"You entered: {value}";
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        public AbonementBasic GetAbonement(string personName)
        {
            return new AbonementByDays(Pay.Оплачено, TimeForTr.Утро, TypeWorkout.МиниГруппа, SpaService.Спа, DaysInAbon.На_5_посещений);
        }

        public void SetAbonement(AbonementBasic abonement, string personName)
        {
            var abon = abonement;

            if (abon is AbonementByDays)
                MessageBox.Show("Yes");
        }

        public string GetText()
        {
            return T;

        }

        public bool SetText(string text)
        {
            T = text;
            return true;
        }
    }
}
