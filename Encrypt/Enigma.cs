using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt
{
    public class Enigma
    {
        //Поля класса.
        #region
        private readonly int blocksize = 40;

        //Поле подсчета байтов в случае отмены операции
        //private long _bytecount { get; set; } = 1;

        private byte[] _seed { get; set; } = Encoding.UTF8.GetBytes("orxan@");
       public string Seed {
                            get { return Encoding.UTF8.GetString(_seed); }
                            set { _seed = Encoding.UTF8.GetBytes(value); }
                           }
       private bool _cancel = false;

        #endregion

        //Делегат отчет о завершении работы
        public Action<bool> TaskComplete;
        public Action<int> WorkProgress;


        public void Cancel()
        {
            this._cancel = true;
        }
        /// <summary>
        /// Востановление файла ,после прерывания операции по шифровке/дешифровке
        /// </summary>
        /// <param name="path"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private async Task RestoreFileAsync(string path,int count)
        {
           
            #region
            //буфер под размер "испорченых" байтов.
            byte[] buff = new byte[count];
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                
                //Используем асинхороное считывание байтов ,раз уж метод в целом это позволяет.
               int t= await fs.ReadAsync(buff, 0, count);
           
                //В цикле востанавливаем исходное значение.т.к ключ не изменился то и мы не чешемся (оказалось чещемся потом )
                for (int i = 0; i < count; i++)
                    buff[i] ^= _seed[i % _seed.Length];

                //Возращаемся в начало файла.
                fs.Seek(0, SeekOrigin.Begin);

                //Пишем в файл новые значения взамен старых.
                await fs.WriteAsync(buff, 0,t);
           };
            #endregion
            
        }

        /// <summary>
        /// Заксоривание байтов. 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task XorStream(string path)
        {

            //Переменая нужна для подсчета байтов,использую лонг т.к инта нехватит с запасом.
            //Поле не использовал т.к проще работать с локальными перемеными внутри метода ,возможно я не прав \_(- -)_/
            int bytecount = 0;
            int len = 0;
            byte[] buff = new byte[blocksize];
            FileInfo file = new FileInfo(path);
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {

                // в цикле получаем блок данных.
                while ((len = await fs.ReadAsync(buff, 0, blocksize)) > 0)
                {
                    //смотрим была ли отмена. Если была отмена ,то востанавливаем файл в исходное состояние.
                    if (_cancel) { break; }

                    //Кодируем через XOR.
                    for (int i = 0; i < len; i++)
                        buff[i] ^= _seed[(bytecount + i) % _seed.Length];

                    //Смешаем курсор от текущей позиции.
                    fs.Seek(-len, SeekOrigin.Current);

                    //Пищем новый блок затирая старый.
                    await fs.WriteAsync(buff, 0, len);

                    //если вошли в цикл то прибавляем считаное количество к итоговому
                    bytecount += len;

                    //Расчет прогресса в % считаные байты от общего числа
                    //long perc = (file.Length / 100) * bytecount;
                    //Прогресс вычисляем один процент
                    int perc = bytecount*100/(int)file.Length;
                    //MessageBox.Show(perc.ToString());
                    
                    WorkProgress(perc);
                    
                }

            };
            //Проверяем после закрытия потока,если операция была прерванна,то востанавливаем файл в исходное состоянии
            if (_cancel) await RestoreFileAsync(path, bytecount);
            MessageBox.Show("Считанно " + bytecount);
            TaskComplete(_cancel);
        }

        /// <summary>
        /// Шифровка
        /// </summary>
        /// <param name="path"></param>
        /// <param name="blocksize"></param>
        /// <returns></returns>
        public async Task EncryptAsync(string path)
        {
            await XorStream(path);
        }


        /// <summary>
        /// Расшифровка файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task DecryptAsync(string path)
        {
            await XorStream(path);
        }
    }
}
