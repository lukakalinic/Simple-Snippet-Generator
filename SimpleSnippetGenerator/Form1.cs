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
using ScintillaNET;

namespace SimpleSnippetGenerator
{
    public partial class Form : System.Windows.Forms.Form
    {
        #region Fields
        private int maxLineNumberCharLength;
        private const int padding = 2;
        #endregion

        public Form()
        {
            InitializeComponent();

            foreach (var margin in scintillaBox.Margins)
            {
                margin.Width = 0;
            }

            fontSizeNumericUpDown.Value = Convert.ToDecimal(scintillaBox.Font.Size);
            maxLineNumberCharLength = scintillaBox.Lines.Count.ToString().Length;
            InitSyntaxFormatting();
        }


        #region Events

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Reseting all
            scintillaBox.Text = "";
            scintillaBox.ScrollWidth = 1;
            authorTextBox.Clear();
            titleTextBox.Clear();
            descriptionRichTextBox.Clear();

            //Setting default values
            fontSizeNumericUpDown.Value = 8;
            InitSyntaxFormatting();
            
            //Setting default radioButtons to be checked
            expansionSnippetRadioButton.Checked = true;
            surroundWithRadioButton.Checked = false;

            //Reset state of Scintilla to default state
            maxLineNumberCharLength = scintillaBox.Lines.Count.ToString().Length;
            textWidthUpdate(scintillaBox, lineNumberCheckBox, "clearButton_Click");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = "Snippet (*.snippet*)|*.snippet";

            string xml = Utility.CreateXML(scintillaBox, descriptionRichTextBox, titleTextBox, authorTextBox, expansionSnippetRadioButton, surroundWithRadioButton);

            //================= Ovde cemo eventualno (SINTAKSNO) da validiram unešeni upit =======================

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Utility.SaveFile(saveFileDialog.FileName, xml);
                MessageBox.Show("Successfuly created snippet!", "Success");
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Fail");
            }
        }

        private void scintillaBox_TextChanged(object sender, EventArgs e)
        {
            textWidthUpdate(scintillaBox, lineNumberCheckBox, "scintillaBox_TextChanged");
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            InitSyntaxFormatting();

            textWidthUpdate(scintillaBox, lineNumberCheckBox, "fontSizeNumericUpDown_ValueChanged");
        }

        private void lineNumberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            textWidthUpdate(scintillaBox, lineNumberCheckBox, "lineNumberCheckBox_CheckedChanged");
        }

        #endregion

        #region Methods for Scintilla

        private void InitSyntaxFormatting()
        {
            // Configure the default style
            scintillaBox.StyleResetDefault();
            scintillaBox.Styles[Style.Default].Font = "Consolas";
            scintillaBox.Styles[Style.Default].SizeF = Convert.ToSingle(fontSizeNumericUpDown.Value);
            scintillaBox.StyleClearAll();

            // Setting selection background color
            scintillaBox.SetSelectionBackColor(true, IntToColor(0xFFAAFF));

            // Configure the CPP (C#) lexer styles
            scintillaBox.Styles[Style.Sql.Default].ForeColor = Color.Silver;
            scintillaBox.Styles[Style.Sql.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintillaBox.Styles[Style.Sql.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintillaBox.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            scintillaBox.Styles[Style.Sql.Number].ForeColor = Color.Olive;
            scintillaBox.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            scintillaBox.Styles[Style.Sql.Word2].ForeColor = Color.Blue;
            scintillaBox.Styles[Style.Sql.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintillaBox.Styles[Style.Sql.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintillaBox.Styles[Style.Sql.Operator].ForeColor = Color.Purple;
            

            scintillaBox.Lexer = Lexer.Sql;

            scintillaBox.SetKeywords(0, "add constraint alter column and any as asc backup database between case check " +
                "create index replace view procedure unique default delete desc distinct drop exec exists foreign key " +
                "from full outer join group by having in inner insert into select is left like limit not or " +
                "order primary right rownum top set table truncate union all update values where null");
        }

        private void showLineNumbers(Scintilla scintillaBox)
        {
            var maxLineNumberCharLength = scintillaBox.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            scintillaBox.Margins[0].Width = scintillaBox.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        #endregion

        private void textWidthUpdate(Scintilla scintillaBox, CheckBox lineNumberCheckBox, string methodName)
        {
            switch (methodName)
            {
                case "fontSizeNumericUpDown_ValueChanged":
                    //I ovde moze da bude problem sa prikazivanjem broja,
                    //Kada se uveca font, desi se da brojevi iskoce van margine!
                    if (lineNumberCheckBox.Checked)
                    {
                        scintillaBox.Margins[0].Width = scintillaBox.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
                    }

                    break;
                case "scintillaBox_TextChanged":
                    if (lineNumberCheckBox.Checked)
                    {
                        showLineNumbers(scintillaBox);
                    }
                    else
                    {
                        //Ovo ovde je obavezno jer npr ako je checkBox unchecked,
                        //svaku novu liniju koju unesem, ako br. linija predje 10, onda 
                        //ce desetku da mi ispise malo odsecenu tj nece upasti u marginu kako treba.
                        //Zato uvek azuriram sirinu margine, iako je ne ispisujem.
                        maxLineNumberCharLength = scintillaBox.Lines.Count.ToString().Length;
                    }

                    break;
                case "lineNumberCheckBox_CheckedChanged":
                    if (lineNumberCheckBox.Checked)
                    {
                        scintillaBox.Margins[0].Width = scintillaBox.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
                    }
                    else
                    {
                        foreach (var margin in scintillaBox.Margins)
                        {
                            margin.Width = 0;
                        }
                    }

                    break;

                case "clearButton_Click":
                    if (lineNumberCheckBox.Checked)
                    {
                        scintillaBox.Margins[0].Width = scintillaBox.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
                    }

                    break;
                default:
                    throw new Exception("Wrong signal!");
            }
        }
    }
}
