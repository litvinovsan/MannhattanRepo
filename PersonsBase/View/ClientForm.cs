using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;
using PersonsBase.myStd;

namespace PersonsBase.View
{
    public partial class ClientForm : Form
    {
        ///////////////// ОСНОВНЫЕ ОБЬЕКТЫ ////////////////////////////////
        private readonly Logic _logic;
        private readonly Person _person;
        private bool _isAnythingChanged;

        ///////////////// КОНСТРУКТОР. ЗАПУСК. ЗАКРЫТИЕ ФОРМЫ ////////////////////////////////
        public ClientForm(string keyName)
        {
            InitializeComponent();
            _person = DataBaseO.GetPersonLink(keyName);
            _isAnythingChanged = false;
            _logic = Logic.GetInstance();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            LoadUserData();
            Logic.LoadShortInfo(groupBox_Info, _person);
            LoadEditableData();

            Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto);

            UpdateControlState(this, EventArgs.Empty);
            LoadListBoxQueue();
            SetupVisitsDataGridView();

            // Подписка на События
            _saveDelegateChain += SaveUserData; // Цепочка Делегатов для сохранения измененных данных.
            _person.StatusChanged += UpdateControlState;
            _person.PathToPhotoChanged += PathToPhotoChangedMethod;
            PwdForm.LockChangedEvent += PwdForm_LockChangedEvent;

            // События Очередь абонементов
            if (_person.AbonementsQueue == null) _person.AbonementsQueue = new ObservableCollection<AbonementBasic>();
            _person.AbonementsQueue.CollectionChanged +=
                AbonementsQueue_CollectionChanged; // Список Абонементов. Если изменился
            _person.AbonementsQueue.CollectionChanged += ShowAbonementList;

            // На всякий случай, может уменьшит мерцание
            tabControl1.DoubleBuffered(true);
            groupBox4.DoubleBuffered(true);
            groupBox_Info.DoubleBuffered(true);
            groupBox_Detailed.DoubleBuffered(true);
        }

        /// <summary>
        /// Включаются|Отключаются различные контролы на форме если был введен пароль руководителя
        /// </summary>
        private void PwdForm_LockChangedEvent()
        {
            if (PwdForm.IsPassUnLocked())
            {
                button_RemoveCurrentAbon.Visible = true;
                button__remove_abon.Enabled = true;
              //  groupBox_Detailed.Enabled = true; // FIXME тут надо включать и выключать выборочные поля.
                                                  // Например, админ должен менять статус оплаты
                textBox_Number.Enabled = true;
            }
            else
            {
                button_RemoveCurrentAbon.Visible = false;
                button__remove_abon.Enabled = false;
               // groupBox_Detailed.Enabled = true; // / FIXME тут надо включать и выключать выборочные поля.
                                                  // Например, админ должен менять статус оплаты
                textBox_Number.Enabled = false;
            }

            Invalidate();
        }

        /// <summary>
        /// Заполняет ЛистБокс с списком Абонементов КЛиента из очереди абонементов.Только отображение
        /// </summary>
        private void LoadListBoxQueue()
        {
            if (_person.AbonementsQueue == null) return;
            var list = new List<string>();
            foreach (var x in _person.AbonementsQueue) list.Add(x.AbonementName);

            listBox_abonements.Items.AddRange(list.ToArray<object>());
            // Отображение Группы списка абонементов
            groupBox_abonList.Visible = list.Count > 0;
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
        }

        //////////// ЛОГИКА ФОРМЫ ////////////////////////////////////////////////////////
        private void AbonementsQueue_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    if (e.NewItems[0] is AbonementBasic item) listBox_abonements.Items.Add(item.AbonementName);
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    listBox_abonements.Items.RemoveAt(0);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateControlState(object sender, EventArgs arg)
        {
            // Различные изменения, которые зависят от СТАТУСА клиента.
            Action myDelegate = delegate
            {
                // По умолчанию для всех карт
                button_add_dop_tren.Visible = false;
                button_CheckInWorkout.Visible = false;
                button_Freeze.Visible = false;
                button_Add_Abon.Enabled = true;
                // Вкл/Выкл Кнопки ЗАМОРОЗКА и ПОСЕЩЕНИЕ если проблемы с абонементом
                switch (_person.UpdateActualStatus())
                {
                    case StatusPerson.Активный:
                        {
                            button_CheckInWorkout.Visible = true;

                            // Кнопка Заморозка Клубной Карты
                            if (_person.AbonementCurent is ClubCardA a &&
                                a.PeriodAbonem != PeriodClubCard.На_1_Месяц)
                            {
                                button_Freeze.Visible = true;
                                // Кнопка Добавить для Клубной Карты
                                button_add_dop_tren.Visible = true;
                            }

                            break;
                        }
                    case StatusPerson.Нет_Карты:
                        {
                            break;
                        }
                    case StatusPerson.Заморожен:
                        {
                            button_Add_Abon.Enabled = false;
                            button_Freeze.Visible = _person.IsAbonementExist();
                            break;
                        }
                    case StatusPerson.Гостевой:
                        {
                            button_Add_Abon.Enabled = true;
                            break;
                        }
                    case StatusPerson.Запрещён:
                        {
                            button_Add_Abon.Enabled = false;
                            break;
                        }
                }

                UpdateNameText();
            };

            if (InvokeRequired)
                Invoke(myDelegate);
            else
                myDelegate();
        }

        private void ShowAbonementList(object sender, NotifyCollectionChangedEventArgs e)
        {
            groupBox_abonList.Visible = _person.AbonementsQueue.Count > 0;
        }

        private void PathToPhotoChangedMethod(object sender, EventArgs e)
        {
            Logic.TryLoadPhoto(pictureBox_ClientPhoto, _person.PathToPhoto);
        }

        // Сохранение данных 
        private void SaveData()
        {
            _saveDelegateChain?.Invoke(); //Цепочка делегатов на сохранение всех полей
            _isAnythingChanged = false;
            _typeClubCardChanged = false;
        }

        /////////// ДАННЫЕ АБОНЕМЕНТА И КЛИЕНТА /////////////////////////////

        // Загрузка Данных
        private void LoadUserData()
        {
            // Загружаем данные на Вкладку Редактирование, в Группу Персональных данных

            _person.UpdateActualStatus(); // Обновляем текущий статус
            // Имя Клиента на форме.
            UpdateNameText();

            // Телефон
            maskedTextBox_PhoneNumber.Text = _person.Phone;
            Logic.SetControlBackColor(maskedTextBox_PhoneNumber, maskedTextBox_PhoneNumber.Text, _person.Phone);

            // Паспорт
            maskedTextBox_Passport.Text = _person.Passport;
            Logic.SetControlBackColor(maskedTextBox_Passport, _editedPassport, _person.Passport);

            // Права
            maskedTextBox_DriverID.Text = _person.DriverIdNum;
            Logic.SetControlBackColor(maskedTextBox_DriverID, _editedDriveId, _person.DriverIdNum);

            // Персональный Номер
            textBox_Number.Text = _person.PersonalNumber.ToString();

            // День Рождения
            dateTimePicker_birthDate.Value = _person.BirthDate;

            // Пол
            var gendRange = Enum.GetNames(typeof(Gender)).ToArray<object>();
            var gendSelected = _person.GenderType.ToString();
            MyComboBox.Initialize(comboBox_Gender, gendRange, gendSelected);


            // Особые Отметки
            textBox_Notes.Text = _person.SpecialNotes;
            _editedSpecialNote = _person.SpecialNotes;
        }

        private void LoadEditableData()
        {
            // Данные подробные,разрешено редактирование через события.
            var table = Logic.CreateTable(SelectList(_person.AbonementCurent));
            if (groupBox_Detailed.Controls.Count != 0) groupBox_Detailed.Controls.Clear();

            table.Font = new Font("Arial", 10);

            groupBox_Detailed.Controls.Add(table);
            _isAnythingChanged = false;
        }

        private void UpdateEditableData()
        {
            var listUpdated = SelectList(_person.AbonementCurent);
            var lst = new List<Control>();
            Logic.ForAllControls(groupBox_Detailed, x =>
            {
                if (x is TextBox || x is ComboBox) lst.Add(x); //Получили только нужные Контролы в массив lst
            });

            for (var i = 0; i < lst.Count; i++) lst[i].Text = listUpdated[i].Item2.Text;
            _isAnythingChanged = false;
        }

        /// <summary>
        /// Настройка Источника, Внешнего вида и Помощи для Списка Посещений на вкладке в Карточке клиента
        /// </summary>
        private void SetupVisitsDataGridView()
        {
            var dt = Visit.GetVisitsTable(_person);
            var journalVisits = _person.JournalVisits;

            var helpStrings = (journalVisits != null && journalVisits.Count > 0) ? journalVisits.First().GetHeadersToolTipHelp() : new[] { "" };

            MyDataGridView.SetSourceDataGridView(dataGridView_Visits, dt);
            MyDataGridView.ImplementStyle(dataGridView_Visits);
            MyDataGridView.AddHeaderToolTips(dataGridView_Visits, helpStrings);
        }

        #region // Хелп Методы для Загрузки и обновления пользовательских данных

        private void UpdateNameText()
        {
            Text = @"Карточка Клиента:    " + _person.Name; // Имя формы

            textBox_Name.Text = _person.Name;
            Logic.SetFontColor(textBox_Name, _person.Status.ToString(), StatusPerson.Активный.ToString());


            switch (_person.Status)
            {
                // Если Запрещен 
                case StatusPerson.Запрещён:
                    textBox_Name.Text = _person.Name;
                    Logic.SetFontColor(textBox_Name, _person.Status.ToString(), StatusPerson.Активный.ToString());
                    return;
                // Если Заморожен
                case StatusPerson.Заморожен when _person.IsAbonementExist() && _person.AbonementCurent is ClubCardA a && _person.Status != StatusPerson.Гостевой:
                    {
                        textBox_Name.ForeColor = Color.SeaGreen;
                        var dateEnd = a.Freeze?.AllFreezes.Last().GetEndDate().Date.ToString("d");
                        textBox_Name.Text = _person.Name + @"   (Заморожен До " + dateEnd + @" )";
                        break;
                    }
                case StatusPerson.Активный:
                    break;
                case StatusPerson.Нет_Карты:
                    break;
                case StatusPerson.Гостевой:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Заморозка запланирована в будущем
            var card = _person.AbonementCurent as ClubCardA;
            if (card?.Freeze != null && _person.Status != StatusPerson.Заморожен &&
                _person.Status != StatusPerson.Гостевой)
                if (card.Freeze.IsConfiguredForFuture())
                {
                    textBox_Name.ForeColor = Color.SeaGreen;
                    textBox_Name.Text = _person.Name +
                                        $@"   (Заморозка c {card.Freeze.GetFutureFreeze().StartDate.Date:d}, дней: {card.Freeze.GetDaysToFreeze()} )";
                }

            // Не Активирован
            if (_person.IsAbonementExist() && !_person.AbonementCurent.IsActivated)
            {
                textBox_Name.ForeColor = Color.Green;
                textBox_Name.Text = _person.Name + @"   (Не Активирован)";
                button_Freeze.Enabled = false;
            }
            else
            {
                button_Freeze.Enabled = true;
            }
        }
        private List<Tuple<Label, Control>> SelectList(AbonementBasic currentAbon)
        {
            List<Tuple<Label, Control>> listResult;
            if (currentAbon is AbonementByDays)
                listResult = CreateListAbonement();
            else if (currentAbon is ClubCardA)
                listResult = CreateListClubCard();
            else if (currentAbon is SingleVisit)
                listResult = CreateListSingleVisit();
            else
                listResult = CreateListNoAbonement();
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
                CreateTypeWorkoutField(),
                CreateSpaServiceField(),
                CreatePayServiceField()
            };

            return list;
        }
        private List<Tuple<Label, Control>> CreateListClubCard()
        {
            var list = new List<Tuple<Label, Control>>
            {
                CreateNameField(),
                CreateStatusField(),
                CreatePeriodClubCardField(),
                CreateTypeWorkoutField(),
                CreateTimeForTrField(),
                CreateSpaServiceField(),
                CreateNumPersonalTrField(),
                CreateNumAerobicTrField(),
                CreateRemainderDaysField(),
                CreatePayServiceField(),
                CreateBuyDateField(),
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
                CreateNumberDaysInAbonField(),
                CreateTypeWorkoutField(),
                CreateTimeForTrField(),
                CreateSpaServiceField(),
                CreateRemainderDaysField(),
                CreatePayServiceField(),
                CreateBuyDateField(),
                CreateEndDateField()
            };

            return list;
        }

        #endregion
        //////////// СТАНДАРТНЫЕ ОБРАБОТЧИКИ ///////////////////////////////////////////////

        private void button_CheckInWorkout_Click(object sender, EventArgs e)
        {
            var result = _logic.CheckInWorkout(_person.Name);

            if (result)
            {
                // Обновление всех полей и состояний
                _person.UpdateActualStatus();
                UpdateNameText();
                Logic.LoadShortInfo(groupBox_Info, _person);
                LoadEditableData();
                UpdateControlState(this, EventArgs.Empty);
                // Для обновления списка посещений при добавлении новой тренировки
                MyDataGridView.SetSourceDataGridView(dataGridView_Visits, Visit.GetVisitsTable(_person));
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
            LoadUserData();
            Logic.LoadShortInfo(groupBox_Info, _person);
            UpdateEditableData();
            Logic.ClearSelection(groupBox_Detailed);

            Logic.SetControlsColorDefault(groupBox_Detailed);
            Logic.SetControlsColorDefault(tableLayoutPanel1);
        }

        private void ClientForm_Resize(object sender, EventArgs e)
        {
            Logic.ClearSelection(groupBox_Detailed);
        }

        private void button_Add_New_Abon_Click(object sender, EventArgs e)
        {
            var isSuccess = Logic.AddAbonement(_person.Name);
            if (isSuccess)
            {
                _person.UpdateActualStatus(); // Обновляем текущий статус
                UpdateNameText();

                Logic.LoadShortInfo(groupBox_Info, _person);
                LoadEditableData();
                UpdateControlState(this, EventArgs.Empty);
            }

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
                    // FIXME Убрать эти функции отсюда, возвращать диалог резалт
                    // Обновляем Если выбрано что-то.
                    _person.UpdateActualStatus(); // Обновляем текущий статус
                    Logic.LoadShortInfo(groupBox_Info, _person);
                    LoadEditableData();
                    UpdateControlState(this, EventArgs.Empty);
                }
                else
                {
                    return;
                }
            }

            button_CheckInWorkout.Focus();
        }

        private void button_remove_abon_Click(object sender, EventArgs e)
        {
            var selectedIndex = listBox_abonements.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show(@"Выберите Абонемент для удаления!");
            }
            else
            {
                _person.AbonementsQueue.RemoveAt(selectedIndex);
                MessageBox.Show(@"Запись Удалена!");
            }
        }

        private void button_remove_current_abon_Click(object sender, EventArgs e)
        {
            if (_person.AbonementCurent == null) return;
            var result = MessageBox.Show($@"Будет удаленo:  {_person.AbonementCurent.AbonementName}.
Продолжить?", @"Удаление Абонемента!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;
            _person.AbonementCurent = null;
            _person.UpdateActualStatus(); // Обновляем текущий статус

            Logic.LoadShortInfo(groupBox_Info, _person);
            LoadEditableData();
            UpdateControlState(this, EventArgs.Empty);
        }

        private void button_Password_Click(object sender, EventArgs e)
        {
            Logic.AccessRootUser();
        }

        private void button_Freeze_Click(object sender, EventArgs e)
        {
            var status = _person.Status;

            if (status != StatusPerson.Заморожен)
            {
                var dlgResult = FormsRunner.RunFreezeForm(_person.Name);
                if (dlgResult == DialogResult.Cancel) return;
            }
            else
            {
                MessageBox.Show(@"Сейчас абонемент заморожен! Новая заморозка добавится в очередь!", @"Внимание!",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                FormsRunner.RunFreezeForm(_person.Name);
            }

            LoadUserData();
            Logic.LoadShortInfo(groupBox_Info, _person);
            UpdateEditableData();
        }

        private void button_photo_Click(object sender, EventArgs e)
        {
            var success = Photo.OpenPhoto(out var img);
            if (success) _person.PathToPhoto = Photo.SaveToPhotoDir(img, _person.Name);
        }
    }
}