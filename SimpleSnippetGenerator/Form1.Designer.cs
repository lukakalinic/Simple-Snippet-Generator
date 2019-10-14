using ScintillaNET;

namespace SimpleSnippetGenerator
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.insertHereLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.expansionSnippetRadioButton = new System.Windows.Forms.RadioButton();
            this.surroundWithRadioButton = new System.Windows.Forms.RadioButton();
            this.snippetTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.snippetDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.scintillaBox = new ScintillaNET.Scintilla();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.lineNumberCheckBox = new System.Windows.Forms.CheckBox();
            this.fontLabel = new System.Windows.Forms.Label();
            this.fontSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.snippetTypeGroupBox.SuspendLayout();
            this.snippetDetailsGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // insertHereLabel
            // 
            this.insertHereLabel.AutoSize = true;
            this.insertHereLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertHereLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.insertHereLabel.Location = new System.Drawing.Point(12, 9);
            this.insertHereLabel.Name = "insertHereLabel";
            this.insertHereLabel.Size = new System.Drawing.Size(157, 20);
            this.insertHereLabel.TabIndex = 1;
            this.insertHereLabel.Text = "Insert querry here:";
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.saveButton.Location = new System.Drawing.Point(505, 398);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(107, 31);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.Transparent;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.resetButton.Location = new System.Drawing.Point(432, 398);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(67, 31);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // expansionSnippetRadioButton
            // 
            this.expansionSnippetRadioButton.AutoSize = true;
            this.expansionSnippetRadioButton.Checked = true;
            this.expansionSnippetRadioButton.Location = new System.Drawing.Point(6, 19);
            this.expansionSnippetRadioButton.Name = "expansionSnippetRadioButton";
            this.expansionSnippetRadioButton.Size = new System.Drawing.Size(74, 17);
            this.expansionSnippetRadioButton.TabIndex = 4;
            this.expansionSnippetRadioButton.TabStop = true;
            this.expansionSnippetRadioButton.Text = "Expansion";
            this.expansionSnippetRadioButton.UseVisualStyleBackColor = true;
            // 
            // surroundWithRadioButton
            // 
            this.surroundWithRadioButton.AutoSize = true;
            this.surroundWithRadioButton.Location = new System.Drawing.Point(6, 42);
            this.surroundWithRadioButton.Name = "surroundWithRadioButton";
            this.surroundWithRadioButton.Size = new System.Drawing.Size(95, 17);
            this.surroundWithRadioButton.TabIndex = 5;
            this.surroundWithRadioButton.Text = "SurroundsWith";
            this.surroundWithRadioButton.UseVisualStyleBackColor = true;
            // 
            // snippetTypeGroupBox
            // 
            this.snippetTypeGroupBox.Controls.Add(this.expansionSnippetRadioButton);
            this.snippetTypeGroupBox.Controls.Add(this.surroundWithRadioButton);
            this.snippetTypeGroupBox.Location = new System.Drawing.Point(432, 101);
            this.snippetTypeGroupBox.Name = "snippetTypeGroupBox";
            this.snippetTypeGroupBox.Size = new System.Drawing.Size(180, 70);
            this.snippetTypeGroupBox.TabIndex = 8;
            this.snippetTypeGroupBox.TabStop = false;
            this.snippetTypeGroupBox.Text = "Snippet Type:";
            // 
            // snippetDetailsGroupBox
            // 
            this.snippetDetailsGroupBox.Controls.Add(this.authorTextBox);
            this.snippetDetailsGroupBox.Controls.Add(this.label1);
            this.snippetDetailsGroupBox.Controls.Add(this.descriptionRichTextBox);
            this.snippetDetailsGroupBox.Controls.Add(this.descriptionLabel);
            this.snippetDetailsGroupBox.Controls.Add(this.titleTextBox);
            this.snippetDetailsGroupBox.Controls.Add(this.titleLabel);
            this.snippetDetailsGroupBox.Location = new System.Drawing.Point(432, 177);
            this.snippetDetailsGroupBox.Name = "snippetDetailsGroupBox";
            this.snippetDetailsGroupBox.Size = new System.Drawing.Size(180, 215);
            this.snippetDetailsGroupBox.TabIndex = 9;
            this.snippetDetailsGroupBox.TabStop = false;
            this.snippetDetailsGroupBox.Text = "Snippet Details:";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(10, 170);
            this.authorTextBox.MaxLength = 50;
            this.authorTextBox.Multiline = true;
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(160, 35);
            this.authorTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author";
            // 
            // descriptionRichTextBox
            // 
            this.descriptionRichTextBox.Location = new System.Drawing.Point(10, 91);
            this.descriptionRichTextBox.MaxLength = 150;
            this.descriptionRichTextBox.Name = "descriptionRichTextBox";
            this.descriptionRichTextBox.Size = new System.Drawing.Size(160, 62);
            this.descriptionRichTextBox.TabIndex = 3;
            this.descriptionRichTextBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(7, 75);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 2;
            this.descriptionLabel.Text = "Description";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(10, 37);
            this.titleTextBox.MaxLength = 50;
            this.titleTextBox.Multiline = true;
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(160, 35);
            this.titleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(7, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(27, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // scintillaBox
            // 
            this.scintillaBox.Location = new System.Drawing.Point(13, 33);
            this.scintillaBox.Margin = new System.Windows.Forms.Padding(0);
            this.scintillaBox.Name = "scintillaBox";
            this.scintillaBox.ScrollWidth = 1;
            this.scintillaBox.Size = new System.Drawing.Size(410, 396);
            this.scintillaBox.TabIndex = 10;
            this.scintillaBox.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.scintillaBox_UpdateUI);
            this.scintillaBox.TextChanged += new System.EventHandler(this.scintillaBox_TextChanged);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Controls.Add(this.lineNumberCheckBox);
            this.optionsGroupBox.Controls.Add(this.fontLabel);
            this.optionsGroupBox.Controls.Add(this.fontSizeNumericUpDown);
            this.optionsGroupBox.Location = new System.Drawing.Point(432, 33);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(180, 62);
            this.optionsGroupBox.TabIndex = 11;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // lineNumberCheckBox
            // 
            this.lineNumberCheckBox.AutoSize = true;
            this.lineNumberCheckBox.Location = new System.Drawing.Point(88, 33);
            this.lineNumberCheckBox.Name = "lineNumberCheckBox";
            this.lineNumberCheckBox.Size = new System.Drawing.Size(86, 17);
            this.lineNumberCheckBox.TabIndex = 14;
            this.lineNumberCheckBox.Text = "Line Number";
            this.lineNumberCheckBox.UseVisualStyleBackColor = true;
            this.lineNumberCheckBox.CheckedChanged += new System.EventHandler(this.lineNumberCheckBox_CheckedChanged);
            // 
            // fontLabel
            // 
            this.fontLabel.AutoSize = true;
            this.fontLabel.Location = new System.Drawing.Point(7, 16);
            this.fontLabel.Name = "fontLabel";
            this.fontLabel.Size = new System.Drawing.Size(49, 13);
            this.fontLabel.TabIndex = 13;
            this.fontLabel.Text = "Font size";
            // 
            // fontSizeNumericUpDown
            // 
            this.fontSizeNumericUpDown.Location = new System.Drawing.Point(10, 32);
            this.fontSizeNumericUpDown.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.Name = "fontSizeNumericUpDown";
            this.fontSizeNumericUpDown.Size = new System.Drawing.Size(67, 20);
            this.fontSizeNumericUpDown.TabIndex = 12;
            this.fontSizeNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSizeNumericUpDown.ValueChanged += new System.EventHandler(this.fontSizeNumericUpDown_ValueChanged);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.scintillaBox);
            this.Controls.Add(this.snippetDetailsGroupBox);
            this.Controls.Add(this.snippetTypeGroupBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.insertHereLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple snippet creator for SQLServer";
            this.Load += new System.EventHandler(this.Form_Load);
            this.snippetTypeGroupBox.ResumeLayout(false);
            this.snippetTypeGroupBox.PerformLayout();
            this.snippetDetailsGroupBox.ResumeLayout(false);
            this.snippetDetailsGroupBox.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label insertHereLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.RadioButton expansionSnippetRadioButton;
        private System.Windows.Forms.RadioButton surroundWithRadioButton;
        private System.Windows.Forms.GroupBox snippetTypeGroupBox;
        private System.Windows.Forms.GroupBox snippetDetailsGroupBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox descriptionRichTextBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private ScintillaNET.Scintilla scintillaBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.CheckBox lineNumberCheckBox;
        private System.Windows.Forms.Label fontLabel;
        private System.Windows.Forms.NumericUpDown fontSizeNumericUpDown;
    }
}

