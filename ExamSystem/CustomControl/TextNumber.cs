using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExamSystem.CustomControl
{
    class TextNumber : TextBox
    {
      

       public TextNumber() :base()
        {
            this.PreviewTextInput += TextNumber_PreviewTextInput;
            this.TextChanged += TextNumber_TextChanged;
            InputMethod.SetIsInputMethodEnabled(this, false);
            this.Text = "0";
        }

        private void TextNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextNumber textNumber = sender as TextNumber;
            if(textNumber.Text.Length == 0)
            {
                this.Text = "0";
            }
        }

        private void TextNumber_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            string pattern = @"^[\b|0-9]$";
            Regex re = new Regex(pattern);
            e.Handled = !re.IsMatch(e.Text);

        }

    }
}
