using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace PersonsBase.data
{
    /// <summary>
    /// Вспомогательные и универсальные методы, которые неразместить в конкретных классах.
    /// </summary>
    [Serializable]
    public static class ExtensionMethods
    {
        #region /// МЕТОДЫ РАСШИРЕНИЙ
        public static void DoubleBuffered(this Control dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (pi != null) pi.SetValue(dgv, setting, null);
        }

        /// <summary>
        /// Переименовывает Ключ в Дикшнари. Внутри создается новый обьект,старый удаляется.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dic"></param>
        /// <param name="fromKey"></param>
        /// <param name="toKey"></param>
        public static void RenameKey<TKey, TValue>(this IDictionary<TKey, TValue> dic, TKey fromKey, TKey toKey)
        {
            if (!dic.ContainsKey(fromKey)) return;

            var value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        #endregion
    }
}
