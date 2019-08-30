﻿using PBase;
using PersonsBase.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsBase.View
{
    public class FormsRunner
    {
        private Options _options;
        private DataBaseClass _dataBase;

        public FormsRunner()
        {
            _options = Options.GetInstance();
            _dataBase = DataBaseClass.GetInstance();
            //_person = DataObjects.GetPersonLink(nameKey); // Получаем ссылку на обьект персоны
        }

        #region /// Форма Создания Абонемента ///
        public static DialogResult CreateAbonementForm(string personName)
        {
            DialogResult result = DialogResult.Cancel;
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

        #region /// Форма Опции ЗАМОРОЗКИ Абонемента ///

        public static DialogResult RunFreezeForm(string personName)
        {
            Person _person = DataObjects.GetPersonLink(personName);
            if (!(_person.AbonementCurent is ClubCardA)) return DialogResult.Cancel;
            ClubCardA clubCard = ((ClubCardA)_person.AbonementCurent);
            FreezeForm freezeForm = new FreezeForm(clubCard);
            return freezeForm.ShowDialog();
        }

        #endregion

        #region /// Форма Выбор ТИПА Тренировки ///

        /// <summary>
        ///  Возвращает  DialogResult.OK Если успешно всё выбрали
        /// </summary>
        public DialogResult RunWorkoutOptionsForm(out WorkoutOptions optionsWorkout, string personName)
        {
            var _person = DataObjects.GetPersonLink(personName);

            DialogResult dlgReult = DialogResult.Cancel;
            optionsWorkout = new WorkoutOptions();
            var workoutForm = new TypeWorkoutForm(personName);

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
    }
}