using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt
{
    public partial class Form1 : Form
    {
        private Enigma en;
        public Form1()
        {
            InitializeComponent();
            this.cancelbut.Enabled = false;
            //начальный ключ всегда "orxan@",смотри значение поля в классе
            seedtextbox.Text = "orxan@";
            startbut.Click += startbut_ClickAsync;
        }



        private async void startbut_ClickAsync(object sender, EventArgs e)
        {
            startbut.Enabled = false;
            searchbut.Enabled = false;
            cancelbut.Enabled = true;
            this.en = new Enigma();
            
            en.TaskComplete += Task_Complite;
            en.WorkProgress += WorkProgress;

            //Забираем ключ из окошка
            en.Seed = seedtextbox.Text;
           
            if (Encryptradio.Checked)
            {
                //Асинхроный вызов метода.
                //await Task.Run(() => en.EncryptAsync(textBox1.Text));
                await en.EncryptAsync(textBox1.Text);
               
            }
            else
            {
                //Асинхроный вызов метода.
                //await Task.Run(() => en.DecryptAsync(textBox1.Text));
                await en.DecryptAsync(textBox1.Text);
            }

        }

        private void WorkProgress(int perc)
        {
            Action action = () =>
            {
                if(progressBar1.Value<perc)
                progressBar1.Value =perc;
                label2.Text = $"Progress {progressBar1.Value} %";

            };
            Invoke(action);
        }

        /// <summary>
        /// Отчет о выполнении.
        /// </summary>
        /// <param name="cancel"></param>
        private void Task_Complite(bool cancel)
        {
           
            Action action=() =>{
                string message = cancel ? "Процесс отменен" : "Процесс Завершен ";
                MessageBox.Show(message);
                startbut.Enabled = true;
                searchbut.Enabled = true;
                progressBar1.Value = 0;
                label2.Text = "";
            };
            Invoke(action);
        }

        private void searchbut_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                this.textBox1.Text = openFileDialog1.SafeFileName;
        }

        /// <summary>
        /// Отмена процесса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            en.Cancel();
            cancelbut.Enabled = false;
        }

        /// <summary>
        /// Генератор 6 значного ключа для шифрования.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void genbut_Click(object sender, EventArgs e)
        {
            StringBuilder seed = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                int a = rand.Next(33, 125);
                seed.Append((char)a);
            }
            this.seedtextbox.Text = seed.ToString();
        }
    }
}
