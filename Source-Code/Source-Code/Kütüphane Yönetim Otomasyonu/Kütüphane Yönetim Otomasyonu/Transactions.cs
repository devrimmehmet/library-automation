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
    public partial class Transactions : Form
    {
        public int ActiveEmployeeID=2;
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
            dataGridView2.Columns["MemberState"].Visible = false;
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
        }
        private void MembersTable(string Name)
        {
            SqlDataAdapter adpmember = new SqlDataAdapter($"select * from Members m inner join MemberStates mS on mS.ID=m.Member_State_ID where mS.MemberState='Aktif' and m.Name like '%{Name}%'", sqlConnection);
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
        private void TransactionsTable()
        {
            SqlDataAdapter adpTransactions = new SqlDataAdapter("select * from Transactions t inner join Members m on m.ID=t.Member_ID  inner join Books b on b.ID=t.Book_ID where TransactionState=0", sqlConnection);
            DataTable dtTransactions = new DataTable();
            sqlConnection.Open();
            adpTransactions.Fill(dtTransactions);
            dataGridView1.DataSource = dtTransactions;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Verilme Tarihi";
            dataGridView1.Columns[6].HeaderText = "İade Tarihi";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Üye Adı";
            dataGridView1.Columns[12].HeaderText = "Üye Soyadı";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kitabın Adı";
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[33].Visible = false;
           
        }
        private void FindMemberNameTransactionsTable(string MemberName)
        {
            SqlDataAdapter adpTransactions = new SqlDataAdapter($"select * from Transactions t inner join Members m on m.ID=t.Member_ID  inner join Books b on b.ID=t.Book_ID where TransactionState=0 and m.Name like '%{MemberName}%'", sqlConnection);
            DataTable dtTransactions = new DataTable();
            sqlConnection.Open();
            adpTransactions.Fill(dtTransactions);
            dataGridView1.DataSource = dtTransactions;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Verilme Tarihi";
            dataGridView1.Columns[6].HeaderText = "İade Tarihi";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Üye Adı";
            dataGridView1.Columns[12].HeaderText = "Üye Soyadı";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kitabın Adı";
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[33].Visible = false;

        }
        private void FindBookNameTransactionsTable(string BookName)
        {
            SqlDataAdapter adpTransactions = new SqlDataAdapter($"select * from Transactions t inner join Members m on m.ID=t.Member_ID  inner join Books b on b.ID=t.Book_ID where TransactionState=0 and b.Name like '%{BookName}%' ", sqlConnection);
            DataTable dtTransactions = new DataTable();
            sqlConnection.Open();
            adpTransactions.Fill(dtTransactions);
            dataGridView1.DataSource = dtTransactions;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Verilme Tarihi";
            dataGridView1.Columns[6].HeaderText = "İade Tarihi";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].HeaderText = "Üye Adı";
            dataGridView1.Columns[12].HeaderText = "Üye Soyadı";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].HeaderText = "Kitabın Adı";
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].Visible = false;
            dataGridView1.Columns[28].Visible = false;
            dataGridView1.Columns[29].Visible = false;
            dataGridView1.Columns[30].Visible = false;
            dataGridView1.Columns[31].Visible = false;
            dataGridView1.Columns[32].Visible = false;
            dataGridView1.Columns[33].Visible = false;

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
            dataGridView1.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;
            dataGridView3.Columns[1].Width = 150;
            dataGridView3.Columns[13].Width = 150;

            textBox2.MaxLength = 11;
            textBox1.MaxLength = 50;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells["Book_ID"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["TransactionNote"].Value.ToString();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string TransactionsDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string BookDepositDate = DateTime.Now.AddDays(+14).ToString("yyyy-MM-dd HH:mm:ss");
          
            sqlConnection.Open();
            SqlCommand Add = new SqlCommand($"insert into Transactions (Member_ID, EntrustedEmployee_ID, Book_ID, TransactionsDate, BookDepositDate, TransactionState) values({txt_Member_ID.Text},{ActiveEmployeeID},{txt_Book_ID.Text},'{TransactionsDate}','{BookDepositDate}',0)", sqlConnection);
            Add.ExecuteNonQuery();
            SqlCommand Update = new SqlCommand($"Update Books set State=0 where ID={txt_Book_ID.Text}", sqlConnection);
            Update.ExecuteNonQuery();
            sqlConnection.Close();
            TransactionsTable();
            MembersTable();
            BooksTable();


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string BookReturnDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
          
            sqlConnection.Open();
            SqlCommand UpdateTransactions = new SqlCommand();
            UpdateTransactions.Connection = sqlConnection;
            UpdateTransactions.CommandText = "UpdateFromTransactions"; //stoured procedure'un saklandığı yer.
            UpdateTransactions.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            UpdateTransactions.Parameters.AddWithValue("@ReturnEmployee_ID", ActiveEmployeeID);
            UpdateTransactions.Parameters.AddWithValue("@BookReturnDate", BookReturnDate);
            UpdateTransactions.Parameters.AddWithValue("@TransactionNote", richTextBox1.Text);
            UpdateTransactions.Parameters.AddWithValue("@ID", txt_Id.Text);
            UpdateTransactions.ExecuteNonQuery();
            SqlCommand UpdateBooks = new SqlCommand($"Update Books set State=1 where ID={textBox3.Text}", sqlConnection);
            UpdateBooks.ExecuteNonQuery();
            sqlConnection.Close();
            richTextBox1.Text = "";
            TransactionsTable();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            string BookDepositDate = DateTime.Now.AddDays(+14).ToString("yyyy-MM-dd HH:mm:ss");
            sqlConnection.Open();
            SqlCommand UpdateTransactions = new SqlCommand();
            UpdateTransactions.Connection = sqlConnection;
            UpdateTransactions.CommandText = "UpdateFromDateTransactions"; //stoured procedure'un saklandığı yer.
            UpdateTransactions.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
            UpdateTransactions.Parameters.AddWithValue("@TransactionNote", richTextBox1.Text);
            UpdateTransactions.Parameters.AddWithValue("@BookDepositDate", BookDepositDate);
            UpdateTransactions.Parameters.AddWithValue("@ID", txt_Id.Text);
            UpdateTransactions.ExecuteNonQuery();
            sqlConnection.Close();
            richTextBox1.Text = "";
            TransactionsTable();
            MembersTable();
            BooksTable();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            if (textBox7.Text != "")
            {
                FindBookNameTransactionsTable(textBox7.Text);
            }
            else
            {
                TransactionsTable();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = "";
            if (textBox4.Text!="")
            {
                FindMemberNameTransactionsTable(textBox4.Text);
            }
            else
            {
                TransactionsTable();
            }
        }
    }


}

