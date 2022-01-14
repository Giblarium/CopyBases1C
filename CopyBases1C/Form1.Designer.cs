namespace CopyBases1C
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button_ReadBasesList = new System.Windows.Forms.Button();
            this.button_CopyBases = new System.Windows.Forms.Button();
            this.textBox_BasesList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FolderCopy = new System.Windows.Forms.TextBox();
            this.listBox_Bases = new System.Windows.Forms.ListBox();
            this.textBox_debug = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_SaveBoth = new System.Windows.Forms.RadioButton();
            this.radioButton_Replace = new System.Windows.Forms.RadioButton();
            this.radioButton_NotCopy = new System.Windows.Forms.RadioButton();
            this.button_OpenFolder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button_SelectBasesList = new System.Windows.Forms.Button();
            this.button_SelectFolderCopy = new System.Windows.Forms.Button();
            this.checkBox_OpenFolder = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Файл списка баз:";
            // 
            // button_ReadBasesList
            // 
            this.button_ReadBasesList.Location = new System.Drawing.Point(451, 4);
            this.button_ReadBasesList.Name = "button_ReadBasesList";
            this.button_ReadBasesList.Size = new System.Drawing.Size(113, 23);
            this.button_ReadBasesList.TabIndex = 2;
            this.button_ReadBasesList.Text = "Обновить список";
            this.button_ReadBasesList.UseVisualStyleBackColor = true;
            this.button_ReadBasesList.Click += new System.EventHandler(this.button_ReadBasesList_Click);
            // 
            // button_CopyBases
            // 
            this.button_CopyBases.Location = new System.Drawing.Point(451, 33);
            this.button_CopyBases.Name = "button_CopyBases";
            this.button_CopyBases.Size = new System.Drawing.Size(113, 23);
            this.button_CopyBases.TabIndex = 3;
            this.button_CopyBases.Text = "Скопровать базы";
            this.button_CopyBases.UseVisualStyleBackColor = true;
            this.button_CopyBases.Click += new System.EventHandler(this.button_CopyBases_Click);
            // 
            // textBox_BasesList
            // 
            this.textBox_BasesList.Location = new System.Drawing.Point(150, 6);
            this.textBox_BasesList.Name = "textBox_BasesList";
            this.textBox_BasesList.Size = new System.Drawing.Size(263, 20);
            this.textBox_BasesList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Путь к копиям:";
            // 
            // textBox_FolderCopy
            // 
            this.textBox_FolderCopy.Location = new System.Drawing.Point(150, 35);
            this.textBox_FolderCopy.Name = "textBox_FolderCopy";
            this.textBox_FolderCopy.Size = new System.Drawing.Size(263, 20);
            this.textBox_FolderCopy.TabIndex = 5;
            this.textBox_FolderCopy.Leave += new System.EventHandler(this.textBox_FolderCopy_Leave);
            // 
            // listBox_Bases
            // 
            this.listBox_Bases.FormattingEnabled = true;
            this.listBox_Bases.Items.AddRange(new object[] {
            "Пусто"});
            this.listBox_Bases.Location = new System.Drawing.Point(150, 61);
            this.listBox_Bases.Name = "listBox_Bases";
            this.listBox_Bases.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox_Bases.Size = new System.Drawing.Size(295, 212);
            this.listBox_Bases.TabIndex = 0;
            // 
            // textBox_debug
            // 
            this.textBox_debug.Enabled = false;
            this.textBox_debug.Location = new System.Drawing.Point(15, 279);
            this.textBox_debug.Multiline = true;
            this.textBox_debug.Name = "textBox_debug";
            this.textBox_debug.Size = new System.Drawing.Size(549, 97);
            this.textBox_debug.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_SaveBoth);
            this.groupBox1.Controls.Add(this.radioButton_Replace);
            this.groupBox1.Controls.Add(this.radioButton_NotCopy);
            this.groupBox1.Location = new System.Drawing.Point(452, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 107);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Если копия уже есть:";
            // 
            // radioButton_SaveBoth
            // 
            this.radioButton_SaveBoth.AutoSize = true;
            this.radioButton_SaveBoth.Location = new System.Drawing.Point(6, 79);
            this.radioButton_SaveBoth.Name = "radioButton_SaveBoth";
            this.radioButton_SaveBoth.Size = new System.Drawing.Size(99, 17);
            this.radioButton_SaveBoth.TabIndex = 0;
            this.radioButton_SaveBoth.Text = "Сохранить оба";
            this.radioButton_SaveBoth.UseVisualStyleBackColor = true;
            // 
            // radioButton_Replace
            // 
            this.radioButton_Replace.AutoSize = true;
            this.radioButton_Replace.Location = new System.Drawing.Point(7, 56);
            this.radioButton_Replace.Name = "radioButton_Replace";
            this.radioButton_Replace.Size = new System.Drawing.Size(75, 17);
            this.radioButton_Replace.TabIndex = 0;
            this.radioButton_Replace.Text = "Заменить";
            this.radioButton_Replace.UseVisualStyleBackColor = true;
            // 
            // radioButton_NotCopy
            // 
            this.radioButton_NotCopy.AutoSize = true;
            this.radioButton_NotCopy.Checked = true;
            this.radioButton_NotCopy.Location = new System.Drawing.Point(7, 33);
            this.radioButton_NotCopy.Name = "radioButton_NotCopy";
            this.radioButton_NotCopy.Size = new System.Drawing.Size(101, 17);
            this.radioButton_NotCopy.TabIndex = 0;
            this.radioButton_NotCopy.TabStop = true;
            this.radioButton_NotCopy.Text = "Не копировать";
            this.radioButton_NotCopy.UseVisualStyleBackColor = true;
            // 
            // button_OpenFolder
            // 
            this.button_OpenFolder.Location = new System.Drawing.Point(451, 250);
            this.button_OpenFolder.Name = "button_OpenFolder";
            this.button_OpenFolder.Size = new System.Drawing.Size(113, 23);
            this.button_OpenFolder.TabIndex = 3;
            this.button_OpenFolder.Text = "Открыть копии";
            this.button_OpenFolder.UseVisualStyleBackColor = true;
            this.button_OpenFolder.Click += new System.EventHandler(this.button_OpenFolder_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(350, 379);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(214, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/Giblarium/CopyBases1C";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button_SelectBasesList
            // 
            this.button_SelectBasesList.Location = new System.Drawing.Point(419, 4);
            this.button_SelectBasesList.Name = "button_SelectBasesList";
            this.button_SelectBasesList.Size = new System.Drawing.Size(26, 23);
            this.button_SelectBasesList.TabIndex = 9;
            this.button_SelectBasesList.Text = "...";
            this.button_SelectBasesList.UseVisualStyleBackColor = true;
            this.button_SelectBasesList.Click += new System.EventHandler(this.button_SelectBasesList_Click);
            // 
            // button_SelectFolderCopy
            // 
            this.button_SelectFolderCopy.Location = new System.Drawing.Point(419, 33);
            this.button_SelectFolderCopy.Name = "button_SelectFolderCopy";
            this.button_SelectFolderCopy.Size = new System.Drawing.Size(26, 23);
            this.button_SelectFolderCopy.TabIndex = 9;
            this.button_SelectFolderCopy.Text = "...";
            this.button_SelectFolderCopy.UseVisualStyleBackColor = true;
            this.button_SelectFolderCopy.Click += new System.EventHandler(this.button_SelectFolderCopy_Click);
            // 
            // checkBox_OpenFolder
            // 
            this.checkBox_OpenFolder.AutoSize = true;
            this.checkBox_OpenFolder.Checked = true;
            this.checkBox_OpenFolder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OpenFolder.Location = new System.Drawing.Point(452, 201);
            this.checkBox_OpenFolder.Name = "checkBox_OpenFolder";
            this.checkBox_OpenFolder.Size = new System.Drawing.Size(100, 43);
            this.checkBox_OpenFolder.TabIndex = 10;
            this.checkBox_OpenFolder.Text = "По окончании \r\nкопирования \r\nоткрыть папку";
            this.checkBox_OpenFolder.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 399);
            this.Controls.Add(this.checkBox_OpenFolder);
            this.Controls.Add(this.button_SelectFolderCopy);
            this.Controls.Add(this.button_SelectBasesList);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_debug);
            this.Controls.Add(this.textBox_FolderCopy);
            this.Controls.Add(this.textBox_BasesList);
            this.Controls.Add(this.button_OpenFolder);
            this.Controls.Add(this.button_CopyBases);
            this.Controls.Add(this.button_ReadBasesList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_Bases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Копирование баз 1С";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ReadBasesList;
        private System.Windows.Forms.Button button_CopyBases;
        private System.Windows.Forms.TextBox textBox_BasesList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FolderCopy;
        private System.Windows.Forms.ListBox listBox_Bases;
        private System.Windows.Forms.TextBox textBox_debug;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_SaveBoth;
        private System.Windows.Forms.RadioButton radioButton_Replace;
        private System.Windows.Forms.RadioButton radioButton_NotCopy;
        private System.Windows.Forms.Button button_OpenFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button_SelectBasesList;
        private System.Windows.Forms.Button button_SelectFolderCopy;
        private System.Windows.Forms.CheckBox checkBox_OpenFolder;
    }
}

