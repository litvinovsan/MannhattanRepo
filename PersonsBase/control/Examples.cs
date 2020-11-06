namespace TestProj
{
    class Examples
    {
        #region Сохранение настроек в датаДикшн

        /* Способ хранения настроек в Дикшин. Зависит от Енумов
         
            public Dictionary<MessageEnum, bool> CheckBoxOptionsMessages; // Храним настройки галок по Опциям Error,Debug,Data

            CheckBoxOptionsMessages = new Dictionary<MessageEnum, bool>
            {
                {MessageEnum.Data, true},
                {MessageEnum.Debug, true},
                {MessageEnum.Error, true}
            };
             
             
        */
        #endregion

        #region Пример использования Событий
        /*
           Обьявляем событие: public event EventHandler nameToShowEvent   
                              public event Action nameToShowEvent;
                              public event EventHandler<EventArgs> nameToShowEvent;

           Создаем метод - запускатор события:       Вызывать его чтобы сгенерировать событие
                             public void OnPersonChanged()
                             {
                                if (nameToShowEvent != null) nameToShowEvent();
                             }
                             или
                             nameToShowEvent?.Invoke();   // Если просто Action
                             nameToShowEvent?.Invoke(this, EventArgs.Empty);

           Подписываемся на событие:
                            nameToShowEvent += OnListChanged; // Событие на изменение коллекции с клиентами
                            void OnListChanged(object sender, EventArgs e)
                            {
                                 Console.WriteLine("Произошло событие добавления в лист");
                            }




        public event EventHandler<string> nameToShowEvent;
        public void OnNameToShow(string name)   // Запускатор события
        {
           //nameToShowEvent?.Invoke(name);
           if (nameToShowEvent != null) nameToShowEvent(this, name);
        }

        OnNameToShow(nameToShow); // Запускаем событие

           */
        #endregion

        #region Доступ к контролам формы из разных потоков

        //public void ClearFindCombo()
        //{
        //    void MyDelegate() => сomboBox_PersonsList.SelectedText = "";
        //    if (InvokeRequired)
        //    {
        //        Invoke((Action)MyDelegate);
        //    }
        //    else
        //    {
        //        MyDelegate();
        //    }
        //}

        // Пример потокобезопасного метода
        //void SetTextSafe(string newText)
        //{
        //   if (textBox1.InvokeRequired) textBox1.Invoke(new Action<string>((s) => textBox1.Text = s), newText);
        //   else textBox1.Text = newText;
        //}

        #endregion

        #region BINDING
        // Загрузка данных в ListBox
        //private void InitListBoxAbonements(List<AbonementBasic> abonementsToShow)
        //{
        //    listBox_abon_selector.DataSource = abonementsToShow; 
        //    listBox_abon_selector.DisplayMember = "AbonementName"; // где название текстового поля в классе AbonementBasic. Будет отображаться в листбоксе
        //    listBox_abon_selector.ValueMember = "AbonementName";
        //}
        //Получение обьекта - var abonselected= (AbonementBasic)listBox_abon_selector.SelectedItem


        /* BINDING DataGrid
                https://www.c-sharpcorner.com/UploadFile/deveshomar/ways-to-bind-datagridview-in-window-forms-C-Sharp/        
                List does not implement IBindingList so the grid does not know about your new items.

                Bind your DataGridView to a BindingList<T> instead.

                var list = new BindingList<Person>(persons);
                myGrid.DataSource = list;
                But I would even go further and bind your grid to a BindingSource

                var list = new List<Person>()
                {
                    new Person { Name = "Joe", },
                    new Person { Name = "Misha", },
                };
                var bindingList = new BindingList<Person>(list);
                var source = new BindingSource(bindingList, null);
                grid.DataSource = source;
                    grid.Refresh();        
             */
        #endregion

        #region Разное
        /* Текст из ENUMERATION
        * .AddRange(Enum.GetNames(typeof(Gender)).ToArray<object>());
        * .SelectedItem = _person.GenderType.ToString();
        *
        *
        */

        /*
        * // Проверка обьекта на Тип
        //if (obj is MyObject)

        // или более точно.
        //obj.GetType() == typeof(MyObject)

        /*   Cоздание массива с текстбоксами
        TextBox [] tb = new TextBox[20];
        for (int i = 0; i < tb.Length; i++)
        {
        tb[i] = new TextBox();
        //бла-бла-бла
        Controls.Add(tb[i]);
        }

        const int lengthArray = 10;
        Control[] controlsArray = new Control[lengthArray];

        private void buttonCreate_Click(object sender, EventArgs e)
        {
        for (int i = 0; i < lengthArray; i++)
        {
          controlsArray[i] = new TextBox() { Name = i.ToString(), Location = new Point(10, i * 20), Text = "Number" + i.ToString() };
           this.Controls.Add(controlsArray[i]);
        }
        }
        */
        #endregion

    }
}
