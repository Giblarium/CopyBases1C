using System.Text.RegularExpressions;

namespace CopyBases1C;

public partial class Form1 : Form
{

    public Form1()
    {
        InitializeComponent();

        //��������� ���������� �����
        textBox_BasesList.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            @"1C\1CEStart\ibases.v8i");
        string dateStr = GetDate();

        if (File.Exists("CopyBases1C.config")) //������� ���� ����� �� �����, ���� �� ����������
        {
            textBox_FolderCopy.Text = File.ReadAllText("CopyBases1C.config") + dateStr;
        }
        else //����� ���� �� ���������
        {
            textBox_FolderCopy.Text = @"D:\BIT\Archive\" + dateStr;
        }

        //��������� ���������� ������
        ReadBasesList();
        label_Version.Text = Application.ProductVersion.ToString();
    }

    private static string GetDate() //��������� ������ ���� � ������� YYYYMMDD
    {
        DateTime date = DateTime.Now;
        string dateStr = date.Year.ToString() + date.Month.ToString("D2") + date.Day.ToString("D2");
        return dateStr;
    }

    /// <summary>
    /// ������� ����
    /// </summary>
    public enum BasesStatus
    {
        OK, // ����� ����������
        NotFound, // ���� �� ������
        Server //��������� ������ ��

    }

    /// <summary>
    /// �������� ������ ����
    /// </summary>
    public class Bases
    {
        public string? name;
        public string? path; // ���� � ����� ��
        public BasesStatus copied; //���������� ����?
    }



    #region ������ ���
    private List<Bases> listBase = new List<Bases>();

    private void button_ReadBasesList_Click(object sender, EventArgs e)
    {
        ReadBasesList();
    }

    private void ReadBasesList()
    {
        if (!File.Exists(textBox_BasesList.Text)) //�������� ������� ����� ������
        {
            textBox_debug.Text = "���� ������ ��� �� ������!";
            return;
        }

        StreamReader sr_BasesList = new StreamReader(textBox_BasesList.Text); //������ ����� ������

        //������� ��������� � ������
        listBox_Bases.Items.Clear();
        listBase.Clear();

        string namebase, pathbase, copiedbase = "";

        //������� ����� ������
        while (!sr_BasesList.EndOfStream)
        {
            string str = sr_BasesList.ReadLine();
            //���������� ������
            if (str[0] == '[') //���� ������ ���������� � [, �� � ��� ���������� �������� ����
            {
                str = str.Remove(0, 1);
                str = str.Remove(str.Length - 1, 1);
                namebase = str;

                str = sr_BasesList.ReadLine();
                if (str[0] == '[') continue;

                if (str.Contains("Connect=")) //���� ������ �������� "Connect=", �� � ��� ���������� ���� � ����
                {
                    if (str.Contains("File")) //���� ������ �������� "File", �� ���� �������� � �� ����� ����������
                    {
                        //��������� ���� � ����� ��
                        str = str.Remove(0, 14);
                        str = str.Remove(str.Length - 2, 2);
                        pathbase = str;
                        if (File.Exists(Path.Combine(pathbase, "1cv8.1cd"))) //���� ����������, ����� ����������
                        {
                            listBase.Add(new Bases { name = namebase, path = pathbase, copied = BasesStatus.OK });
                        }
                        else //����� �� ����������
                        {
                            listBase.Add(new Bases { name = namebase, path = "", copied = BasesStatus.NotFound });
                        }
                    }
                    else //���� ������ � "Connect=" �� �������� "File", �� ���� ������-��������� ��� ���-���������. ���� �� ����������
                    {
                        listBase.Add(new Bases { name = namebase, path = "", copied = BasesStatus.Server });
                    }
                }
            }
        }
        //������� ���� ������ ���
        sr_BasesList.Close();

        //���������� ���������
        foreach (Bases bases in listBase)
        {
            switch (bases.copied)
            {
                case BasesStatus.OK:
                    copiedbase = "";
                    break;
                case BasesStatus.NotFound:
                    copiedbase = "[���� �� �� ������] ";
                    break;
                case BasesStatus.Server:
                    copiedbase = "[��������� ��] ";
                    break;
                default:
                    break;
            }
            listBox_Bases.Items.Add(copiedbase + bases.name);
        }

    }

    #endregion


    #region ����������� ���

    /// <summary>
    /// ���������� ������� ������ "����������� ����"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button_CopyBases_Click(object sender, EventArgs e)
    {
        if (listBox_Bases.SelectedIndices.Count == 0)
        {
            textBox_debug.Text = "�� ������� ����!";
            return; //���� ������� 0 ��������� � ���������, �������� �����
        }
        for (int i = 0; i < listBox_Bases.Items.Count; i++) //������� ��������� ���������
        {
            if (listBox_Bases.GetSelected(i)) //���� ������� ������, �� �������� �����������
            {
                //listBase[i].check = true; 
                CopyBases(listBase[i].name, listBase[i].path, listBase[i].copied); //��������������� - ����������� ������ ��
            }
        }
        if (checkBox_OpenFolder.Checked)
        {
            OpenFolderCopy(); //���� ��������, �� ����������� ����� � ������� ����� ��������� �����������
        }
    }
    /// <summary>
    /// ����������� ����� ��
    /// </summary>
    /// <param name="name">��� ���� ������ � �������� �����</param>
    /// <param name="path">���� � ����� � �������</param>
    private void CopyBases(string name, string path, BasesStatus status)
    {
        //��������� ����� � �������� ��
        string sourceFile = Path.Combine(path, "1Cv8.1CD");
        name = Regex.Replace(name, @"[^\w\.@-]", " ", RegexOptions.None, TimeSpan.FromSeconds(1.5));
        string copyFile = Path.Combine(textBox_FolderCopy.Text, name + ".1cd");
        //string debugText = "";

        if (status == BasesStatus.NotFound)
        {
            textBox_debug.AppendText("���� " + name + " �� �����������, �.�. ���� ���� ������ �� ������.\r\n");
            return; //�������� �����, ���� ���� �� �� ������.
        }
        else if (status == BasesStatus.Server)
        {
            textBox_debug.AppendText("���� " + name + " �� �����������, �.�. ���� ���������.\r\n");
            return; //�������� �����, ���� ���� �� ��������.
        }

        if (!Directory.Exists(textBox_FolderCopy.Text)) //������� ����� � �������, ���� �� ���
        {
            Directory.CreateDirectory(textBox_FolderCopy.Text);
            textBox_debug.AppendText("������� �����: " + textBox_FolderCopy.Text + "\r\n");
        }

        if (File.Exists(copyFile)) //���� ���� ����� ����������, �� �������� ���������
        {
            if (radioButton_NotCopy.Checked) //�� ����������
            {
                textBox_debug.AppendText("���� " + name + " �� �����������, �.�. ���� ��� ����������.\r\n");
                return;
            }
            else if (radioButton_Replace.Checked) //���������� � �������
            {
                File.Copy(sourceFile, copyFile, true);
                textBox_debug.AppendText("���� " + name + " �����������, ���� �������.\r\n");
            }
            else if (radioButton_SaveBoth.Checked) //����������� ������ ���� � ����� � �������� ����� � ��������
            {
                DateTime dateTime = DateTime.Now;
                string strDateTime = dateTime.Year.ToString("D4") + dateTime.Month.ToString("D2") + dateTime.Day.ToString("D2") +
                    dateTime.Hour.ToString("D2") + dateTime.Minute.ToString("D2") + dateTime.Second.ToString("D2");
                copyFile = Path.Combine(textBox_FolderCopy.Text, name + strDateTime + ".1cd");
                File.Copy(sourceFile, copyFile);
                textBox_debug.AppendText("���� " + name + " �����������, ��� ����� ���������.\r\n");
            }
        }
        else //���� ����� ����� ��� ���, �� ������ ��������� �����.
        {
            File.Copy(sourceFile, copyFile);
            textBox_debug.AppendText("���� " + name + " �����������.\r\n");
        }
    }
    #endregion

    #region ������ � ������
    /// <summary>
    /// ���������� ������� ������ "�������� �����"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button_OpenFolder_Click(object sender, EventArgs e)
    {
        OpenFolderCopy();
    }
    /// <summary>
    /// �������� ����� � �������
    /// </summary>
    private void OpenFolderCopy()
    {
        if (Directory.Exists(textBox_FolderCopy.Text))
        {
            System.Diagnostics.Process.Start("explorer.exe", textBox_FolderCopy.Text);
        }
        else
        {
            textBox_debug.Text = "����� ����� �� ����������";
        }
    }

    /// <summary>
    /// ���������� ������� ������ "...". ����� ����� � �������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button_SelectFolderCopy_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog FBD = new FolderBrowserDialog();
        if (FBD.ShowDialog() == DialogResult.OK)
        {
            textBox_FolderCopy.Text = FBD.SelectedPath;
            textBox_FolderCopy.Text += @"\" + GetDate(); //���������� ���� � ���� �����
            SafePath();
        }

    }
    /// <summary>
    /// ���������� ������� ������ "...". ����� ����� ������ ��
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void button_SelectBasesList_Click(object sender, EventArgs e)
    {
        OpenFileDialog OPF = new OpenFileDialog
        {
            Filter = "����� ������ ��� ������ 1�|*.v8i"
        };
        if (OPF.ShowDialog() == DialogResult.OK)
        {
            textBox_BasesList.Text = OPF.FileName;

        }

    }

    /// <summary>
    /// ������ � ���� ���������� ���� ����������� ��� ��� ���������
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

    #region ����
    /// <summary>
    /// ���������� ������� ������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start(linkLabel1.Text);
    }


    #endregion


}
