namespace Encrypt
{
    partial class Form1
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
            this.searchbut = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.startbut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Encryptradio = new System.Windows.Forms.RadioButton();
            this.Decryptradio = new System.Windows.Forms.RadioButton();
            this.cancelbut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.seedtextbox = new System.Windows.Forms.TextBox();
            this.genbut = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchbut
            // 
            this.searchbut.Location = new System.Drawing.Point(54, 111);
            this.searchbut.Name = "searchbut";
            this.searchbut.Size = new System.Drawing.Size(91, 32);
            this.searchbut.TabIndex = 0;
            this.searchbut.Text = "Search";
            this.searchbut.UseVisualStyleBackColor = true;
            this.searchbut.Click += new System.EventHandler(this.searchbut_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // startbut
            // 
            this.startbut.Location = new System.Drawing.Point(201, 111);
            this.startbut.Name = "startbut";
            this.startbut.Size = new System.Drawing.Size(90, 32);
            this.startbut.TabIndex = 2;
            this.startbut.Text = "Start";
            this.startbut.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Encryptradio);
            this.groupBox1.Controls.Add(this.Decryptradio);
            this.groupBox1.Location = new System.Drawing.Point(17, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 101);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // Encryptradio
            // 
            this.Encryptradio.AutoSize = true;
            this.Encryptradio.Checked = true;
            this.Encryptradio.Location = new System.Drawing.Point(30, 78);
            this.Encryptradio.Name = "Encryptradio";
            this.Encryptradio.Size = new System.Drawing.Size(61, 17);
            this.Encryptradio.TabIndex = 1;
            this.Encryptradio.TabStop = true;
            this.Encryptradio.Text = "Encrypt";
            this.Encryptradio.UseVisualStyleBackColor = true;
            // 
            // Decryptradio
            // 
            this.Decryptradio.AutoSize = true;
            this.Decryptradio.Location = new System.Drawing.Point(30, 32);
            this.Decryptradio.Name = "Decryptradio";
            this.Decryptradio.Size = new System.Drawing.Size(62, 17);
            this.Decryptradio.TabIndex = 0;
            this.Decryptradio.Text = "Decrypt";
            this.Decryptradio.UseVisualStyleBackColor = true;
            // 
            // cancelbut
            // 
            this.cancelbut.Location = new System.Drawing.Point(342, 111);
            this.cancelbut.Name = "cancelbut";
            this.cancelbut.Size = new System.Drawing.Size(100, 32);
            this.cancelbut.TabIndex = 4;
            this.cancelbut.Text = "Cancel";
            this.cancelbut.UseVisualStyleBackColor = true;
            this.cancelbut.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Генератор ключа шифрования";
            // 
            // seedtextbox
            // 
            this.seedtextbox.Location = new System.Drawing.Point(236, 225);
            this.seedtextbox.Name = "seedtextbox";
            this.seedtextbox.Size = new System.Drawing.Size(158, 20);
            this.seedtextbox.TabIndex = 6;
            // 
            // genbut
            // 
            this.genbut.Location = new System.Drawing.Point(263, 251);
            this.genbut.Name = "genbut";
            this.genbut.Size = new System.Drawing.Size(96, 33);
            this.genbut.TabIndex = 7;
            this.genbut.Text = "Generate";
            this.genbut.UseVisualStyleBackColor = true;
            this.genbut.Click += new System.EventHandler(this.genbut_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(683, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.genbut);
            this.Controls.Add(this.seedtextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelbut);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.startbut);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.searchbut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchbut;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button startbut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Encryptradio;
        private System.Windows.Forms.RadioButton Decryptradio;
        private System.Windows.Forms.Button cancelbut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox seedtextbox;
        private System.Windows.Forms.Button genbut;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
    }
}

