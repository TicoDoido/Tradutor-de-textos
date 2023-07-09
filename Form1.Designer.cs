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
            buttonLoadFile.Location = new Point(12, 12);
            buttonLoadFile.Name = "buttonLoadFile";
            buttonLoadFile.Size = new Size(158, 101);
            buttonLoadFile.TabIndex = 0;
            buttonLoadFile.Text = "Selecionar Arquivo .txt";
            buttonLoadFile.UseVisualStyleBackColor = true;
            buttonLoadFile.Click += buttonLoadFile_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox1.Location = new Point(188, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(355, 368);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            richTextBox2.Location = new Point(553, 12);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(355, 368);
            richTextBox2.TabIndex = 2;
            richTextBox2.Text = "";
            // 
            // buttonTranslate
            // 
            buttonTranslate.Font = new Font("Segoe Script", 16F, FontStyle.Bold, GraphicsUnit.Point);
            buttonTranslate.Location = new Point(12, 128);
            buttonTranslate.Name = "buttonTranslate";
            buttonTranslate.Size = new Size(158, 105);
            buttonTranslate.TabIndex = 3;
            buttonTranslate.Text = "Traduzir texto";
            buttonTranslate.UseVisualStyleBackColor = true;
            buttonTranslate.Click += buttonTranslate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonEdit);
            groupBox1.Controls.Add(buttonSave);
            groupBox1.Location = new Point(12, 248);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(158, 112);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "OPÇÕES DO TEXTO TRADUZIDO";
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Segoe Script", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEdit.Location = new Point(6, 28);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(146, 36);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "EDITAR";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Segoe Script", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.Location = new Point(6, 70);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(146, 36);
            buttonSave.TabIndex = 0;
            buttonSave.Text = "SALVAR";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 450);
            Controls.Add(groupBox1);
            Controls.Add(buttonTranslate);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(buttonLoadFile);
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