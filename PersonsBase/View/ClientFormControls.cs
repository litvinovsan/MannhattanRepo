using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PersonsBase.control;
using PersonsBase.data;
using PersonsBase.data.Abonements;

namespace PersonsBase.View
{
   public partial class ClientForm
   {
      // Поля персональных данных
      #region // Поле. Телефон

      private string _editedPhone;
      private void maskedTextBox_PhoneNumber_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedPhone = tb.Text;
         Logic.SetControlBackColor(tb, _editedPhone, _person.Phone);
      }


      #endregion

      #region // Поле. Паспорт

      private string _editedPassport;
      private void maskedTex_Passport_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedPassport = tb.Text;
         Logic.SetControlBackColor(tb, _editedPassport, _person.Passport);
      }
      #endregion

      #region // Поле. Права

      private string _editedDriveId;
      private void maskedTextBox_DriverID_TextChanged(object sender, EventArgs e)
      {
         var tb = (MaskedTextBox)sender;
         _editedDriveId = tb.Text;
         Logic.SetControlBackColor(tb, _editedDriveId, _person.DriverIdNum);
      }
      #endregion

      #region // Поле. День Рождения
      DateTime _editedDr;
      private void dateTimePicker_birthDate_ValueChanged(object sender, EventArgs e)
      {
         var tb = (DateTimePicker)sender;
         _editedDr = tb.Value.Date;
      }

      #endregion

      #region // Поле. Пол
      Gender _editedGender;
      private void comboBox_Gender_SelectedIndexChanged(object sender, EventArgs e)
      {
         ComboChangedMethod(sender, out _editedGender, _person.GenderType);
      }
      #endregion

      #region // Поле. Персональный номер

      private string _editedPersonalNumber = string.Empty;
      private void textBox_Number_TextChanged(object sender, EventArgs e)
      {
         var tb = (TextBox)sender;
         var t = tb.Text;
         //FIXME заменить 1 на не равно 0. может быть любое число тут
         var numberLen = t.StartsWith("1") ? 13 : 12;
         _editedPersonalNumber = tb.Text;
         if (t.Length == numberLen)
         {
            _editedPersonalNumber = Logic.NormalizeBarCodeNumber(tb.Text);
            Logic.SetControlBackColor(tb, _editedPersonalNumber, _person.IdString);
         }
      }

      #endregion

      #region // Поле. Особые отметки
      private string _editedSpecialNote;
      private void richTextBox_notes_TextChanged(object sender, EventArgs e)
      {
         var tb = (RichTextBox)sender;
         _editedSpecialNote = tb.Rtf;
      }

      #endregion

      /// <summary>
      /// Запускается автоматически в цепочке делегатов SaveDelegateChain. SaveData()
      /// </summary>
      private void SaveUserData()
      {
         if (_editedPhone != null && _editedPhone != _person.Phone) _person.Phone = _editedPhone;
         if (_editedPassport != null && _editedPassport != _person.Passport) _person.Passport = _editedPassport;
         if (_editedDriveId != null && _editedDriveId != _person.DriverIdNum) _person.DriverIdNum = _editedDriveId;
         if (_editedDr.CompareTo(_person.BirthDate) != 0) _person.BirthDate = _editedDr;
         if (!Equals(_editedGender, _person.GenderType)) _person.GenderType = _editedGender;

         if (!_editedPersonalNumber.Equals(_person.IdString))
         {
            DataBaseM.EditPersonalNumber(_person.Name, _editedPersonalNumber);
         }

      }
      private void SaveSpecialNotes()
      {
         if (_editedSpecialNote != null && _editedSpecialNote != _person.SpecialNotes) _person.SpecialNotes = _editedSpecialNote;
      }
     
      private void ComboBoxColor(ComboBox comboBox, string oldVal, string curVal)
      {
         Logic.SetControlBackColor(comboBox, curVal, oldVal);
         button_SavePersonalData.Focus(); // Cнимаем выделение сменой фокуса.
      }
      // Разное
      private void ComboChangedMethod<T>(object sender, out T editedVar, T originVar)
      {
         var tb = (ComboBox)sender;
         var edited = (T)Enum.Parse(typeof(T), tb.SelectedItem.ToString());
         editedVar = edited;

         ComboBoxColor(tb, originVar.ToString(), tb.SelectedItem.ToString());
      }
   }
}
