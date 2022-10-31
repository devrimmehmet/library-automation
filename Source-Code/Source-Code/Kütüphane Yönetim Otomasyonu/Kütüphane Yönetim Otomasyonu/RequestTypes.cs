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
    public partial class RequestTypes : Form
    {
        public RequestTypes()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from RequestTypes", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "RequestType";
            dataGridView1.Columns[1].Width = 1000;
        }

        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from RequestTypes where RequestType like  '%{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "RequestType";
            dataGridView1.Columns[1].Width = 1000;



        }
        private void Members_Load(object sender, EventArgs e)
        {


            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();

            txt_Name.MaxLength = 50;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["RequestType"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"select * from RequestTypes where RequestType='{txt_Name.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu Talep türü zaten sisteme eklendi !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                SqlCommand komut = new SqlCommand($"insert into RequestTypes (RequestType) values ('{txt_Name.Text}')", sqlConnection);

                int eklenti = komut.ExecuteNonQuery();
                sqlConnection.Close();

                if (eklenti > 0)
                {
                    MessageBox.Show("Talep Türü Sisteme Eklendi.");
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Talep Türü eklenemedi.");
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
                SqlCommand Sil = new SqlCommand($"DeleteFromRequestTypes {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek talep türünü seçiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"select * from RequestTypes where RequestType='{txt_Name.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu talep türü zaten sistemde var bu güncelleme işlemini yapamazsınız !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();

                if (txt_Id.Text != "")
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);

                    SqlCommand Update = new SqlCommand($"UpdateFromRequestTypes {IDD},'{txt_Name.Text}'", sqlConnection);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek talep türünü seçiniz");
                }

            }
        }


        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

            TableReflesh(txt_Search_Name.Text);


        }
    }


}

