using PersonsBase.data;
using System.Windows.Forms;
using PersonsBase.data.Abonements;

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
                var clientFrm = new ClientForm(keyName);
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
                if (form.ShowDialog() != DialogResult.OK) return result;

                form.ApplyChanges();
                result = DialogResult.OK;
            }
            return result;
        }

        #endregion

        #region /// ЗАМОРОЗКА Абонемента ///

        public static DialogResult RunFreezeForm(string personName)
        {// Cохраняет напрямую в Абонемент
            Person person = PersonObject.GetLink(personName);
            if (!(person.AbonementCurent is ClubCardA)) return DialogResult.Cancel;
            ClubCardA clubCard = ((ClubCardA)person.AbonementCurent);
            var freezeForm = new FreezeForm(clubCard);
            return freezeForm.ShowDialog();
        }

        #endregion

        #region /// ВЫБОР ТИПА ТРЕНИРОВКИ ///

        /// <summary>
        ///  Возвращает  DialogResult.OK Если успешно всё выбрали
        /// </summary>
        public static DialogResult RunWorkoutOptionsForm(ref WorkoutOptions optionsWorkout, string personName)
        {
            // Если нет Персональных или Аэробных тренировок - не выводить окно выбора тренировок. По умолчанию отмечается Тренажерный зал
            var abon = PersonObject.GetLink(personName)?.AbonementCurent;

            if (abon == null) return DialogResult.Cancel;

            optionsWorkout.TypeWorkout = abon.TypeWorkout; // Значение по умолчанию

            switch (abon)
            {
                case ClubCardA clubCardA:
                    {
                        if (clubCardA.NumPersonalTr == 0 && clubCardA.NumAerobicTr == 0 && clubCardA.NumMiniGroup == 0)
                        {
                            optionsWorkout.TypeWorkout = TypeWorkout.Тренажерный_Зал;
                            return DialogResult.OK;
                        }
                        break;
                    }
                case AbonementByDays byDays:
                    {
                        if (byDays.TypeWorkout == TypeWorkout.Аэробный_Зал ||
                            byDays.TypeWorkout == TypeWorkout.Тренажерный_Зал)
                        {
                            // Возвращаем текущий тип тренировки
                            //optionsWorkout.TypeWorkout = abon.TypeWorkout;
                            return DialogResult.OK;
                        }
                        break;
                    }
                case SingleVisit singleVisit:
                    {
                        return DialogResult.OK;
                    }
            }

            var workoutForm = new WorkoutForm(personName);

            var dlgReult = workoutForm.ShowDialog();
            if (dlgReult == DialogResult.OK) optionsWorkout = workoutForm.SelectedOptions;
            return dlgReult;
        }

        #endregion

        #region /// ВВОД ПАРОЛЯ ///
        public static void RunPasswordForm()
        {
            if (PwdForm.IsPassUnLocked()) PwdForm.LockPassword();
            else
            {
                var pwd = new PwdForm();
                pwd.ShowDialog();
            }
        }
        #endregion

        #region /// ВЫБОР КЛИЕНТА из списка БАЗЫ ///
        public static bool RunSelectPersonForm(out string personName, string header)
        {
            personName = null;

            var frm = new PersonsForm(header);
            var dlgReult = frm.ShowDialog();

            if (dlgReult != DialogResult.OK) return false;

            var selectedPerson = frm.GetName();
            personName = selectedPerson;
            return true;
        }
        #endregion

        #region /// СКАНИРОВАНИЯ ШТРИХКОДА ///

        /// <summary>
        /// Возвращает true Если код считан и Клиент Найден. False если нет такого клиента в базе.
        /// </summary>
        /// <param name="namePerson"></param>
        /// <returns></returns>
        public static bool RunBarCodeForm(out string namePerson)
        {
            namePerson = "";
            using (var brCode = new BarCodeForm())
            {
                var dlgRes = brCode.ShowDialog();
                if (dlgRes != DialogResult.OK) return false;
                namePerson = brCode.GetFindedName();
            }
            return true;
        }
        #endregion

        #region /// ОТЧЕТЫ о КЛИЕНТАХ
        public static void RunReportForm()
        {
            var frm = new ReportForm();
            frm.Show();
        }
        #endregion

        #region /// ВЫБОР ТЕКУЩЕГО АДМИНИСТРАТОРА ///
        public static void RunAdminForm()
        {
            var frm = new AdminSelectForm();
            frm.Show();
        }
        #endregion

    }
}
