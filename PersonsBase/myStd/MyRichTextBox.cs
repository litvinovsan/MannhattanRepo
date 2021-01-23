using System;
using System.Drawing;
using System.Windows.Forms;

namespace PersonsBase.myStd
{
    static class MyRichTextBox
    {
        /// <summary>
        /// Сохраняет в  string текст из RichTextBox с спец символами форматирования
        /// </summary>
        /// <param name="richText"></param>
        /// <returns></returns>
        public static string Save(RichTextBox richText)
        {
            return richText.Rtf;
        }

        /// <summary>
        /// Загружает в текстбокс текст содержащий символы форматирования Richtextbox(цвет размер,шрифт)
        /// Если текст не содержит спец символов, то будет загружен как обычный текст
        /// </summary>
        /// <param name="richText"></param>
        /// <param name="text"></param>
        public static void Load(RichTextBox richText, string text)
        {
            try
            {
                richText.Rtf = text;
            }
            catch (Exception)
            {
                richText.Text = text;
            }
        }

        /// <summary>
        /// Очищает форматирование всего текстбокса
        /// </summary>
        /// <param name="richText"></param>
        public static void ClearFormat(RichTextBox richText)
        {
            // При записи текста в поле текст - сбрасываются настройки формата.
            richText.Text = richText.Text;
        }

        public static void ToggleBold(RichTextBox richTextBox)
        {
            // рабочий код
            //var fontBold = new Font(richTextBox.Font, FontStyle.Bold);
            //var fontRegular = new Font(richTextBox.Font, FontStyle.Regular);
            //richTextBox.SelectionFont = Equals(richTextBox.SelectionFont.Bold, true) ? fontRegular : fontBold;

            if (richTextBox.SelectionFont == null) return;

            var currentFont = richTextBox.SelectionFont;

            var newFontStyle = richTextBox.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold;

            richTextBox.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
        }

        public static void ToggleColor(RichTextBox richTextBox, Color color)
        {
            if (richTextBox.SelectionFont == null) return;

            richTextBox.SelectionColor = richTextBox.SelectionColor == color ? Color.Black : color;
        }
    }
}
