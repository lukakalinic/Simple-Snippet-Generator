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
            descriptionRichTextBox1.Clear();

            //Setting default values
            fontSizeNumericUpDown.Value = 8;
            setFontSize();

            //Setting default radioButtons to be checked
            insertSnippetRadioButton.Checked = true;
            surroundWithRadioButton.Checked = false;
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            setFontSize();
        }

        private void setFontSize()
        {
            float size = Convert.ToSingle(fontSizeNumericUpDown.Value);
            Font myFont = new Font(inputRichTextBox.Font.Name, size);
            inputRichTextBox.Font = myFont;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            XNamespace xn = "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet";

            XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            xdoc.Add(new XElement(xn + "CodeSnippets", new XAttribute("xmlns", "http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet"),
                         new XElement("CodeSnippet", new XAttribute("Format", "1.0.0"),
                         new XElement("Header",
                             new XElement("Title", "value1"),
                             new XElement("Shortcuts"),
                             new XElement("Description", "desc"),
                             new XElement("Author", "author"),
                             new XElement("SnippetTypes",
                                 new XElement("SnippetType", "tip"))),
                         new XElement("Snippet",
                             new XElement("Code", new XAttribute("Language", "XML"), "querry")))));

            //Using only for testing
            string test = xdoc.ToString();
        }
    }
}
