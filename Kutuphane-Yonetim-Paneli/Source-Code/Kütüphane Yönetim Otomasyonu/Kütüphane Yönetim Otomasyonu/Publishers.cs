using System;
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
    public partial class Publishers : Form
    {
        public Publishers()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Publishers", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Mail";
            dataGridView1.Columns[4].HeaderText = "Adres";
        }

        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Publishers where Name like '{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Mail";
            dataGridView1.Columns[4].HeaderText = "Adres";




        }
        private void Members_Load(object sender, EventArgs e)
        {


            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();

            txt_Name.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            richTextBox1.MaxLength = 200;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_Phone.Text = dataGridView1.CurrentRow.Cells["Phone"].Value.ToString();
            txt_Mail.Text = dataGridView1.CurrentRow.Cells["Mail"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"SELECT * FROM Publishers where Name='{txt_Name.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir yayınevi var !!!");
                sqlConnection.Close();

            }
            else
            {

                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                }
                else
                {
                    if (txt_Phone.TextLength > 10)
                    {
                        sqlConnection.Close();
                        sqlConnection.Open();
                        SqlCommand komut = new SqlCommand($"insert into Publishers (Name,Phone,Mail,Address) values ('{txt_Name.Text}','{txt_Phone.Text}','{txt_Mail.Text}','{richTextBox1.Text}')", sqlConnection);

                        int eklenti = komut.ExecuteNonQuery();
                        sqlConnection.Close();

                        if (eklenti > 0)
                        {
                            MessageBox.Show("Yayınevi Sisteme Eklendi.");
                            TableReflesh();
                        }
                        else
                        {
                            MessageBox.Show("Yayınevi eklenemedi.");
                        }
                        sqlConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlConnection.Close();
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
                SqlCommand Sil = new SqlCommand($"DeleteFromPublishers {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek yayınevini seçiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
            {
                MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection.Close();
            }
            else
            {
                if (txt_Phone.TextLength > 10)
                {
                    if (txt_Id.Text != "")
                    {
                        int IDD = Convert.ToInt32(txt_Id.Text);
                        sqlConnection.Open();
                        SqlCommand Update = new SqlCommand($"UpdateFromPublishers {IDD},'{txt_Name.Text}','{txt_Phone.Text}','{txt_Mail.Text}','{richTextBox1.Text}'", sqlConnection);
                        Update.ExecuteNonQuery();
                        sqlConnection.Close();
                        TableReflesh();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen güncellenecek yayınevini seçiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection.Close();
                }
            }




        }





        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

            TableReflesh(txt_Search_Name.Text);


        }
    }


}

