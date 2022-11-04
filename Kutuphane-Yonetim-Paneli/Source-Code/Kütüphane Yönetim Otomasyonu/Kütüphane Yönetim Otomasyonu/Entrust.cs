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
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class Entrust : Form
    {
        public int ActiveEmployeeID=2;
        public Entrust()
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
            //dataGridView2.Columns[1].Width = 300;
            dataGridView2.Columns[2].HeaderText = "Soyad";
        //    dataGridView2.Columns[2].Width = 300;
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
            dataGridView2.Columns["MemberState"].Visible = false;
            dataGridView2.Columns["DeletedInfo"].Visible = false;
            dataGridView2.Columns["DeletedDate"].Visible = false;
            dataGridView2.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView2.Columns["DeletedState"].Visible = false;

        }
        private void MembersTable(decimal TC)
        {
            SqlDataAdapter adpmember = new SqlDataAdapter($"select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where mS.MemberState='Aktif' and m.IdentityNumber like '%{TC}%'", sqlConnection);
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
            dataGridView2.Columns["MemberState"].Visible = false;
            dataGridView2.Columns["DeletedInfo"].Visible = false;
            dataGridView2.Columns["DeletedDate"].Visible = false;
            dataGridView2.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView2.Columns["DeletedState"].Visible = false;
        }
        private void MembersTable(string Name)
        {
            string MemberUpdateStr = $"select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where mS.MemberState='Aktif' and m.Name like '%'+@Text+'%' and DeletedState=0";
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand(MemberUpdateStr, sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Text", Name.ToString());
            DataTable dtmember = new DataTable();
            sqlConnection.Open();
            adp.Fill(dtmember);
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
            dataGridView2.Columns["MemberState"].Visible = false;
            dataGridView2.Columns["DeletedInfo"].Visible = false;
            dataGridView2.Columns["DeletedDate"].Visible = false;
            dataGridView2.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView2.Columns["DeletedState"].Visible = false;
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
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[9].HeaderText = "Raf Numarası";
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[11].Visible = false;
            dataGridView3.Columns[12].Visible = false;
            dataGridView3.Columns[13].HeaderText = "Yazar";
            dataGridView3.Columns[14].Visible = false;

        }
        private void BooksTable(string Raf)
        {
            SqlDataAdapter adpBooks = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID where State=1 and b.ShelfNumber like '%{Raf}%'", sqlConnection);
            /// BURADA İFADEYE ' gibi özel karakter koyarsa hata verecek ÇÖZMEYİ UNUTMA
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
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[9].HeaderText = "Raf Numarası";
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[11].Visible = false;
            dataGridView3.Columns[12].Visible = false;
            dataGridView3.Columns[13].HeaderText = "Yazar";
            dataGridView3.Columns[14].Visible = false;

        }
        private void FindBooksTableWithName(string Name)
        {
            SqlDataAdapter adpBooks = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID where State=1 and b.Name like '%{Name}%'", sqlConnection);
            /// BURADA İFADEYE ' gibi özel karakter koyarsa hata verecek ÇÖZMEYİ UNUTMA
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
            dataGridView3.Columns[7].Visible = false;
            dataGridView3.Columns[8].Visible = false;
            dataGridView3.Columns[9].HeaderText = "Raf Numarası";
            dataGridView3.Columns[10].Visible = false;
            dataGridView3.Columns[11].Visible = false;
            dataGridView3.Columns[12].Visible = false;
            dataGridView3.Columns[13].HeaderText = "Yazar";
            dataGridView3.Columns[14].Visible = false;

        }
       
        private void Members_Load(object sender, EventArgs e)
        {
            MembersTable();
            BooksTable();
           
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView3.AllowUserToAddRows = false; // satır ekleme iptal
          
            dataGridView3.Columns[1].Width = 150;
            dataGridView3.Columns[13].Width = 150;
            textBox2.MaxLength = 11;
            textBox1.MaxLength = 50;
        }

    


        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Member_ID.Text = (dataGridView2.CurrentRow.Cells["ID"].Value).ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Book_ID.Text = (dataGridView3.CurrentRow.Cells["ID"].Value).ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string TransactionsDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string BookDepositDate = DateTime.Now.AddDays(+14).ToString("yyyy-MM-dd HH:mm:ss");

            sqlConnection.Open();
            string EntrustAddStr = "insert into Transactions (Member_ID, EntrustedEmployee_ID, Book_ID, TransactionsDate, BookDepositDate, TransactionState) values(@Member_ID,@ActiveEmployeeID,@Book_ID,@TransactionsDate,@BookDepositDate,0)";
            SqlCommand komut = new SqlCommand(EntrustAddStr, sqlConnection);
            komut.Parameters.AddWithValue("@Member_ID", txt_Member_ID.Text);
            komut.Parameters.AddWithValue("@EntrustedEmployee_ID", ActiveEmployeeID);
            komut.Parameters.AddWithValue("@Book_ID", txt_Book_ID.Text);
            komut.Parameters.AddWithValue("@TransactionsDate", TransactionsDate);
            komut.Parameters.AddWithValue("@BookDepositDate", BookDepositDate);
            int eklenti = komut.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand Update = new SqlCommand($"Update Books set State=0 where ID={txt_Book_ID.Text}", sqlConnection);
            Update.ExecuteNonQuery();
            sqlConnection.Close();
         
            MembersTable();
            BooksTable();


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
              textBox1.Text = "";
            txt_Member_ID.Text = "";
            if (textBox2.Text!="")
            {
                MembersTable(Convert.ToDecimal(textBox2.Text));
            }
            else
            {
                MembersTable();
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            txt_Member_ID.Text = "";
            if (textBox1.Text != "")
            {
                MembersTable((textBox1.Text));
            }
            else
            {
                MembersTable();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = "";
            txt_Book_ID.Text = "";
            if (textBox6.Text != "")
            {
                BooksTable((textBox6.Text));
            }
            else
            {
                BooksTable();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
                textBox6.Text = "";
            txt_Book_ID.Text = "";
            if (textBox5.Text != "")
            {
                FindBooksTableWithName((textBox5.Text));
            }
            else
            {
                BooksTable();
            }
        }

      
    }


}

