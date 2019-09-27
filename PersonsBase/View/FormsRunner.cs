using PBase;
using PersonsBase.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
    public static class FormsRunner
    {
        //_options = Options.GetInstance();
        //_dataBase = DataBaseLevel.GetInstance();
        //_person = DataBaseO.GetPersonLink(nameKey); // Получаем ссылку на обьект персоны

        #region /// СОЗДАНИЕ КЛИЕНТА ///
        public static bool RunCreatePersonForm(out string createdName)
        {
            createdName = null;
            var personForm = new CreatePersonForm();
            if (personForm.ShowDialog() != DialogResult.OK) return false;
            createdName = personForm.GetName();
            return true;
        }
        #endregion

        #region /// КАРТОЧКА КЛИЕНТА ///
        public static void RunClientForm(string keyName)
        {
            if (DataBaseLevel.ContainsNameKey(keyName))
            {
                ClientForm clientFrm = new ClientForm(keyName);
                clientFrm.ShowDialog();
            }
            else
            {
                MessageBox.Show(@"Ошибка. Неправильное имя клиента");
            }
        }
        #endregion

        #region /// СТРАНИЦА РУКОВОДИТЕЛЯ ///
        public static DialogResult CreateBossForm()
        {
            var result = DialogResult.Cancel;
            using (var form = new BossForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    result = DialogResult.OK;
                }
            }
            return result;
        }

        #endregion

        #region /// СОЗДАНИЕ АБОНЕМЕНТА ///
        public static DialogResult CreateAbonementForm(string personName)
        {
            var result = DialogResult.Cancel;
            using (var form = new AbonementForm(personName))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.ApplyChanges();
                    result = DialogResult.OK;
                }
            }
            return result;
        }

        #endregion

        #region /// ЗАМОРОЗКА Абонемента ///

        public static DialogResult RunFreezeForm(string personName)
        {// Cохраняет напрямую в Абонемент
            Person person = DataBaseO.GetPersonLink(personName);
            if (!(person.AbonementCurent is ClubCardA)) return DialogResult.Cancel;
            ClubCardA clubCard = ((ClubCardA)person.AbonementCurent);
            FreezeForm freezeForm = new FreezeForm(clubCard);
            return freezeForm.ShowDialog();
        }

        #endregion

        #region /// ВЫБОР ТИПА ТРЕНИРОВКИ ///

        /// <summary>
        ///  Возвращает  DialogResult.OK Если успешно всё выбрали
        /// </summary>
        public static DialogResult RunWorkoutOptionsForm(ref WorkoutOptions optionsWorkout, string personName)
        {
            var dlgReult = DialogResult.Cancel;

            var workoutForm = new WorkoutForm(personName);

            dlgReult = workoutForm.ShowDialog();
            if (dlgReult == DialogResult.OK)
            {
                optionsWorkout = workoutForm.SelectedOptions;
            }
            return dlgReult;
        }

        #endregion

        #region /// Форма Ввод ПАРОЛЯ ///
        public static void RunPasswordForm()
        {
            if (PwdForm.IsPassUnLocked()) PwdForm.LockPassword();
            else
            {
                PwdForm pwd = new PwdForm(Options.GetInstance());
                pwd.ShowDialog();
            }
        }
        #endregion

        #region /// ФОРМА ВЫБОР КЛИЕНТА из списка БАЗЫ ///
        public static bool RunSelectPersonForm(out string personName)
        {
            personName = null;
            var frm = new SelectPersonForm();
            var dlgReult = frm.ShowDialog();

            if (dlgReult != DialogResult.OK) return false;

            var selectedPerson = frm.GetName();
            personName = selectedPerson;
            return true;
        }
        #endregion

    }
}
