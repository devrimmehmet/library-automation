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
    public partial class Permissions : Form
    {
        public Permissions()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Permissions", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Permission";
            dataGridView1.Columns[1].Width = 1000;
        }

        private void TableReflesh(string SearchTextName)
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Permissions where Permission like  '%{SearchTextName}%'", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Permission";
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
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Permission"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"select * from Permissions where Permission='{txt_Name.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu yetki zaten sisteme eklendi !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                SqlCommand komut = new SqlCommand($"insert into Permissions (Permission) values ('{txt_Name.Text}')", sqlConnection);

                int eklenti = komut.ExecuteNonQuery();
                sqlConnection.Close();

                if (eklenti > 0)
                {
                    MessageBox.Show("Yetki Sisteme Eklendi.");
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Yetki eklenemedi.");
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
                SqlCommand Sil = new SqlCommand($"DeleteFromPermissions {IDD}", sqlConnection);
                Sil.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek Yetkiyi seçiniz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand Member = new SqlCommand($"select * from Permissions where Permission='{txt_Name.Text}'", sqlConnection);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu yetki zaten sistemde var bu güncelleme işlemini yapamazsınız !!!");
                sqlConnection.Close();

            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();

                if (txt_Id.Text != "")
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);

                    SqlCommand Update = new SqlCommand($"UpdateFromPermissions {IDD},'{txt_Name.Text}'", sqlConnection);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek yetkiyi seçiniz");
                }

            }
        }


        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

            TableReflesh(txt_Search_Name.Text);


        }
    }


}

