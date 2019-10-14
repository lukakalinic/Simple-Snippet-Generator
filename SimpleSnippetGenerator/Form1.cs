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
        private int lastCaretPos = 0;
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

        private void scintillaBox_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            // Has the caret changed position?
            var caretPos = scintillaBox.CurrentPosition;
            if (lastCaretPos != caretPos)
            {
                lastCaretPos = caretPos;
                var bracePos1 = -1;
                var bracePos2 = -1;

                // Is there a brace to the left or right?
                if (caretPos > 0 && Utility.IsBrace(scintillaBox.GetCharAt(caretPos - 1)))
                    bracePos1 = (caretPos - 1);
                else if (Utility.IsBrace(scintillaBox.GetCharAt(caretPos)))
                    bracePos1 = caretPos;

                if (bracePos1 >= 0)
                {
                    // Find the matching brace
                    bracePos2 = scintillaBox.BraceMatch(bracePos1);
                    if (bracePos2 == Scintilla.InvalidPosition)
                    {
                        scintillaBox.BraceBadLight(bracePos1);
                        scintillaBox.HighlightGuide = 0;
                    }
                    else
                    {
                        scintillaBox.BraceHighlight(bracePos1, bracePos2);
                        scintillaBox.HighlightGuide = scintillaBox.GetColumn(bracePos1);
                    }
                }
                else
                {
                    // Turn off brace matching
                    scintillaBox.BraceHighlight(Scintilla.InvalidPosition, Scintilla.InvalidPosition);
                    scintillaBox.HighlightGuide = 0;
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            scintillaBox.IndentationGuides = IndentView.LookBoth;
            scintillaBox.Styles[Style.BraceLight].BackColor = Color.LightGray;
            scintillaBox.Styles[Style.BraceLight].ForeColor = Color.BlueViolet;
            scintillaBox.Styles[Style.BraceBad].ForeColor = Color.Red;
        }

        #endregion

        #region Methods for Scintilla

        private void InitSyntaxFormatting()
        {
            // Reset the styles
            scintillaBox.StyleResetDefault();
            scintillaBox.Styles[Style.Default].Font = "Courier New";
            scintillaBox.Styles[Style.Default].Size = Convert.ToInt32(fontSizeNumericUpDown.Value);
            scintillaBox.StyleClearAll();

            // Set the SQL Lexer
            scintillaBox.Lexer = Lexer.Sql;

            // Set the Styles
            scintillaBox.Styles[Style.LineNumber].ForeColor = Color.FromArgb(255, 128, 128, 128);  //Dark Gray
            scintillaBox.Styles[Style.LineNumber].BackColor = Color.FromArgb(255, 228, 228, 228);  //Light Gray
            scintillaBox.Styles[Style.Sql.Comment].ForeColor = Color.Green;
            scintillaBox.Styles[Style.Sql.CommentLine].ForeColor = Color.Green;
            scintillaBox.Styles[Style.Sql.CommentLineDoc].ForeColor = Color.Green;
            scintillaBox.Styles[Style.Sql.Number].ForeColor = Color.Maroon;
            scintillaBox.Styles[Style.Sql.Word].ForeColor = Color.Blue;
            scintillaBox.Styles[Style.Sql.Word2].ForeColor = Color.Fuchsia;
            scintillaBox.Styles[Style.Sql.User1].ForeColor = Color.Gray;
            scintillaBox.Styles[Style.Sql.User2].ForeColor = Color.FromArgb(255, 00, 128, 192);    //Medium Blue-Green
            scintillaBox.Styles[Style.Sql.String].ForeColor = Color.Red;
            scintillaBox.Styles[Style.Sql.Character].ForeColor = Color.Red;
            scintillaBox.Styles[Style.Sql.Operator].ForeColor = Color.Black;

            // Set keyword lists
            // Word = 0
            scintillaBox.SetKeywords(0, @"add alter as authorization backup begin bigint binary bit break browse bulk by cascade case catch check checkpoint close clustered column commit compute constraint containstable continue create current cursor cursor database date datetime datetime2 datetimeoffset dbcc deallocate decimal declare default delete deny desc disk distinct distributed double drop dump else end errlvl escape except exec execute exit external fetch file fillfactor float for foreign freetext freetexttable from full function goto grant group having hierarchyid holdlock identity identity_insert identitycol if image index insert int intersect into key kill lineno load merge money national nchar nocheck nocount nolock nonclustered ntext numeric nvarchar of off offsets on open opendatasource openquery openrowset openxml option order over percent plan precision primary print proc procedure public raiserror read readtext real reconfigure references replication restore restrict return revert revoke rollback rowcount rowguidcol rule save schema securityaudit select set setuser shutdown smalldatetime smallint smallmoney sql_variant statistics table table tablesample text textsize then time timestamp tinyint to top tran transaction trigger truncate try union unique uniqueidentifier update updatetext use user values varbinary varchar varying view waitfor when where while with writetext xml go ");
            // Word2 = 1
            scintillaBox.SetKeywords(1, @"ascii cast char charindex ceiling coalesce collate contains convert current_date current_time current_timestamp current_user floor isnull max min nullif object_id session_user substring system_user tsequal ");
            // User1 = 4
            scintillaBox.SetKeywords(4, @"all and any between cross exists in inner is join left like not null or outer pivot right some unpivot ( ) * ");
            // User2 = 5
            scintillaBox.SetKeywords(5, @"sys objects sysobjects ");
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
