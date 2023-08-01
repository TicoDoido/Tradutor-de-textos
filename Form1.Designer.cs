namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLoadFile = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            buttonTranslate = new Button();
            groupBox1 = new GroupBox();
            buttonEdit = new Button();
            buttonSave = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonLoadFile
            // 
            buttonLoadFile.Font = new Font("Segoe Script", 14F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoadFile.Location = new Point(17, 20);
            buttonLoadFile.Margin = new Padding(4, 5, 4, 5);
            buttonLoadFile.Name = "buttonLoadFile";
            buttonLoadFile.Size = new Size(226, 168);
            buttonLoadFile.TabIndex = 0;
            buttonLoadFile.Text = "Selecionar Arquivo .txt";
            buttonLoadFile.UseVisualStyleBackColor = true;
            buttonLoadFile.Click += buttonLoadFile_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox1.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.Location = new Point(269, 20);
            richTextBox1.Margin = new Padding(4, 5, 4, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(505, 611);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            richTextBox2.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox2.Location = new Point(790, 20);
            richTextBox2.Margin = new Padding(4, 5, 4, 5);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(505, 611);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // buttonTranslate
            // 
            buttonTranslate.Font = new Font("Segoe Script", 16F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTranslate.Location = new Point(17, 213);
            buttonTranslate.Margin = new Padding(4, 5, 4, 5);
            buttonTranslate.Name = "buttonTranslate";
            buttonTranslate.Size = new Size(226, 175);
            buttonTranslate.TabIndex = 3;
            buttonTranslate.Text = "Traduzir texto";
            buttonTranslate.UseVisualStyleBackColor = true;
            buttonTranslate.Click += buttonTranslate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonEdit);
            groupBox1.Controls.Add(buttonSave);
            groupBox1.Location = new Point(17, 413);
            groupBox1.Margin = new Padding(4, 5, 4, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 5, 4, 5);
            groupBox1.Size = new Size(226, 187);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "OPÇÕES DO TEXTO TRADUZIDO";
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe Script", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEdit.Location = new Point(9, 47);
            buttonEdit.Margin = new Padding(4, 5, 4, 5);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(209, 60);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe Script", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.Location = new Point(9, 117);
            buttonSave.Margin = new Padding(4, 5, 4, 5);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(209, 60);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "SALVAR";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1314, 750);
            Controls.Add(groupBox1);
            Controls.Add(buttonTranslate);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(buttonLoadFile);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button buttonLoadFile;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button buttonTranslate;
        private GroupBox groupBox1;
        private Button buttonSave;
        private Button buttonEdit;
    }
}