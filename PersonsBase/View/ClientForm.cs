using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ClientForm : Form, IDisposable
    {
        #region /// ОСНОВНЫЕ ОБЬЕКТЫ ///

        private readonly Logic _logic;
        private readonly Person _person;
        private bool _isAnythingChanged;
        private readonly AbonementController _abonementController;

        #endregion

        #region /// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ///
        public ClientForm(string keyName)
        {
            InitializeComponent();
            _person = PersonObject.GetLink(keyName) ?? new Person();
            _isAnythingChanged = false;
            _logic = Logic.GetInstance();
            _abonementController = AbonementController.GetInstance();
        }

        private void UnsubscribeEvents()
        {
            _person.NameChanged -= _person_NameChanged;
            _person.PathToPhotoChanged -= PathToPhotoChangedMethod;
            _person.PhoneChanged -= _person_PhoneChanged;
            _person.PassportChanged -= _person_PassportChanged;
            _person.DriverIdChanged -= _person_DriverIdChanged;
            _person.PersonalNumberChanged -= _person_PersonalNumberChanged;
            _person.SpecialNotesChanged -= _person_SpecialNotesChanged;
            _person.AbonementCurentChanged -= CurentAbonementChanged;
            _person.AbonementCurentChanged -= OnPersonOnAbonementCurentChanged;

            _person.StatusChanged -= UpdateInfoTextBoxField;
            _person.StatusChanged -= UpdateControls;
            _person.StatusChanged -= UpdateVisitsTable;
            PwdForm.LockChangedEvent -= PwdForm_LockChangedEvent;
            _abonementController.CollectionChanged -= OnAbonementControllerOnCollectionChanged;
            listBox_NotValidAbons.SelectedIndexChanged -= listBox_NotValidAbons_SelectedIndexChanged;
        }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            // Заполнение стартовое всех полей
            LoadUserData();

            _person.AbonementCurent = _abonementController.GetFirstValid(_person.Name);
            //Cписки абонементов
            UpdateAbonementsListBox(listBox_NotValidAbons, _abonementController.GetListNotValid(_person.Name));
            UpdateAbonementsListBox(listBox_abon_selector, _abonementController.GetListValid(_person.Name));

            LoadEditableData();
            Logic.LoadShortInfo(groupBox_Info, _person);
            UpdateControls(this, EventArgs.Empty);
            CurentAbonementChanged(this, EventArgs.Empty);
            UpdateInfoTextBoxField(this, EventArgs.Empty);

            Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto, _person.GenderType);
            //   LoadListBoxQueue();

            // Подписка на События
            _saveDelegateChain += SaveUserData; // Цепочка Делегатов для сохранения измененных данных.
            _person.NameChanged += _person_NameChanged;
            _person.PathToPhotoChanged += PathToPhotoChangedMethod;
            _person.PhoneChanged += _person_PhoneChanged;
            _person.PassportChanged += _person_PassportChanged;
            _person.DriverIdChanged += _person_DriverIdChanged;
            _person.PersonalNumberChanged += _person_PersonalNumberChanged;
            _person.SpecialNotesChanged += _person_SpecialNotesChanged;

            // Когда изменился какой-либо параметр Абонемента
            _person.AbonementCurentChanged += CurentAbonementChanged;
            _person.AbonementCurentChanged += OnPersonOnAbonementCurentChanged;

            // Когда изменилась заморозка абонемента - Обновим Инфо поле
            if (_person.AbonementCurent?.Freeze != null)
            {
                _person.AbonementCurent.Freeze.FreezeChanged -= RunStatusDirector;
                _person.AbonementCurent.Freeze.FreezeChanged += RunStatusDirector;
                _person.AbonementCurent.Freeze.FreezeChanged -= UpdateInfoTextBoxField;
                _person.AbonementCurent.Freeze.FreezeChanged += UpdateInfoTextBoxField;
                _person.AbonementCurent.Freeze.FreezeChanged -= UpdateControls;
                _person.AbonementCurent.Freeze.FreezeChanged += UpdateControls;
            }

            // Когда изменился Статус Абонемента
            _person.StatusChanged += UpdateInfoTextBoxField;
            _person.StatusChanged += UpdateControls;
            _person.StatusChanged += UpdateVisitsTable;

            PwdForm.LockChangedEvent += PwdForm_LockChangedEvent;

            // Изменение коллекции абонементов в АбонКонтроллере
            _abonementController.CollectionChanged += OnAbonementControllerOnCollectionChanged;

            // Список закончившихся абонементов
            listBox_NotValidAbons.SelectedIndexChanged += listBox_NotValidAbons_SelectedIndexChanged;

            // Вкладки Посещений и Архив абонементов
            SetupVisitsDataGridView();
            SetupHistoryAbonement(); //Настройка дата грид вью на вкладке истории абонементов
        }

        private void OnAbonementControllerOnCollectionChanged(object o, EventArgs args)
        {
            _person.AbonementCurent = _abonementController.GetFirstValid(_person.Name);

            UpdateAbonementsListBox(listBox_abon_selector, _abonementController.GetListValid(_person.Name));
            UpdateControls(this, EventArgs.Empty);
            Logic.LoadShortInfo(groupBox_Info, _person);
            LoadEditableData();
        }

        private void OnPersonOnAbonementCurentChanged(object o, EventArgs args)
        {
            UpdateInfoTextBoxField(this, EventArgs.Empty);
            UpdateControls(this, EventArgs.Empty);
            Logic.LoadShortInfo(groupBox_Info, _person);
            LoadEditableData();
        }

        private void RunStatusDirector(object sender, EventArgs e)
        {
            _person.StatusDirector();
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isAnythingChanged)
            {
                var dialogResult = MessageBox.Show(@"Сохранить изменения перед выходом?", @"Данные Поменялись!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) SaveData();
            }

            SaveSpecialNotes(); //Всегда сохраняем Особые отметки
            _isAnythingChanged = false;

            // Освобождаем память от изображения
            if (pictureBox_ClientPhoto.Image != null)
            {
                pictureBox_ClientPhoto.Image.Dispose();
                pictureBox_ClientPhoto.Image = null;
            }

            // Блокируем админскую учетку на всякий случай

            PwdForm.LockPassword();
            _abonementController.Save();
            UnsubscribeEvents();
        }
        #endregion

        #region /// ОБРАБОТЧИКИ ПОДПИСОК ///

        // Информационное текстовое поле
        private void UpdateInfoTextBoxField(object sender, EventArgs e)
        {
            switch (_person?.Status)
            {
                case StatusPerson.Активный:
                    {
                        label_infoText.Text = @"";
                        label_infoText.ForeColor = Color.SeaGreen;
                        // Заморозка запланирована в будущем
                        if (_person?.AbonementCurent?.Freeze != null && _person?.Status != StatusPerson.Заморожен && _person.Status != StatusPerson.Гостевой)
                        {
                            if (_person.AbonementCurent.Freeze.IsConfiguredForFuture())
                            {
                                label_infoText.Text =
                                    $@"Заморозка c {_person.AbonementCurent.Freeze.GetFutureFreeze().StartDate.Date:d}, дней: {_person.AbonementCurent.Freeze.GetDaysToFreeze()}";
                            }
                        }
                        // Не Активирован
                        if (_person.IsAbonementExist() && _person.AbonementCurent != null && !_person.AbonementCurent.IsActivated)
                        {
                            label_infoText.Text = @" Не активирован";
                        }

                        break;
                    }
                case StatusPerson.Нет_Карты:
                    {
                        label_infoText.Text = @"Нет Карты";
                        label_infoText.ForeColor = Color.DarkRed;
                        break;
                    }
                case StatusPerson.Заморожен:
                    {
                        label_infoText.ForeColor = Color.SeaGreen;
                        if (_person.IsAbonementExist() && _person.AbonementCurent?.Freeze != null &&
                            _person.Status != StatusPerson.Гостевой)
                        {
                            if (_person.AbonementCurent.Freeze?.AllFreezes.Count == 0) break;
                            var dateEnd = _person.AbonementCurent.Freeze?.AllFreezes.Last().GetEndDate().Date.ToString("d");
                            label_infoText.Text = @"Заморожен до " + dateEnd;
                        }
                        break;
                    }
                case StatusPerson.Гостевой:
                    label_infoText.Text = @"Был Гостевой визит";
                    label_infoText.ForeColor = Color.SeaGreen;
                    break;
                case StatusPerson.Запрещён:
                    label_infoText.Text = StatusPerson.Запрещён.ToString();
                    label_infoText.ForeColor = Color.DarkRed;
                    break;
                case null:
                    break;
            }

        }

        // Кнопки
        private void UpdateControls(object sender, EventArgs e)
        {
            // Видимость списка Абонементов
            groupBox_Abonements.Visible = listBox_abon_selector.Items.Count != 0;
            groupBox_Abon_NotValid.Visible = listBox_NotValidAbons.Items.Count != 0;

            // Все контролы
            switch (_person.Status)
            {
                case StatusPerson.Активный:
                    {
                        button_Add_Abon.Enabled = true;
                        button_CheckInWorkout.Visible = true;

                        if (_person.AbonementCurent is ClubCardA a && a.PeriodAbonem != PeriodClubCard.На_1_Месяц)
                        {
                            button_Freeze.Visible = true;
                            button_Freeze.Enabled = _person.AbonementCurent.IsActivated;
                            button_Freeze.Text = @"Заморозка";
                        }
                        else
                        {
                            button_Freeze.Visible = false;
                        }

                        // Кнопка Добавить 
                        button_add_dop_tren.Visible = (_person.AbonementCurent is ClubCardA);

                        break;
                    }
                case StatusPerson.Нет_Карты:
                    {
                        button_Add_Abon.Enabled = true;
                        button_CheckInWorkout.Visible = false;
                        button_Freeze.Visible = false;
                        button_add_dop_tren.Visible = false;
                        break;
                    }
                case StatusPerson.Заморожен:
                    {
                        button_CheckInWorkout.Visible = false;
                        button_Add_Abon.Enabled = true;
                        button_Freeze.Visible = true;
                        button_add_dop_tren.Visible = false;
                        button_Freeze.Text = @"Разморозить";
                        break;
                    }
                case StatusPerson.Гостевой:
                    {
                        button_CheckInWorkout.Visible = false;
                        button_Add_Abon.Enabled = true;
                        button_Freeze.Visible = false;
                        button_add_dop_tren.Visible = false;
                        break;
                    }
                case StatusPerson.Запрещён:
                    {
                        button_CheckInWorkout.Visible = false;
                        button_Add_Abon.Enabled = false;
                        button_add_dop_tren.Visible = false;
                        button_Freeze.Visible = false;
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Абонементы
        private void CurentAbonementChanged(object sender, EventArgs e)
        {
            // Подписываемся на заморозку если появился абонемент
            if (_person.AbonementCurent?.Freeze != null)
            {
                _person.AbonementCurent.Freeze.FreezeChanged -= UpdateInfoTextBoxField;
                _person.AbonementCurent.Freeze.FreezeChanged += UpdateInfoTextBoxField;
            }

            // Подписываемся на изменения в обонементе когда абонемент существует
            if (_person.AbonementCurent != null)
            {
                _person.AbonementCurent.ValuesChanged -= UpdateInfoTextBoxField;
                _person.AbonementCurent.ValuesChanged += UpdateInfoTextBoxField;

                _person.AbonementCurent.ValuesChanged -= UpdateControls;
                _person.AbonementCurent.ValuesChanged += UpdateControls;
            }

            // Тут брать данные изменившегося абонемента и отрисовывать на форме изменения.
            //switch (_person.AbonementCurent)
            //{
            //    case AbonementByDays byDays:
            //        {
            //            break;
            //        }
            //    case ClubCardA clubCardA:
            //        {
            //            break;
            //        }
            //    case SingleVisit singleVisit:
            //        {
            //            break;
            //        }
            //}
        }

        /// <summary>
        /// Обновляет таблицу с посещениями на вкладке посещений.
        /// Сейчас только для Гостевого посещения. Костыль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateVisitsTable(object sender, EventArgs e)
        {
            if (_person.Status == StatusPerson.Гостевой)
            {
                MyDataGridView.SetSourceDataGridView(dataGridView_Visits, Visit.GetVisitsTable(_person));
            }
        }

        private void _person_PersonalNumberChanged(object sender, string e)
        {
            if (!textBox_Number.Text.Equals(_person.IdString))
                textBox_Number.Text = _person.IdString.ToString();
            Logic.SetControlBackColor(textBox_Number, _person.IdString.ToString(), textBox_Number.Text);
        }
        private void _person_SpecialNotesChanged(object sender, string e)
        {
            MyRichTextBox.Load(richTextBox_notes, _person.SpecialNotes);
        }

        private void _person_DriverIdChanged(object sender, string e)
        {
            if (!maskedTextBox_DriverID.Text.Equals(_person.DriverIdNum))
                maskedTextBox_DriverID.Text = _person.DriverIdNum;
            Logic.SetControlBackColor(maskedTextBox_DriverID, _editedDriveId, _person.DriverIdNum);
        }
        private void _person_PassportChanged(object sender, string e)
        {
            if (!maskedTextBox_Passport.Text.Equals(_person.Passport))
                maskedTextBox_Passport.Text = _person.Passport;
            Logic.SetControlBackColor(maskedTextBox_Passport, _editedPassport, _person.Passport);
        }
        private void _person_NameChanged(object sender, string e)
        {
            Text = @"Карточка Клиента:    " + _person.Name; // Имя формы
            label_PersonName.Text = _person.Name;
        }
        private void _person_PhoneChanged(object sender, string e)
        {
            if (!maskedTextBox_PhoneNumber.Text.Equals(_person.Phone))
                maskedTextBox_PhoneNumber.Text = _person.Phone;
            Logic.SetControlBackColor(maskedTextBox_PhoneNumber, maskedTextBox_PhoneNumber.Text, _person.Phone);
        }

        /// <summary>
        /// Включаются|Отключаются различные контролы на форме если был введен пароль руководителя
        /// </summary>
        private void PwdForm_LockChangedEvent()
        {
            if (PwdForm.IsPassUnLocked())
            {
                button_RemoveCurrentAbon.Visible = true;
                // Например, админ должен менять статус оплаты
                textBox_Number.Enabled = true;
            }
            else
            {
                button_RemoveCurrentAbon.Visible = false;
                // Например, админ должен менять статус оплаты
                textBox_Number.Enabled = false;
            }
            LoadEditableData();
            Logic.ClearSelection(groupBox_Detailed);
        }
        private void PathToPhotoChangedMethod(object sender, EventArgs e)
        {
            Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto, _person.GenderType);
        }
        #endregion

        #region  /// МЕТОДЫ

        private void LoadUserData()
        {
            // Имя Клиента
            label_PersonName.Text = _person.Name;
            // Телефон
            maskedTextBox_PhoneNumber.Text = _person.Phone;
            // Паспорт
            maskedTextBox_Passport.Text = _person.Passport;
            // Права
            maskedTextBox_DriverID.Text = _person.DriverIdNum;
            // Персональный Номер
            textBox_Number.Text = _person.IdString;

            // День Рождения
            try
            {
                dateTimePicker_birthDate.Value = _person.BirthDate;
            }
            catch (Exception)
            {
                dateTimePicker_birthDate.Value = DateTime.Now;
            }

            // Пол
            var gendRange = Enum.GetNames(typeof(Gender)).ToArray<object>();
            var gendSelected = _person.GenderType.ToString();
            MyComboBox.Initialize(comboBox_Gender, gendRange, gendSelected);

            // Особые Отметки
            _editedSpecialNote = _person.SpecialNotes;

            MyRichTextBox.Load(richTextBox_notes, _person.SpecialNotes);
        }

        /// <summary>
        /// Инициализирует ЛистБокс с всеми абонементами Клиента. Вызывает прерывание на изменение индекса ЛистБокса
        /// </summary>
        /// <param name="listBox"></param>
        /// <param name="abonementsToShow"></param>
        private void UpdateAbonementsListBox(ListBox listBox, List<AbonementBasic> abonementsToShow)
        {
            if (abonementsToShow == null)
            {
                listBox.DataSource = null;
                return;
            }

            // Диспетчер Абонементов в ListBox
            listBox.DataSource = abonementsToShow;
            listBox.DisplayMember = "AbonementName" ;
            listBox.ValueMember = "AbonementName";
            
        }

        #endregion

        #region // Хелп Методы для Загрузки и обновления пользовательских данных
        private void LoadEditableData()
        {
            // Данные подробные,разрешено редактирование через события.
            var table = Logic.CreateTable(CreateControlsFields(_person.AbonementCurent));
            if (groupBox_Detailed.Controls.Count != 0) groupBox_Detailed.Controls.Clear();

            table.Font = new Font("Arial", 11);

            groupBox_Detailed.Controls.Add(table);
            _isAnythingChanged = false;
        }

        private void UpdateEditableData()
        {
            var listUpdated = CreateControlsFields(_person.AbonementCurent);
            var lst = new List<Control>();
            Logic.ForAllControls(groupBox_Detailed, x =>
            {
                if (x is TextBox || x is ComboBox) lst.Add(x); //Получили только нужные Контролы в массив lst
            });

            for (var i = 0; i < lst.Count; i++) lst[i].Text = listUpdated[i].Item2.Text;
            _isAnythingChanged = false;
            Logic.ClearSelection(groupBox_Detailed);
        }

        /// <summary>
        /// Настройка Источника, Внешнего вида и Помощи для Списка Посещений на вкладке в Карточке клиента
        /// </summary>
        private void SetupVisitsDataGridView()
        {
            var dtable = Visit.GetVisitsTable(_person);
            MyDataGridView.SetSourceDataGridView(dataGridView_Visits, dtable);
            MyDataGridView.ImplementStyle(dataGridView_Visits);
        }

        #region Вкладка Архив Абонементов
        /// <summary>
        /// Настраивает вывод информации о предыдущих абонементах на вкладке Архив Абонементов.
        /// Для обновления таблицы с архивом абон. вызывать этот метод.
        /// </summary>
        private void SetupHistoryAbonement()
        {
            // Получение имен всех полей через атрибуты этих полей. В классе АбонХистори есть атрибуты у полей с описанием имени.
            // var headerStrings = MyReflection.GetPropertiesName(typeof(AbonHistory));
            var headerStrings = MyReflection.GetPropertyDescriptions(typeof(AbonHistory));

            var abonHistories = PersonObject.GetAbonHistoryList(_person.Name);
            if (abonHistories == null) return;

            // Перевернем список
            var abonReverced = abonHistories.Reverse<AbonHistory>().ToList();

            MyDataGridView.SetSourceDataGridView(dataGridView_history_abonements, abonReverced);
            MyDataGridView.ImplementStyle(dataGridView_history_abonements);
            MyDataGridView.AddHeaders(dataGridView_history_abonements, headerStrings);
        }
        #endregion

        private List<Tuple<Label, Control>> CreateControlsFields(AbonementBasic currentAbon)
        {
            List<Tuple<Label, Control>> listResult;
            switch (currentAbon)
            {
                case AbonementByDays _:
                    listResult = CreateListAbonement();
                    break;
                case ClubCardA _:
                    listResult = CreateListClubCard();
                    break;
                case SingleVisit _:
                    listResult = CreateListSingleVisit();
                    break;
                default:
                    listResult = CreateListNoAbonement();
                    break;
            }
            return listResult;
        }
        private List<Tuple<Label, Control>> CreateListNoAbonement()
        {
            var list = new List<Tuple<Label, Control>>
            {
                CreateNameField(),
                CreateStatusField()
            };
            return list;
        }
        private List<Tuple<Label, Control>> CreateListSingleVisit()
        {
            var list = new List<Tuple<Label, Control>>
            {
                CreateNameField(),
                CreateStatusField(),
                CreateActivationField(),
                CreateTypeWorkoutField(),
                CreateSpaServiceField(),
                CreatePayServiceField(),
                CreateBuyDateField(),
                CreateActivationDateField(),
            };

            return list;
        }
        private List<Tuple<Label, Control>> CreateListClubCard()
        {
            var list = new List<Tuple<Label, Control>>
            {
                CreateNameField(),
                CreateStatusField(),
                CreateActivationField(),
                CreatePeriodClubCardField(),
                CreateTypeWorkoutField(),
                CreateTimeForTrField(),
                CreateSpaServiceField(),
                CreateNumPersonalTrField(),
                CreateNumAerobicTrField(),
                CreateRemainderDaysField(),
                CreatePayServiceField(),
                CreateBuyDateField(),
                CreateActivationDateField(),
                CreateEndDateField()
            };
            return list;
        }
        private List<Tuple<Label, Control>> CreateListAbonement()
        {
            var list = new List<Tuple<Label, Control>>
            {
                CreateNameField(),
                CreateStatusField(),
                CreateActivationField(),
                CreateNumberDaysInAbonField(),
                CreateTypeWorkoutField(),
                CreateTimeForTrField(),
                CreateSpaServiceField(),
                CreateRemainderDaysField(),
                CreatePayServiceField(),
                CreateBuyDateField(),
                CreateActivationDateField(),
                CreateEndDateField()
            };

            return list;
        }

        private void SaveData()
        {
            _saveDelegateChain?.Invoke(); //Цепочка делегатов на сохранение всех полей
            _isAnythingChanged = false;
            _typeClubCardChanged = false;
            _saveDelegateChain = null;
        }
        #endregion

        #region /// СТАНДАРТНЫЕ ОБРАБОТЧИКИ ////

        private void button_CheckInWorkout_Click(object sender, EventArgs e)
        {
            var isOk = _logic.CheckInWorkout(_person.Name);

            if (isOk)
            {
                // Обновление всех полей и состояний
                // Logic.LoadShortInfo(groupBox_Info, _person);
                // LoadEditableData();
                // Для обновления списка посещений при добавлении новой тренировки
                //MyDataGridView.SetSourceDataGridView(dataGridView_Visits, Visit.GetVisitsTable(_person));
                Close();
            }

            // Перенос Фокуса на кнопку 
            button_CheckInWorkout.Focus();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_SavePersonalData_Click(object sender, EventArgs e)
        {
            SaveData();
            Logic.LoadShortInfo(groupBox_Info, _person);
            LoadEditableData();
            Logic.SetControlsColorDefault(groupBox_Detailed);
            Logic.SetControlsColorDefault(tableLayoutPanel1);
            Logic.SaveEverithing();
            Logic.ClearSelection(groupBox_Detailed);
        }

        private void ClientForm_Resize(object sender, EventArgs e)
        {
            Logic.ClearSelection(groupBox_Detailed);
        }

        private void button_Add_New_Abon_Click(object sender, EventArgs e)
        {
            Logic.AddAbonement(_person.Name);

            button_CheckInWorkout.Focus();
        }

        private void button_add_dop_tren_Click(object sender, EventArgs e)
        {
            //FIXME  Перенести в Логику. 
            using (var form = new NumWorkoutForm(_person.AbonementCurent))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    form.ApplyChanges();
                    PersonObject.SaveAbonementToHistory(_person, _person.AbonementCurent);
                    // FIXME Убрать эти функции отсюда, возвращать диалог резалт
                    // Обновляем Если выбрано что-то.
                    Logic.LoadShortInfo(groupBox_Info, _person);
                    LoadEditableData();
                }
                else
                {
                    return;
                }
            }

            button_CheckInWorkout.Focus();
        }

        private void button_remove_current_abon_Click(object sender, EventArgs e)
        {
            if (_person.AbonementCurent == null) return;

            var result = MessageBox.Show($@"Будет удаленo: {_person.AbonementCurent.AbonementName}.Продолжить?",
                @"Удаление Абонемента!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            // Удаляем абонемент из коллекции AbonementController
            _abonementController.RemoveAbonement(_person.Name, _person.AbonementCurent);
        }

        private void button_Password_Click(object sender, EventArgs e)
        {
            Logic.AccessRootUser();
        }

        private void button_Freeze_Click(object sender, EventArgs e)
        {
            var status = _person.Status;
            // Чередуется заморозка и разморозка. Если абонемент заморожен - доступна только разморозка
            // Для Разморозки
            if (status == StatusPerson.Заморожен)
            {
                var result = MessageBox.Show(@"Разморозить абонемент?", @"Разморозка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;

                var abon = _person.AbonementCurent as ClubCardA;
                abon?.Freeze.UnFreezeCurrent();
                RunStatusDirector(this, EventArgs.Empty);
            }
            else //  Для заморозки
            {
                var dlgResult = FormsRunner.RunFreezeForm(_person.Name);
                if (dlgResult == DialogResult.Cancel)
                {
                    return;
                }
                RunStatusDirector(this, EventArgs.Empty);
            }

            // Для обновления
            Logic.LoadShortInfo(groupBox_Info, _person);
            UpdateEditableData();
        }

        private void button_photo_Click(object sender, EventArgs e)
        {
            var success = Photo.OpenPhoto(out var img);
            var path = Photo.SaveToPhotoDir(img, _person.Name);
            if (success) _person.PathToPhoto = Path.GetFileName(path);
        }

        private void button_photo_cam_Click(object sender, EventArgs e)
        {
            // Открывает форму для получения снимка. 
            var isPictOk = Logic.GetWebCamBmp(out Bitmap picture);

            if (!isPictOk || picture == null) return;

            // Прописывает в персону имя файла фотки. Сохраняет копию изображения
            var path = Photo.SaveToPhotoDir(picture, _person.Name);
            _person.PathToPhoto = Path.GetFileName(path);
        }

        private void listBox_abon_selector_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = listBox_abon_selector.SelectedIndex;
            if (selectedIndex == -1) return;
            // Если не выбрано ничего - выходим
            if (listBox_abon_selector.Items.Count == 0)
            {
                _person.AbonementCurent = null;
                return;
            }

            // Уберем выделение в Списке Сгоревших абонементов.
            listBox_NotValidAbons.SelectedIndex = -1;

            // Проверяем, изменился ли выбранный абонемент
            if (_person.AbonementCurent == listBox_abon_selector.SelectedItem as AbonementBasic) return;

            // Абонемент изменился
            _person.AbonementCurent = listBox_abon_selector.SelectedItem as AbonementBasic;
            flowLayoutPanel1.Enabled = true;
        }

        /// <summary>
        /// Заходим сюда когда выбирается Сгоревший абонемент. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_NotValidAbons_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = listBox_NotValidAbons.SelectedIndex;
            // Если не выбрано ничего - выходим
            if (selectedIndex == -1 || listBox_NotValidAbons.Items.Count == 0) return;

            listBox_abon_selector.SelectedIndex = -1;

            var selectedAbonement = listBox_NotValidAbons.SelectedItem as AbonementBasic;

            // Абонемент изменился
            Logic.LoadShortInfo(groupBox_Info, selectedAbonement);
            label_infoText.Text = @"Абонемент Сгорел";
            // Блокировка панели с кнопками если выбран Сгоревший абонемент. Блокируем если есть действующие абонементы
            if (listBox_abon_selector.Items.Count != 0)
                flowLayoutPanel1.Enabled = false;
        }

        /// <summary>
        /// Нужен для Активации Кнопок. Они выключаются на время отображения Сгоревших абонементов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox_abon_selector_MouseClick(object sender, MouseEventArgs e)
        {
            if (flowLayoutPanel1.Enabled) return;

            flowLayoutPanel1.Enabled = true;
            Logic.LoadShortInfo(groupBox_Info, _person);
            UpdateControls(this, EventArgs.Empty);
            UpdateInfoTextBoxField(this, EventArgs.Empty);
        }

        // Кнопки управвления цветом в Заметках
        private void button_Clear_Selection_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ClearFormat(richTextBox_notes);
        }

        private void button_Bold_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleBold(richTextBox_notes);
        }

        private void button_Green_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.Green);
        }

        private void button_Blue_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.DarkBlue);
        }

        private void button_Red_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.Red);
        }
        private void toolStripMenuItem_Red_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.Red);
        }

        private void toolStripMenuItem_Green_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.Green);
        }

        private void toolStripMenuItem_Blue_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleColor(richTextBox_notes, Color.DarkBlue);
        }

        private void toolStripMenuItem_Bold_Click(object sender, EventArgs e)
        {
            MyRichTextBox.ToggleBold(richTextBox_notes);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Visible = tabControl1.SelectedIndex == 0;
        }

        #endregion


    }
}