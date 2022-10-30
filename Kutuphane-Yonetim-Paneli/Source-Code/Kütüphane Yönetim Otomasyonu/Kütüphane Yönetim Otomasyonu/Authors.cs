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
    public partial class Authors : Form
    {
        public Authors()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
         
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Authors", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;
        }
        private void TableSearch(string SearchTextInformation)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Authors where Information like '%{SearchTextInformation}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;




        }
        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Authors where NameSurname like '{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ad-Soyad";
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Hakkında";
            dataGridView1.Columns[2].Width = 850;




        }
        private void Members_Load(object sender, EventArgs e)
        {

          
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();

            txt_Name.MaxLength = 100;
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["NameSurname"].Value.ToString();
            richTextBox1.Text= dataGridView1.CurrentRow.Cells["Information"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand FindAuthor = new SqlCommand();
            FindAuthor.Connection = sqlConnection;
            FindAuthor.CommandText = "FindAuthor"; //stoured procedure'un saklandığı yer.
            FindAuthor.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            FindAuthor.Parameters.AddWithValue("@NameSurname", txt_Name.Text);
            SqlDataReader dr2 = FindAuthor.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu isme sahip başka bir yazar var !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = sqlConnection;
                komut.CommandText = "AddAuthors"; //stoured procedure'un saklandığı yer.
                komut.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.

             
                komut.Parameters.AddWithValue("@NameSurname", txt_Name.Text);
                komut.Parameters.AddWithValue("@Information", richTextBox1.Text);
                int eklenti = komut.ExecuteNonQuery();
                    sqlConnection.Close();

                    if (eklenti > 0)
                    {
                        MessageBox.Show("Yazar Sisteme Eklendi.");
                        TableReflesh();
                    }
                    else
                    {
                        MessageBox.Show("Yazar eklenemedi.");
                    }
                    sqlConnection.Close();
                
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                int IDD = Convert.ToInt32(txt_Id.Text);
                sqlConnection.Open();
                SqlCommand Sil = new SqlCommand($"DeleteFromAuthors {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek yazarı seçiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

           
            if (txt_Id.Text != "")
            {
                int IDD = Convert.ToInt32(txt_Id.Text);   
                sqlConnection.Open();
                SqlCommand UpdateCMD = new SqlCommand();
                UpdateCMD.Connection = sqlConnection;
                UpdateCMD.CommandText = "UpdateFromAuthors"; //stoured procedure'un saklandığı yer.
                UpdateCMD.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.

                UpdateCMD.Parameters.AddWithValue("@ID", IDD); //@Adi parametresi gösterldi.
                UpdateCMD.Parameters.AddWithValue("@NameSurname", txt_Name.Text); //@SoyAdi paremetresi gönderildi.
                UpdateCMD.Parameters.AddWithValue("@Information", richTextBox1.Text); //@SoyAdi paremetresi gönderildi.
                UpdateCMD.ExecuteNonQuery(); // veriler veritabanında kaydedildi.
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek yazarı seçiniz");
            }

        }



    
        

        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            TableSearch((txt_Search_Information.Text));
          
           
        }

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Information.Text = "";
            TableReflesh(txt_Search_Name.Text);
           

        }
    }


}

