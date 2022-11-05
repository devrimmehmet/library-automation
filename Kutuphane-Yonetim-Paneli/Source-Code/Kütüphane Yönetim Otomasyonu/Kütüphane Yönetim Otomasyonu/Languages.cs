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
    public partial class Languages : Form
    {
        public Languages()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Languages where DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns["Language"].HeaderText = "Diller";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].Width = 1000;
        }
        private void Default()
        {
            txt_Id.Text = "";
            txt_Language.Text = "";
        }
        private void TableReflesh(string SearchTextName)
        {

            string SearchLanguage = "select * from Languages where Language like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(SearchLanguage, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns["Language"].HeaderText = "Diller";
            dataGridView1.Columns[1].Width = 1000;
            dataGridView1.Columns[1].Width = 1000;
            Default();


        }
        private void Members_Load(object sender, EventArgs e)
        {


            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            Default();
            TableReflesh();

            txt_Language.MaxLength = 20;

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Language.Text = dataGridView1.CurrentRow.Cells["Language"].Value.ToString();

        }
        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

            TableReflesh(txt_Search_Name.Text);


        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string MemberStr = "select * from Languages where Language=@ID and DeletedState=0";
            SqlCommand Member = new SqlCommand(MemberStr, sqlConnection);
            Member.Parameters.AddWithValue("@ID", txt_Language.Text);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu dil zaten sisteme eklendi !!!");
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                string LanguageStr = "insert into Languages (Language) values (@Language)";
                SqlCommand Language = new SqlCommand(LanguageStr, sqlConnection);
                Language.Parameters.AddWithValue("@Language", txt_Language.Text);
                int eklenti = Language.ExecuteNonQuery();
                sqlConnection.Close();

                if (eklenti > 0)
                {
                    MessageBox.Show("Dil Sisteme Eklendi.");
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Dil eklenemedi.");
                }
                sqlConnection.Close();
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                if (MessageBox.Show("Dili Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    sqlConnection.Open();
                    SqlCommand Sil = new SqlCommand($"DeleteFromLanguages {IDD}", sqlConnection);
                    Sil.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Dil Silme İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek Dili seçiniz");
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string MemberStr = "select * from Languages where Language=@ID and DeletedState=0";
            SqlCommand Member = new SqlCommand(MemberStr, sqlConnection);
            Member.Parameters.AddWithValue("@ID", txt_Language.Text);
            SqlDataReader dr2 = Member.ExecuteReader();
            if (dr2.Read())
            {
                MessageBox.Show("Bu dil zaten sistemde var bu güncelleme işlemini yapamazsınız !!!");
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                sqlConnection.Open();
                if (txt_Id.Text != "")
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    string UpdateStr = "UpdateFromLanguages @ID,@Language";
                    SqlCommand Update = new SqlCommand(UpdateStr, sqlConnection);
                    Update.Parameters.AddWithValue("@ID", IDD);
                    Update.Parameters.AddWithValue("@Language", txt_Language.Text);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek dili seçiniz");
                }
            }
        }
    }
}

