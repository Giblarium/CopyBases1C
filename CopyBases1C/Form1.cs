using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CopyBases1C
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //начальное заполнение полей
            textBox_BasesList.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"1C\1CEStart\ibases.v8i");
            string dateStr = GetDate();

            if (File.Exists("CopyBases1C.config")) //считать путь копий из файла, если он существует
            {
                textBox_FolderCopy.Text = File.ReadAllText("CopyBases1C.config") + dateStr;
            }
            else //иначе путь по умолчинию
            {
                textBox_FolderCopy.Text = @"D:\BIT\Archive\" + dateStr;
            }

            //начальное заполнение списка
            ReadBasesList();
            label_Version.Text = Application.ProductVersion.ToString();
        }

        private static string GetDate() //получение строки даты в формате YYYYMMDD
        {
            DateTime date = DateTime.Now;
            string dateStr = date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2");
            return dateStr;
        }

        /// <summary>
        /// статусы базы
        /// </summary>
        public enum BasesStatus
        {
            OK, // можно копировать
            NotFound, // файл не найден
            Server //серверная версия БД

        }

        /// <summary>
        /// описание класса базы
        /// </summary>
        public class Bases
        {
            public string name; 
            public string path; // путь к файлу БД
            public BasesStatus copied; //копируемая база?
        }



        #region Список баз
        private List<Bases> listBase = new List<Bases>();

        private void button_ReadBasesList_Click(object sender, EventArgs e)
        {
            ReadBasesList();
        }

        private void ReadBasesList()
        {
            if (!File.Exists(textBox_BasesList.Text)) //проверка наличия файла списка
            {
                textBox_debug.Text = "Файл списка баз не найден!";
                return;
            }

            StreamReader sr_BasesList = new StreamReader(textBox_BasesList.Text); //чтение файла списка

            //очистка листбокса и списка
            listBox_Bases.Items.Clear();
            listBase.Clear();

            string namebase, pathbase, copiedbase = "";

            //парсинг файла списка
            while (!sr_BasesList.EndOfStream)
            {
                string str = sr_BasesList.ReadLine();
                //заполнение списка
                if (str[0] == '[') //если строка начинается с [, то в ней содержится название базы
                {
                    str = str.Remove(0, 1);
                    str = str.Remove(str.Length - 1, 1);
                    namebase = str;

                    str = sr_BasesList.ReadLine();
                    if (str[0] == '[') continue;

                    if (str.Contains("Connect=")) //если строка содержит "Connect=", то в ней содержится путь к базе
                    {
                        if (str.Contains("File")) //если строка содержит "File", то база файловая и ее можно копировать
                        {
                            //обработка пути к файлу БД
                            str = str.Remove(0, 14);
                            str = str.Remove(str.Length - 2, 2);
                            pathbase = str;
                            if (File.Exists(Path.Combine(pathbase, "1cv8.1cd"))) //файл существует, можно копировать
                            {
                                listBase.Add(new Bases { name = namebase, path = pathbase, copied = BasesStatus.OK });
                            }
                            else //файла не существует
                            {
                                listBase.Add(new Bases { name = namebase, path = "", copied = BasesStatus.NotFound });
                            }
                        }
                        else //если строка с "Connect=" не содержит "File", то база клиент-серверная или веб-Серверная. База не копируется
                        {
                            listBase.Add(new Bases { name = namebase, path = "", copied = BasesStatus.Server });
                        }
                    }
                }
            }
            //закрыть файл списка баз
            sr_BasesList.Close();

            //Заполнение листбокса
            foreach (Bases bases in listBase)
            {
                switch (bases.copied)
                {
                    case BasesStatus.OK:
                        copiedbase = "";
                        break;
                    case BasesStatus.NotFound:
                        copiedbase = "[Файл БД не найден] ";
                        break;
                    case BasesStatus.Server:
                        copiedbase = "[Серверная БД] ";
                        break;
                    default:
                        break;
                }
                listBox_Bases.Items.Add(copiedbase + bases.name);
            }

        }

        #endregion


        #region Копирование баз

        /// <summary>
        /// обработчик нажатия кнопки "Скопировать базы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CopyBases_Click(object sender, EventArgs e)
        {
            if (listBox_Bases.SelectedIndices.Count == 0)
            {
                textBox_debug.Text = "Не выбраны базы!";
                return; //если выбрано 0 элементов в листбоксе, прервать метод
            }
            if (!Directory.Exists(textBox_FolderCopy.Text)) //создать папку с копиями, если ее нет
            {
                Directory.CreateDirectory(textBox_FolderCopy.Text);
                textBox_debug.AppendText("Создана папка:" + textBox_FolderCopy.Text + "\r\n");
            }
            for (int i = 0; i < listBox_Bases.Items.Count; i++) //перебор элементов листбокса
            {
                if (listBox_Bases.GetSelected(i)) //если элемент выбран, то проходит копирование
                {
                    //listBase[i].check = true; 
                    CopyBases(listBase[i].name, listBase[i].path, listBase[i].copied); //непосредственно - копирование файлов БД
                }
            }
            if (checkBox_OpenFolder.Checked)
            {
                OpenFolderCopy(); //Если отмечено, то открывается папка с копиями после окончания копирования
            }
        }
        /// <summary>
        /// копирование файла БД
        /// </summary>
        /// <param name="name">имя базы данных и название копии</param>
        /// <param name="path">путь к папке с копиями</param>
        private void CopyBases(string name, string path, BasesStatus status)
        {
            //обработка путей и названий БД
            string sourceFile = Path.Combine(path, "1Cv8.1CD");
            name = Regex.Replace(name, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            string copyFile = Path.Combine(textBox_FolderCopy.Text, name + ".1cd");
            //string debugText = "";

            if (status == BasesStatus.NotFound)
            {
                textBox_debug.AppendText("База " + name + " не скопирована, т.к. файл базы данных не найден.\r\n");
                return; //Прервать метод, если файл БД не нейден.
            }
            else if (status == BasesStatus.Server)
            {
                textBox_debug.AppendText("База " + name + " не скопирована, т.к. база серверная.\r\n");
                return; //Прервать метод, если база не файловая.
            }


            if (File.Exists(copyFile)) //если файл копии существует, то согласно настройке
            {
                if (radioButton_NotCopy.Checked) //не копируется
                {
                    textBox_debug.AppendText("База " + name + " не скопирована, т.к. файл уже существует.\r\n");
                    return;
                }
                else if (radioButton_Replace.Checked) //копируется с заменой
                {
                    File.Copy(sourceFile, copyFile, true);
                    textBox_debug.AppendText("База " + name + " скопирована, файл заменен.\r\n");
                }
                else if (radioButton_SaveBoth.Checked) //сохраняется второй файл с датой и временем копии в названии
                {
                    DateTime dateTime = DateTime.Now;
                    string strDateTime = dateTime.Year.ToString("D4") + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") +
                        dateTime.Hour.ToString("D2") + dateTime.Minute.ToString("D2") + dateTime.Second.ToString("D2");
                    copyFile = Path.Combine(textBox_FolderCopy.Text, name + strDateTime + ".1cd");
                    File.Copy(sourceFile, copyFile);
                    textBox_debug.AppendText("База " + name + " скопирована, обе копии сохранены.\r\n");
                }
            }
            else //если файла копии еще нет, то просто создается копия.
            {
                File.Copy(sourceFile, copyFile);
                textBox_debug.AppendText("База " + name + " скопирована.\r\n");
            }
        }
        #endregion

        #region Работа с папкой
        /// <summary>
        /// обработчик нажатия кнопки "Открытие папки"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolderCopy();
        }
        /// <summary>
        /// открытие папки с копиями
        /// </summary>
        private void OpenFolderCopy()
        {
            if (Directory.Exists(textBox_FolderCopy.Text))
            {
                System.Diagnostics.Process.Start("explorer.exe", textBox_FolderCopy.Text);
            }
            else
            {
                textBox_debug.Text = "Папки копий не существует";
            }
        }

        /// <summary>
        /// обработчки нажатия кнопки "...". Выбор папки с копиями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SelectFolderCopy_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox_FolderCopy.Text = FBD.SelectedPath;
                textBox_FolderCopy.Text += @"\" + GetDate(); //добавление даты в путь копий
                SafePath();
            }

        }
        /// <summary>
        /// обработчик нажатия кнопки "...". Выбор файла списка БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SelectBasesList_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog
            {
                Filter = "Файлы списка баз данных 1С|*.v8i"
            };
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                textBox_BasesList.Text = OPF.FileName;
                
            }
            
        }

        /// <summary>
        /// запись в файл последнего пути копирования при его изменении
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_FolderCopy_Leave(object sender, EventArgs e)
        {
            SafePath();
        }

        private void SafePath()
        {
            string str = textBox_FolderCopy.Text.Replace(GetDate(), "");
            File.WriteAllText("CopyBases1C.config", str);
        }
        #endregion

        #region Фичи
        /// <summary>
        /// обработчик нажатия ссылки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
        #endregion

    }
}
