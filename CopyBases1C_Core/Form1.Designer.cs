namespace CopyBases1C
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
            this.textBox_BasesList = new System.Windows.Forms.TextBox();
            this.textBox_FolderCopy = new System.Windows.Forms.TextBox();
            this.listBox_Bases = new System.Windows.Forms.ListBox();
            this.textBox_debug = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_SaveBoth = new System.Windows.Forms.RadioButton();
            this.radioButton_Replace = new System.Windows.Forms.RadioButton();
            this.radioButton_NotCopy = new System.Windows.Forms.RadioButton();
            this.button_ReadBasesList = new System.Windows.Forms.Button();
            this.button_CopyBases = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_OpenFolder = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.button_SelectBasesList = new System.Windows.Forms.Button();
            this.button_SelectFolderCopy = new System.Windows.Forms.Button();
            this.label_Version = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_BasesList
            // 
            this.textBox_BasesList.Location = new System.Drawing.Point(121, 6);
            this.textBox_BasesList.Name = "textBox_BasesList";
            this.textBox_BasesList.Size = new System.Drawing.Size(217, 23);
            this.textBox_BasesList.TabIndex = 0;
            // 
            // textBox_FolderCopy
            // 
            this.textBox_FolderCopy.Location = new System.Drawing.Point(121, 35);
            this.textBox_FolderCopy.Name = "textBox_FolderCopy";
            this.textBox_FolderCopy.Size = new System.Drawing.Size(217, 23);
            this.textBox_FolderCopy.TabIndex = 1;
            // 
            // listBox_Bases
            // 
            this.listBox_Bases.FormattingEnabled = true;
            this.listBox_Bases.ItemHeight = 15;
            this.listBox_Bases.Location = new System.Drawing.Point(121, 64);
            this.listBox_Bases.Name = "listBox_Bases";
            this.listBox_Bases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Bases.Size = new System.Drawing.Size(250, 184);
            this.listBox_Bases.TabIndex = 2;
            // 
            // textBox_debug
            // 
            this.textBox_debug.Enabled = false;
            this.textBox_debug.Location = new System.Drawing.Point(12, 254);
            this.textBox_debug.Multiline = true;
            this.textBox_debug.Name = "textBox_debug";
            this.textBox_debug.Size = new System.Drawing.Size(511, 100);
            this.textBox_debug.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_SaveBoth);
            this.groupBox1.Controls.Add(this.radioButton_Replace);
            this.groupBox1.Controls.Add(this.radioButton_NotCopy);
            this.groupBox1.Location = new System.Drawing.Point(377, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Если копия уже есть:";
            // 
            // radioButton_SaveBoth
            // 
            this.radioButton_SaveBoth.AutoSize = true;
            this.radioButton_SaveBoth.Location = new System.Drawing.Point(6, 71);
            this.radioButton_SaveBoth.Name = "radioButton_SaveBoth";
            this.radioButton_SaveBoth.Size = new System.Drawing.Size(107, 19);
            this.radioButton_SaveBoth.TabIndex = 2;
            this.radioButton_SaveBoth.Text = "Сохранить оба";
            this.radioButton_SaveBoth.UseVisualStyleBackColor = true;
            // 
            // radioButton_Replace
            // 
            this.radioButton_Replace.AutoSize = true;
            this.radioButton_Replace.Location = new System.Drawing.Point(6, 46);
            this.radioButton_Replace.Name = "radioButton_Replace";
            this.radioButton_Replace.Size = new System.Drawing.Size(78, 19);
            this.radioButton_Replace.TabIndex = 1;
            this.radioButton_Replace.Text = "Заменить";
            this.radioButton_Replace.UseVisualStyleBackColor = true;
            // 
            // radioButton_NotCopy
            // 
            this.radioButton_NotCopy.AutoSize = true;
            this.radioButton_NotCopy.Checked = true;
            this.radioButton_NotCopy.Location = new System.Drawing.Point(6, 22);
            this.radioButton_NotCopy.Name = "radioButton_NotCopy";
            this.radioButton_NotCopy.Size = new System.Drawing.Size(107, 19);
            this.radioButton_NotCopy.TabIndex = 0;
            this.radioButton_NotCopy.TabStop = true;
            this.radioButton_NotCopy.Text = "Не копировать";
            this.radioButton_NotCopy.UseVisualStyleBackColor = true;
            // 
            // button_ReadBasesList
            // 
            this.button_ReadBasesList.Location = new System.Drawing.Point(377, 6);
            this.button_ReadBasesList.Name = "button_ReadBasesList";
            this.button_ReadBasesList.Size = new System.Drawing.Size(146, 23);
            this.button_ReadBasesList.TabIndex = 5;
            this.button_ReadBasesList.Text = "Обновить список";
            this.button_ReadBasesList.UseVisualStyleBackColor = true;
            this.button_ReadBasesList.Click += new System.EventHandler(this.button_ReadBasesList_Click);
            // 
            // button_CopyBases
            // 
            this.button_CopyBases.Location = new System.Drawing.Point(377, 34);
            this.button_CopyBases.Name = "button_CopyBases";
            this.button_CopyBases.Size = new System.Drawing.Size(146, 23);
            this.button_CopyBases.TabIndex = 6;
            this.button_CopyBases.Text = "Скопировать базы";
            this.button_CopyBases.UseVisualStyleBackColor = true;
            this.button_CopyBases.Click += new System.EventHandler(this.button_CopyBases_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Файл списка баз:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Путь к копиям:";
            // 
            // checkBox_OpenFolder
            // 
            this.checkBox_OpenFolder.AutoSize = true;
            this.checkBox_OpenFolder.Checked = true;
            this.checkBox_OpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OpenFolder.Location = new System.Drawing.Point(383, 169);
            this.checkBox_OpenFolder.Name = "checkBox_OpenFolder";
            this.checkBox_OpenFolder.Size = new System.Drawing.Size(106, 49);
            this.checkBox_OpenFolder.TabIndex = 9;
            this.checkBox_OpenFolder.Text = "По окончании\r\nкопирования\r\nоткрыть папку";
            this.checkBox_OpenFolder.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(281, 357);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(242, 15);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/Giblarium/CopyBases1C";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(377, 224);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(146, 23);
            this.button_OpenFolder.TabIndex = 11;
            this.button_OpenFolder.Text = "Открыть копии";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.button_OpenFolder_Click);
            // 
            // button_SelectBasesList
            // 
            this.button_SelectBasesList.Location = new System.Drawing.Point(344, 6);
            this.button_SelectBasesList.Name = "button_SelectBasesList";
            this.button_SelectBasesList.Size = new System.Drawing.Size(27, 23);
            this.button_SelectBasesList.TabIndex = 12;
            this.button_SelectBasesList.Text = "...";
            this.button_SelectBasesList.UseVisualStyleBackColor = true;
            this.button_SelectBasesList.Click += new System.EventHandler(this.button_SelectBasesList_Click);
            // 
            // button_SelectFolderCopy
            // 
            this.button_SelectFolderCopy.Location = new System.Drawing.Point(344, 34);
            this.button_SelectFolderCopy.Name = "button_SelectFolderCopy";
            this.button_SelectFolderCopy.Size = new System.Drawing.Size(27, 23);
            this.button_SelectFolderCopy.TabIndex = 13;
            this.button_SelectFolderCopy.Text = "...";
            this.button_SelectFolderCopy.UseVisualStyleBackColor = true;
            this.button_SelectFolderCopy.Click += new System.EventHandler(this.button_SelectFolderCopy_Click);
            // 
            // label_Version
            // 
            this.label_Version.AutoSize = true;
            this.label_Version.Location = new System.Drawing.Point(12, 357);
            this.label_Version.Name = "label_Version";
            this.label_Version.Size = new System.Drawing.Size(38, 15);
            this.label_Version.TabIndex = 14;
            this.label_Version.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 381);
            this.Controls.Add(this.label_Version);
            this.Controls.Add(this.button_SelectFolderCopy);
            this.Controls.Add(this.button_SelectBasesList);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox_OpenFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_CopyBases);
            this.Controls.Add(this.button_ReadBasesList);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_debug);
            this.Controls.Add(this.listBox_Bases);
            this.Controls.Add(this.textBox_FolderCopy);
            this.Controls.Add(this.textBox_BasesList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_BasesList;
        private TextBox textBox_FolderCopy;
        private ListBox listBox_Bases;
        private TextBox textBox_debug;
        private GroupBox groupBox1;
        private RadioButton radioButton_SaveBoth;
        private RadioButton radioButton_Replace;
        private RadioButton radioButton_NotCopy;
        private Button button_ReadBasesList;
        private Button button_CopyBases;
        private Label label1;
        private Label label2;
        private CheckBox checkBox_OpenFolder;
        private LinkLabel linkLabel1;
        private Button button_OpenFolder;
        private Button button_SelectBasesList;
        private Button button_SelectFolderCopy;
        private Label label_Version;
    }
}