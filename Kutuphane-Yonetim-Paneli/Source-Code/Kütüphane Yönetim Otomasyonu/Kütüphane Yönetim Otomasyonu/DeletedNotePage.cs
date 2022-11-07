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
    public partial class DeletedNotePage : Form
    {
        public DeletedNotePage()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int ActiveMemberID;
        public void DeletedMembers()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select m.Name+' '+m.Surname as 'Ad-Soyad',m.IdentityNumber as 'TC',m.DeletedInfo as 'Silinme Gerekçesi',m.DeletedDate as 'Silinme Tarihi', e.Name+ ' '+ e.Surname as 'Silen Personel'  from Members m inner join Employees e on e.ID=m.DeletedEmployeeID where m.DeletedState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns["Silinme Gerekçesi"].Visible = false;
            dataGridView1.Columns["TC"].Width = 125;
            dataGridView1.Columns["Silinme Tarihi"].Width =150;
         
        }
        private void DeletedBooks()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select m.Name as 'Ad',m.ID as 'Kitap ID',m.DeletedInfo as 'Silinme Gerekçesi',m.DeletedDate as 'Silinme Tarihi', e.Name+ ' '+ e.Surname as 'Silen Personel'  from Books m inner join Employees e on e.ID=m.DeletedEmployeeID where m.DeletedState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView3.DataSource = dt;
            sqlConnection.Close();
            dataGridView3.Columns["Silinme Gerekçesi"].Visible = false;
            dataGridView3.Columns["Kitap ID"].Width = 80;
            dataGridView3.Columns["Silinme Tarihi"].Width = 150;
        }
        private void DeletedEmployee()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select m.Name+' '+m.Surname as 'Ad-Soyad',m.IdentityNumber as 'Silinen Personel TC',m.DeletedInfo as 'Silinme Gerekçesi',m.DeletedDate as 'Silinme Tarihi', e.Name+ ' '+ e.Surname as 'Silen Personel'  from Employees m inner join Employees e on e.ID=m.DeletedEmployeeID where m.DeletedState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            sqlConnection.Close();
            dataGridView2.Columns["Silinme Gerekçesi"].Visible = false;
            dataGridView2.Columns["Silinen Personel TC"].Width = 125;
            dataGridView2.Columns["Silinme Tarihi"].Width = 150;
        }
 
        private void Members_Load(object sender, EventArgs e)
        {
            DeletedBooks();
            DeletedEmployee();
            DeletedMembers();
           
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView3.AllowUserToAddRows = false; // satır ekleme iptal

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            rTB_Comment.Text = dataGridView1.CurrentRow.Cells["Silinme Gerekçesi"].Value.ToString();
           
        }



     

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox2.Text = dataGridView3.CurrentRow.Cells["Silinme Gerekçesi"].Value.ToString();

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox1.Text = dataGridView2.CurrentRow.Cells["Silinme Gerekçesi"].Value.ToString();

        }
    }
}

