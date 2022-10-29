﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
         
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Employees m inner join Permissions p on p.ID=m.Permission_ID", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Doğum Tarihi";
         
            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[11].HeaderText = "Yetki";
        
            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;





        }
        private void TableReflesh(decimal SearchTextTC)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Employees m inner join Permissions p on p.ID=m.Permission_ID where IdentityNumber like '{SearchTextTC}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Doğum Tarihi";

            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[11].HeaderText = "Yetki";

            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;




        }
        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Employees m inner join Permissions p on p.ID=m.Permission_ID where Name like '{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "TC";
            dataGridView1.Columns[5].HeaderText = "Cinsiyet";
            dataGridView1.Columns[6].HeaderText = "Doğum Tarihi";

            dataGridView1.Columns[8].HeaderText = "Mail";
            dataGridView1.Columns[9].HeaderText = "Şifre";
            dataGridView1.Columns[11].HeaderText = "Yetki";

            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;




        }
        private void Members_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 2;

            SqlCommand komut = new SqlCommand("SELECT Permission FROM Permissions", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["Permission"]);
            }
            sqlConnection.Close();
            comboBox2.SelectedIndex = 0;
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();

            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_TC.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            //rTxt_Address.MaxLength = 200;
            txt_Password.MaxLength = 50;
            txt_Search_TC.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_Surname.Text = dataGridView1.CurrentRow.Cells["Surname"].Value.ToString();
            comboBox1.Text = (dataGridView1.CurrentRow.Cells["Gender"].Value).ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["BirthDate"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txt_TC.Text = (dataGridView1.CurrentRow.Cells["IdentityNumber"].Value).ToString();
            txt_Mail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
           
            int PermissionID= Convert.ToInt32(dataGridView1.CurrentRow.Cells["Permission_ID"].Value.ToString());
            SqlCommand komut = new SqlCommand($"SELECT Permission FROM Permissions where ID={PermissionID}", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
         
            while (dr.Read())
            {
                comboBox2.Text=(dr["Permission"].ToString());
            }
            
            sqlConnection.Close();
       
            txt_Password.Text = dataGridView1.CurrentRow.Cells["Password"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"SELECT * FROM Employees where IdentityNumber='{txt_TC.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu TC numarasına ait başka bir Personel var !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txt_Phone.TextLength>10)
                    {
                        if (txt_TC.TextLength>10)
                        {
                            
                            int PermissionID = 0;
                            SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Permissions where Permission='{comboBox2.Text}'", sqlConnection);
                            SqlDataReader dr;
                            sqlConnection.Open();
                            dr = komut1.ExecuteReader();

                            while (dr.Read())
                            {
                            PermissionID  = Convert.ToInt32(dr["ID"].ToString());
                            }

                            sqlConnection.Close();
                            sqlConnection.Open();
                            SqlCommand komut = new SqlCommand($"insert into employees (Name,Surname,Gender,BirthDate,Phone,IdentityNumber,Mail,Permission_ID,Password) values ('{txt_Name.Text}','{txt_Surname.Text}','{comboBox1.Text}','{dateTimePicker1.Text}','{txt_Phone.Text}','{txt_TC.Text}','{txt_Mail.Text}','{PermissionID}','{txt_Password.Text}')");
                            komut.Connection = sqlConnection;
                            int eklenti = komut.ExecuteNonQuery();
                            sqlConnection.Close();

                            if (eklenti > 0)
                            {
                                MessageBox.Show("Personel Sisteme Eklendi.");
                                TableReflesh();
                            }
                            else
                            {
                                MessageBox.Show("Personel eklenemedi.");
                            }
                            sqlConnection.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen Geçerli Bir TC Numarası giriniz.", "Geçersiz TC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                   
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (txt_Id.Text != "")
            {
                int IDD = Convert.ToInt32(txt_Id.Text);
                sqlConnection.Open();
                SqlCommand Sil = new SqlCommand($"DeleteFromEmployees {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            int PermissionID = 0;
            SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Permissions where Permission='{comboBox2.Text}'", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut1.ExecuteReader();

            while (dr.Read())
            {
                PermissionID = Convert.ToInt32(dr["ID"].ToString());
            }

            sqlConnection.Close();
            if (txt_Id.Text != "")
            {
                int IDD = Convert.ToInt32(txt_Id.Text);
                sqlConnection.Open();
                SqlCommand Update = new SqlCommand($"UpdateFromEmployees {IDD},'{txt_Name.Text}','{txt_Surname.Text}','{comboBox1.Text}','{dateTimePicker1.Text}','{txt_Phone.Text}','{txt_Mail.Text}','{PermissionID}','{txt_Password.Text}'", sqlConnection);
                Update.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek kaydı seçiniz");
            }

        }



        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (dataGridView1.Rows[i].Cells["Permission"].Value.ToString() == "Admin")
                {
                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;
                }
                //else if (dataGridView1.Rows[i].Cells["Permission"].Value.ToString() == "Pasif")
                //{
                //    renk.BackColor = Color.Orange;
                //}
                //else if (dataGridView1.Rows[i].Cells["Permission"].Value.ToString() == "Admin")
                //{
                //    renk.BackColor = Color.Red;
                //    renk.ForeColor = Color.White;
                //}
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }

        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            if (txt_Search_TC.Text!="")
            {
                TableReflesh(Convert.ToDecimal(txt_Search_TC.Text));
            }
            else
            {
                TableReflesh();
            }
           
        }

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Search_TC.Text = "";
            TableReflesh(txt_Search_Name.Text);
           

        }
    }


}

