using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CopyBases1C
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            textBox_BasesList.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"1C\1CEStart\ibases.v8i"); //todo автовыбор appdata
            DateTime date = DateTime.Now;
            string dateStr = date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2");
            textBox_FolderCopy.Text = @"D:\BIT\Archive\" + dateStr;
            //button_ReadBasesList_Click();


            

        }

        public class Bases
        {
            public string name;
            public string path;
            public bool check;
        }

        List<Bases> listBase = new List<Bases>();

        private void button_ReadBasesList_Click(object sender, EventArgs e)
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
                        listBase.Add(new Bases { name = namebase, path = pathbase });
                    }
                    else
                    {
                        listBox_Bases.Items.Remove(namebase);
                        listBox_Bases.Items.Add("[серверная база] " + namebase);
                        listBase.Add(new Bases { name = namebase, path = pathbase });
                    }

                }
                
            }
        }

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


        }

        private void CopyBases(string name, string path)
        {
            string sourceFile = Path.Combine(path, "1Cv8.1CD");
            string copyFile = Path.Combine(textBox_FolderCopy.Text, name + ".1cd");
            string debugText = "";

            if (!File.Exists(sourceFile))
            {
                debugText += "База " + name + " не скопирована, т.к. файл базы данных не найден.\n";
                return;
            }

            if (!Directory.Exists(textBox_FolderCopy.Text))
            {
                Directory.CreateDirectory(textBox_FolderCopy.Text);
                debugText = "Создана папка:" + textBox_FolderCopy.Text + "\n";

            }
            if (File.Exists(copyFile))
            {
                if (radioButton_NotCopy.Checked)
                {
                    debugText += "База " + name + " не скопирована, т.к. файл уже существует.\n";
                    return;
                }
                else if (radioButton_Replace.Checked)
                {
                    File.Copy(sourceFile, copyFile, true);
                    debugText += "База " + name + " скопирована, файл заменен.\n";
                }
                else if (radioButton_SaveBoth.Checked)
                {
                    DateTime dateTime = DateTime.Now;
                    string strDateTime = dateTime.Year.ToString("D4") + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") +
                        dateTime.Hour.ToString("D2") + dateTime.Minute.ToString("D2") + dateTime.Second.ToString("D2");
                    copyFile = Path.Combine(textBox_FolderCopy.Text, name + strDateTime + ".1cd");
                    File.Copy(sourceFile, copyFile);
                    debugText += "База " + name + " скопирована, обе копии сохранинены.\n";


                }
            }
            else
            {
                File.Copy(sourceFile, copyFile);
                debugText += "База " + name + " скопирована.\n";
            }
            textBox_debug.Text = debugText;

            //throw new NotImplementedException();
        }

        private void button_OpenFolder_Click(object sender, EventArgs e)
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
    }
}
