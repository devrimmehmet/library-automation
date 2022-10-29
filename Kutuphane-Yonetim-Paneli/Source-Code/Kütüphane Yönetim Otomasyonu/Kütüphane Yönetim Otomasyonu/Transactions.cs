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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        private void MembersTable()
        {
            SqlDataAdapter adpmember = new SqlDataAdapter("select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where mS.MemberState='Aktif' ", sqlConnection);
            DataTable dtmember = new DataTable();
            sqlConnection.Open();
            adpmember.Fill(dtmember);
            dataGridView2.DataSource = dtmember;

            sqlConnection.Close();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Ad";
            dataGridView2.Columns[2].HeaderText = "Soyad";
            dataGridView2.Columns[3].Visible = false;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].HeaderText = "TC";
            dataGridView2.Columns[7].Visible = false;
            dataGridView2.Columns[8].Visible = false;
            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns["Member_State_ID"].Visible = false;
            dataGridView2.Columns["ID1"].Visible = false;
            dataGridView2.Columns["MemberState"].Visible =false;
        }
        private void BooksTable()
        {
            SqlDataAdapter adpBooks = new SqlDataAdapter("select * from Books b inner join Authors a on a.ID=b.Author_ID where State=1 ", sqlConnection);
            DataTable dtBooks = new DataTable();
            sqlConnection.Open();
            adpBooks.Fill(dtBooks);
            dataGridView3.DataSource = dtBooks;

            sqlConnection.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Ad";
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[3].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            dataGridView3.Columns[5].Visible = false;
            dataGridView3.Columns[6].Visible = false;
            dataGridView3.Columns[7].Visible =false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[9].HeaderText = "Raf Numarası";
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[11].Visible = false;
            dataGridView3.Columns[12].Visible = false;
            dataGridView3.Columns[13].HeaderText = "Yazar";
            dataGridView3.Columns[14].Visible = false;
           
        }
        private void TransactionsTable()
        {
            SqlDataAdapter adpTransactions = new SqlDataAdapter("select * from Transactions ", sqlConnection);
            DataTable dtTransactions = new DataTable();
            sqlConnection.Open();
            adpTransactions.Fill(dtTransactions);
            dataGridView1.DataSource = dtTransactions;

            sqlConnection.Close();
            //dataGridView3.Columns[0].HeaderText = "ID";
            //dataGridView3.Columns[1].HeaderText = "Ad";
            //dataGridView3.Columns[2].Visible = false;
            //dataGridView3.Columns[3].Visible = false;
            //dataGridView3.Columns[4].Visible = false;
            //dataGridView3.Columns[5].Visible = false;
            //dataGridView3.Columns[6].Visible = false;
            //dataGridView3.Columns[7].Visible = false;
            //dataGridView3.Columns[8].Visible = false;
            //dataGridView3.Columns[9].HeaderText = "Raf Numarası";
            //dataGridView3.Columns[10].Visible = false;
            //dataGridView3.Columns[11].Visible = false;
            //dataGridView3.Columns[12].Visible = false;
            //dataGridView3.Columns[13].HeaderText = "Yazar";
            //dataGridView3.Columns[14].Visible = false;

        }
        private void TableSearchShelf(string SearchTextShelfNumber)
        {
     

        }
        private void TableReflesh(string SearchTextName)
        {
         

        }
        private void Members_Load(object sender, EventArgs e)
        {
            MembersTable();
            BooksTable();
            TransactionsTable();
       
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal

            dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView3.AllowUserToAddRows = false; // satır ekleme iptal

            SqlCommand komut1 = new SqlCommand("SELECT TransactionType FROM TransactionTypes", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            cB_Transaction_Type.Items.Clear();
            while (dr1.Read())
            {
                cB_Transaction_Type.Items.Add(dr1["TransactionType"]);
            }
            sqlConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
          
         
        }



        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
          //  txt_Search_Name.Text = "";
          
            //    TableSearchShelf(txt_Search_Shelf.Text);
            

        }

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
          //  txt_Search_Shelf.Text = "";
           // TableReflesh(txt_Search_Name.Text);


        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
          
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Member_ID.Text = (dataGridView2.CurrentRow.Cells["ID"].Value).ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Book_ID.Text = (dataGridView3.CurrentRow.Cells["ID"].Value).ToString();
        }
    }


}

