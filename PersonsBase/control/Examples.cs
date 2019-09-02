namespace TestProj
{
    class Examples
    {

        /* Способ хранения настроек в Дикшин. Зависит от Енумов
         
            public Dictionary<MessageEnum, bool> CheckBoxOptionsMessages; // Храним настройки галок по Опциям Error,Debug,Data

            CheckBoxOptionsMessages = new Dictionary<MessageEnum, bool>
            {
                {MessageEnum.Data, true},
                {MessageEnum.Debug, true},
                {MessageEnum.Error, true}
            };
             
             
        */




        /*************** СОБЫТИЯ И ОБРАБОТЧИКИ СОБЫТИЙ     ****************/
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


        Examples()
        {
            // Пример потокобезопасного метода
            //void SetTextSafe(string newText)
            //{
            //   if (textBox1.InvokeRequired) textBox1.Invoke(new Action<string>((s) => textBox1.Text = s), newText);
            //   else textBox1.Text = newText;
            //}

            // Проверка обьекта на Тип
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

               private void buttonDelete_Click(object sender, EventArgs e)
               {
                 for (int i = 0; i < 10; i++)
                  {
                      this.Controls.Remove(controlsArray[i]);
                   }
               }




            */



        }
        public string ClassName
        {
            get
            {
                return GetType().Name;
            }
        }


    }
}
