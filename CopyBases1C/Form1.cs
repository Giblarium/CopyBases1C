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
            textBox_BasesList.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                @"1C\1CEStart\ibases.v8i"); //todo автовыбор appdata
            string dateStr = GetData();
            if (File.Exists("CopyBases1C.config"))
            {
                textBox_FolderCopy.Text = File.ReadAllText("CopyBases1C.config") + dateStr;
            }
            else
            {
                textBox_FolderCopy.Text = @"D:\BIT\Archive\" + dateStr;
            }
            ReadBasesList();
        }

        private static string GetData()
        {
            DateTime date = DateTime.Now;
            string dateStr = date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2");
            return dateStr;
        }

        public class Bases
        {
            public string name;
            public string path;
            public bool check;
        }

        #region Список баз
        List<Bases> listBase = new List<Bases>();

        private void button_ReadBasesList_Click(object sender, EventArgs e)
        {
            ReadBasesList();
        }

        private void ReadBasesList()
        {
            if (!File.Exists(textBox_BasesList.Text))
            {
                textBox_debug.Text = "Файл списка баз не найден!";
                return;
            }
            StreamReader sr_BasesList = new StreamReader(textBox_BasesList.Text);

            listBox_Bases.Items.Clear();
            listBase.Clear();

            string namebase = "", pathbase = "";

            while (!sr_BasesList.EndOfStream)
            {
                string str = sr_BasesList.ReadLine();
                if (str[0] == '[')
                {
                    str = str.Remove(0, 1);
                    str = str.Remove(str.Length - 1, 1);
                    namebase = str;
                    listBox_Bases.Items.Add(str);
                }
                if (str.Contains("Connect="))
                {
                    if (str.Contains("File"))
                    {
                        str = str.Remove(0, 14);
                        str = str.Remove(str.Length - 2, 2);
                        pathbase = str;
                        if (File.Exists(Path.Combine(pathbase, "1cv8.1cd")))
                        {
                            listBase.Add(new Bases { name = namebase, path = pathbase });
                        }
                        else
                        {
                            RenameListBases(namebase, "[Файл не найден] ");
                            listBase.Add(new Bases { name = namebase, path = "" });
                        }
                    }
                    else
                    {
                        RenameListBases(namebase, "[серверная база] ");
                        listBase.Add(new Bases { name = namebase, path = "" });
                    }
                }
            }
            sr_BasesList.Close();
        }

        private void RenameListBases(string namebase, string param)
        {
            listBox_Bases.Items.Remove(namebase);
            listBox_Bases.Items.Add(param + namebase);
        }

        #endregion
        #region Копирование баз

        private void button_CopyBases_Click(object sender, EventArgs e)
        {
            if (listBox_Bases.SelectedIndices.Count == 0)
            {
                textBox_debug.Text = "Не выбраны базы!";
                return;
            }
            for (int i = 0; i < listBox_Bases.Items.Count; i++)
            {
                if (listBox_Bases.GetSelected(i))
                {
                    listBase[i].check = true;
                    CopyBases(listBase[i].name, listBase[i].path);
                }
            }
            if (checkBox_OpenFolder.Checked)
            {
                OpenFolderCopy();
            }
        }

        private void CopyBases(string name, string path)
        {
            string sourceFile = Path.Combine(path, "1Cv8.1CD");
            name = Regex.Replace(name, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            string copyFile = Path.Combine(textBox_FolderCopy.Text, name + ".1cd");
            string debugText = "";

            if (!File.Exists(sourceFile))
            {
                textBox_debug.AppendText("База " + name + " не скопирована, т.к. файл базы данных не найден.\r\n");
                return;
            }

            if (!Directory.Exists(textBox_FolderCopy.Text))
            {
                Directory.CreateDirectory(textBox_FolderCopy.Text);
                textBox_debug.AppendText("Создана папка:" + textBox_FolderCopy.Text + "\r\n");
            }

            if (File.Exists(copyFile))
            {
                if (radioButton_NotCopy.Checked)
                {
                    textBox_debug.AppendText("База " + name + " не скопирована, т.к. файл уже существует.\r\n");
                    return;
                }
                else if (radioButton_Replace.Checked)
                {
                    File.Copy(sourceFile, copyFile, true);
                    textBox_debug.AppendText("База " + name + " скопирована, файл заменен.\r\n");
                }
                else if (radioButton_SaveBoth.Checked)
                {
                    DateTime dateTime = DateTime.Now;
                    string strDateTime = dateTime.Year.ToString("D4") + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") +
                        dateTime.Hour.ToString("D2") + dateTime.Minute.ToString("D2") + dateTime.Second.ToString("D2");
                    copyFile = Path.Combine(textBox_FolderCopy.Text, name + strDateTime + ".1cd");
                    File.Copy(sourceFile, copyFile);
                    textBox_debug.AppendText("База " + name + " скопирована, обе копии сохранены.\r\n");
                }
            }
            else
            {
                File.Copy(sourceFile, copyFile);
                textBox_debug.AppendText("База " + name + " скопирована.\r\n");
            }
        }
        #endregion

        #region Работа с папкой

        private void button_OpenFolder_Click(object sender, EventArgs e)
        {
            OpenFolderCopy();
        }

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


        private void button_SelectFolderCopy_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox_FolderCopy.Text = FBD.SelectedPath;
                textBox_FolderCopy.Text += @"\" + GetData();
            }
        }

        private void button_SelectBasesList_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы списка баз данных 1С|*.v8i";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                textBox_BasesList.Text = OPF.FileName;
            }
        }

        private void textBox_FolderCopy_Leave(object sender, EventArgs e)
        {
            string str = textBox_FolderCopy.Text.Replace(GetData(), "");
            File.WriteAllText("CopyBases1C.config", str);
        }
        #endregion

        #region Фичи

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
        #endregion

    }
}
