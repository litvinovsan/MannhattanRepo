using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsBase.data.Abonements
{
    public class AbonementsController
    {
        private readonly ObservableCollection<AbonementBasic> _collection;

        public AbonementsController(ObservableCollection<AbonementBasic> collection)
        {
            _collection = collection ?? throw new NullReferenceException("В Контроллер Абонементов передан пустой обьект списка.");
        }

        /// <summary>
        /// Возвращает Первый абонемент из очереди
        /// </summary>
        /// <returns></returns>
        public AbonementBasic GetAbonement()
        {

            if (_collection == null || _collection?.Count == 0)
            {
                return null;
            }
            else
            {
                var abon = _collection.First();
                return abon;
            }
        }

        /// <summary>
        /// Возвращает актуальный абонемент и добавляет-удаляет новые абонементы
        /// Если на вход подается null - возвращает следующий из очереди
        /// </summary>
        /// <param name="newAbonementValue"></param>
        /// <returns></returns>
        public AbonementBasic AddToQueue(AbonementBasic newAbonementValue)
        {
            var resultAbon = (_collection?.Count > 0) ? _collection?.First() : null;
            if (newAbonementValue == null)
            {
                _collection?.RemoveAt(0);

                resultAbon = (_collection?.Count > 0) ? _collection?.First() : null;
            }
            else
            {
                _collection?.Add(newAbonementValue);
            }

            return resultAbon;
        }
    }
}
