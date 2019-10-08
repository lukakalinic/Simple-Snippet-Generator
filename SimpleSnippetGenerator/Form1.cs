using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UtilityLibrary;

namespace SimpleSnippetGenerator
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            fontSizeNumericUpDown.Value = Convert.ToDecimal(inputRichTextBox.Font.Size);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Reseting all
            inputRichTextBox.Clear();
            authorTextBox.Clear();
            titleTextBox.Clear();
            descriptionRichTextBox.Clear();

            //Setting default values
            fontSizeNumericUpDown.Value = 8;
            Utility.SetFontSize(fontSizeNumericUpDown, inputRichTextBox);

            //Setting default radioButtons to be checked
            insertSnippetRadioButton.Checked = true;
            surroundWithRadioButton.Checked = false;
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Utility.SetFontSize(fontSizeNumericUpDown, inputRichTextBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string test = Utility.CreateXML(inputRichTextBox, descriptionRichTextBox, titleTextBox, authorTextBox);
        }
    }
}
