using System;
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

        #endregion
    }
}
