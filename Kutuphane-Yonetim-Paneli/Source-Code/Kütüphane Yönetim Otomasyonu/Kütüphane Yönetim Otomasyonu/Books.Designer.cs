namespace Kütüphane_Yönetim_Otomasyonu
{
    partial class Books
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_ShelfNumber = new System.Windows.Forms.TextBox();
            this.txt_PageNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cB_Language = new System.Windows.Forms.ComboBox();
            this.cB_Author = new System.Windows.Forms.ComboBox();
            this.rTxt_Description = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Search_Shelf = new System.Windows.Forms.TextBox();
            this.txt_Search_Name = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkB_State = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cB_Publisher = new System.Windows.Forms.ComboBox();
            this.cB_Category = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_PublishYear = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 356);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1130, 273);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // txt_Id
            // 
            this.txt_Id.Enabled = false;
            this.txt_Id.Location = new System.Drawing.Point(174, 12);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.Size = new System.Drawing.Size(133, 20);
            this.txt_Id.TabIndex = 1;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(174, 38);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(133, 20);
            this.txt_Name.TabIndex = 2;
            // 
            // txt_ShelfNumber
            // 
            this.txt_ShelfNumber.Location = new System.Drawing.Point(174, 278);
            this.txt_ShelfNumber.Name = "txt_ShelfNumber";
            this.txt_ShelfNumber.Size = new System.Drawing.Size(133, 20);
            this.txt_ShelfNumber.TabIndex = 3;
            // 
            // txt_PageNumber
            // 
            this.txt_PageNumber.Location = new System.Drawing.Point(175, 90);
            this.txt_PageNumber.Name = "txt_PageNumber";
            this.txt_PageNumber.Size = new System.Drawing.Size(133, 20);
            this.txt_PageNumber.TabIndex = 6;
            this.txt_PageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Just_Numeric_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dil";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(106, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "RAF NO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Sayfa Sayısı";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(79, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Yayınlanma Tarihi";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(100, 232);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Yazar";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(117, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Açıklama";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(434, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 43);
            this.button1.TabIndex = 27;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(551, 29);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 42);
            this.button2.TabIndex = 28;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(669, 28);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 43);
            this.button3.TabIndex = 29;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // cB_Language
            // 
            this.cB_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Language.FormattingEnabled = true;
            this.cB_Language.Location = new System.Drawing.Point(174, 251);
            this.cB_Language.Name = "cB_Language";
            this.cB_Language.Size = new System.Drawing.Size(133, 21);
            this.cB_Language.TabIndex = 30;
            // 
            // cB_Author
            // 
            this.cB_Author.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Author.FormattingEnabled = true;
            this.cB_Author.Location = new System.Drawing.Point(175, 224);
            this.cB_Author.Name = "cB_Author";
            this.cB_Author.Size = new System.Drawing.Size(133, 21);
            this.cB_Author.TabIndex = 31;
            // 
            // rTxt_Description
            // 
            this.rTxt_Description.Location = new System.Drawing.Point(175, 113);
            this.rTxt_Description.Name = "rTxt_Description";
            this.rTxt_Description.Size = new System.Drawing.Size(203, 83);
            this.rTxt_Description.TabIndex = 32;
            this.rTxt_Description.Text = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(874, 308);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "RAFA GÖRE";
            // 
            // txt_Search_Shelf
            // 
            this.txt_Search_Shelf.Location = new System.Drawing.Point(987, 305);
            this.txt_Search_Shelf.Name = "txt_Search_Shelf";
            this.txt_Search_Shelf.Size = new System.Drawing.Size(133, 20);
            this.txt_Search_Shelf.TabIndex = 35;
            this.txt_Search_Shelf.TextChanged += new System.EventHandler(this.txt_Search_TC_TextChanged);
            // 
            // txt_Search_Name
            // 
            this.txt_Search_Name.Location = new System.Drawing.Point(987, 332);
            this.txt_Search_Name.Name = "txt_Search_Name";
            this.txt_Search_Name.Size = new System.Drawing.Size(133, 20);
            this.txt_Search_Name.TabIndex = 36;
            this.txt_Search_Name.TextChanged += new System.EventHandler(this.txt_Search_Name_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(874, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "ADINA GÖRE";
            // 
            // checkB_State
            // 
            this.checkB_State.AutoSize = true;
            this.checkB_State.Location = new System.Drawing.Point(196, 202);
            this.checkB_State.Name = "checkB_State";
            this.checkB_State.Size = new System.Drawing.Size(71, 17);
            this.checkB_State.TabIndex = 38;
            this.checkB_State.Text = "Mevcutta";
            this.checkB_State.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(115, 307);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Yayınevi";
            // 
            // cB_Publisher
            // 
            this.cB_Publisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Publisher.FormattingEnabled = true;
            this.cB_Publisher.Location = new System.Drawing.Point(174, 304);
            this.cB_Publisher.Name = "cB_Publisher";
            this.cB_Publisher.Size = new System.Drawing.Size(133, 21);
            this.cB_Publisher.TabIndex = 40;
            // 
            // cB_Category
            // 
            this.cB_Category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Category.FormattingEnabled = true;
            this.cB_Category.Location = new System.Drawing.Point(174, 331);
            this.cB_Category.Name = "cB_Category";
            this.cB_Category.Size = new System.Drawing.Size(133, 21);
            this.cB_Category.TabIndex = 42;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(115, 334);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 41;
            this.label16.Text = "Kategori";
            // 
            // txt_PublishYear
            // 
            this.txt_PublishYear.Location = new System.Drawing.Point(174, 64);
            this.txt_PublishYear.Name = "txt_PublishYear";
            this.txt_PublishYear.Size = new System.Drawing.Size(133, 20);
            this.txt_PublishYear.TabIndex = 43;
            this.txt_PublishYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Just_Numeric_KeyPress);
            // 
            // Books
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(1150, 650);
            this.Controls.Add(this.txt_PublishYear);
            this.Controls.Add(this.cB_Category);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cB_Publisher);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.checkB_State);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_Search_Name);
            this.Controls.Add(this.txt_Search_Shelf);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.rTxt_Description);
            this.Controls.Add(this.cB_Author);
            this.Controls.Add(this.cB_Language);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PageNumber);
            this.Controls.Add(this.txt_ShelfNumber);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_Id);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Books";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Members";
            this.Load += new System.EventHandler(this.Members_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_ShelfNumber;
        private System.Windows.Forms.TextBox txt_PageNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cB_Language;
        private System.Windows.Forms.ComboBox cB_Author;
        private System.Windows.Forms.RichTextBox rTxt_Description;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Search_Shelf;
        private System.Windows.Forms.TextBox txt_Search_Name;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkB_State;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cB_Publisher;
        private System.Windows.Forms.ComboBox cB_Category;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_PublishYear;
    }
}