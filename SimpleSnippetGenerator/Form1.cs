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
        #endregion

        public Form()
        {
            InitializeComponent();
            fontSizeNumericUpDown.Value = Convert.ToDecimal(scintillaBox.Font.Size);
            InitSyntaxFormatting(8);
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
            InitSyntaxFormatting(8);


            //Setting default radioButtons to be checked
            insertSnippetRadioButton.Checked = true;
            surroundWithRadioButton.Checked = false;
        }

        private void fontSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(fontSizeNumericUpDown.Value);
            InitSyntaxFormatting(size);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = "Snippet (*.snippet*)|*.snippet";

            string xml = Utility.CreateXML(scintillaBox, descriptionRichTextBox, titleTextBox, authorTextBox);

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
            var maxLineNumberCharLength = scintillaBox.Lines.Count.ToString().Length;
            if (maxLineNumberCharLength == this.maxLineNumberCharLength)
                return;

            const int padding = 1;
            scintillaBox.Margins[0].Width = scintillaBox.TextWidth(Style.LineNumber, new string('9', maxLineNumberCharLength + 1)) + padding;
            this.maxLineNumberCharLength = maxLineNumberCharLength;
        }

        #endregion
        
        private void InitSyntaxFormatting(float fontSize)
        {
            // Configure the default style
            scintillaBox.StyleResetDefault();
            scintillaBox.Styles[Style.Default].Font = "Consolas";
            scintillaBox.Styles[Style.Default].SizeF = fontSize;
            scintillaBox.StyleClearAll();

            // Setting selection background color
            scintillaBox.SetSelectionBackColor(true, IntToColor(0x114D9C));

            // Configure the CPP (C#) lexer styles
            scintillaBox.Styles[Style.Cpp.Default].ForeColor = Color.Silver;
            scintillaBox.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintillaBox.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0); // Green
            scintillaBox.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128); // Gray
            scintillaBox.Styles[Style.Cpp.Number].ForeColor = Color.Olive;
            scintillaBox.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            scintillaBox.Styles[Style.Cpp.Word2].ForeColor = Color.Blue;
            scintillaBox.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintillaBox.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintillaBox.Styles[Style.Cpp.Verbatim].ForeColor = Color.FromArgb(163, 21, 21); // Red
            scintillaBox.Styles[Style.Cpp.StringEol].BackColor = Color.Pink;
            scintillaBox.Styles[Style.Cpp.Operator].ForeColor = Color.Purple;
            scintillaBox.Styles[Style.Cpp.Preprocessor].ForeColor = Color.Maroon;

            scintillaBox.Lexer = Lexer.Cpp;

            scintillaBox.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            scintillaBox.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
        }

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
    }
}
