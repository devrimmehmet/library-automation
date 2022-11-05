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
    public partial class ReturnExtendTime : Form
    {
        public int ActiveEmployeeID = 2;
        public ReturnExtendTime()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");

        private void TransactionsTable()
        {
            SqlDataAdapter adpTransactions = new SqlDataAdapter("select * from Transactions t inner join Members m on m.ID=t.Member_ID  inner join Books b on b.ID=t.Book_ID where TransactionState=0", sqlConnection);
            DataTable dtTransactions = new DataTable();
            sqlConnection.Open();
            adpTransactions.Fill(dtTransactions);
            dataGridView1.DataSource = dtTransactions;

            sqlConnection.Close();
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Member_ID"].Visible = false;
            dataGridView1.Columns["EntrustedEmployee_ID"].Visible = false;
            dataGridView1.Columns["ReturnEmployee_ID"].Visible = false;
            dataGridView1.Columns["Book_ID"].Visible = false;
            dataGridView1.Columns["TransactionsDate"].HeaderText = "Emanet Tarihi";
            dataGridView1.Columns["TransactionsDate"].Width = 140;
            dataGridView1.Columns["BookDepositDate"].HeaderText = "İade Tarihi";
            dataGridView1.Columns["BookDepositDate"].Width = 150;
            dataGridView1.Columns["IdentityNumber"].HeaderText = "TC";
            dataGridView1.Columns["IdentityNumber"].Width = 130;
            dataGridView1.Columns["BookReturnDate"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["TransactionState"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Adı";
            dataGridView1.Columns["Name"].Width = 130;
            dataGridView1.Columns["Surname"].HeaderText = "Soyadı";
            dataGridView1.Columns["Surname"].Width = 130;
            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["BirthDate"].Visible = false;
            dataGridView1.Columns["Member_State_ID"].Visible = false;
            dataGridView1.Columns["MemberDate"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["ID2"].Visible = false;
            dataGridView1.Columns["Name1"].HeaderText = "Kitabın Adı";
            dataGridView1.Columns["Name1"].Width = 330;
            dataGridView1.Columns["Author_ID"].Visible = false;
            dataGridView1.Columns["PublicationYear"].Visible = false;
            dataGridView1.Columns["NumberOfPages"].Visible = false;
            dataGridView1.Columns["Language_ID"].Visible = false;
            dataGridView1.Columns["Publisher_ID"].Visible = false;
            dataGridView1.Columns["State"].Visible = false;
            dataGridView1.Columns["Category_ID"].Visible = false;
            dataGridView1.Columns["Photo"].Visible = false;
            dataGridView1.Columns["DeletedState1"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["ShelfNumber"].HeaderText = "Raf";
            dataGridView1.Columns["ShelfNumber"].Width = 90;
            dataGridView1.Columns["Phone"].Visible = false;
            dataGridView1.Columns["TransactionNote"].Visible = false;
            dataGridView1.Columns["Mail"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["DeletedInfo1"].Visible = false;
            dataGridView1.Columns["DeletedDate1"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID1"].Visible = false;

            sqlConnection.Close();
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

            TransactionsTable();
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Id.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Book_ID"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["TransactionNote"].Value.ToString();
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



        private void button2_Click_1(object sender, EventArgs e)
        {
            if (txt_Id.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show($"Seçim Yapmadınız.", "Seçim Yapılmadı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            
            DateTime BookReturnDatePunisment = DateTime.Now;
            DateTime BookDepositDatePunisment = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BookDepositDate"].Value);
            int daysPunishment = 5;
            TimeSpan tS = BookReturnDatePunisment - BookDepositDatePunisment;
            if (tS.Days > 0)
            {
               int totalPunishment = tS.Days*daysPunishment;
                DialogResult result2 = MessageBox.Show($"Üye İade Gününü Geçirmiştir ödeme Yapması Gereklidir. \n Toplam {totalPunishment} TL ödeme yapılmalıdır. \n Ödeme yapılacak mı?", "Ödeme Bildirimi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result2 == DialogResult.Yes)
                {
                    string BookReturnDatePunishment = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    sqlConnection.Open();
                    SqlCommand UpdateTransactionsPunishment = new SqlCommand();
                    UpdateTransactionsPunishment.Connection = sqlConnection;
                    UpdateTransactionsPunishment.CommandText = "UpdateFromTransactions"; //stoured procedure'un saklandığı yer.
                    UpdateTransactionsPunishment.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                    UpdateTransactionsPunishment.Parameters.AddWithValue("@ReturnEmployee_ID", ActiveEmployeeID);
                    UpdateTransactionsPunishment.Parameters.AddWithValue("@BookReturnDate", BookReturnDatePunishment);
                    UpdateTransactionsPunishment.Parameters.AddWithValue("@TransactionNote", richTextBox1.Text);
                    UpdateTransactionsPunishment.Parameters.AddWithValue("@ID", txt_Id.Text);
                    UpdateTransactionsPunishment.ExecuteNonQuery();
                    SqlCommand UpdateBooksPunishment = new SqlCommand($"Update Books set State=1 where ID={textBox3.Text}", sqlConnection);
                    UpdateBooksPunishment.ExecuteNonQuery();
                    SqlCommand AddPunishment = new SqlCommand($"Insert Into Punishments (Member_ID,Paid_Employee_ID,Punishment) values (@Member_ID,@Paid_Employee_ID,@Punishment)", sqlConnection);
                    int currentMember= Convert.ToInt32(dataGridView1.CurrentRow.Cells["Member_ID"].Value);
                    AddPunishment.Parameters.AddWithValue("@Member_ID", currentMember);
                    AddPunishment.Parameters.AddWithValue("@Paid_Employee_ID", ActiveEmployeeID);
                    AddPunishment.Parameters.AddWithValue("@Punishment", totalPunishment);
                    AddPunishment.ExecuteNonQuery();
                    sqlConnection.Close();
                    richTextBox1.Text = "";
                    TransactionsTable();
                }
                else if (result2 == DialogResult.No)
                {
                    MessageBox.Show($"Borç ödeme yapılmadığı her gün {daysPunishment} TL artmaya devam edecektir.", "Ödeme Bildirimi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
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
            }
            }
        }



        private void button3_Click_1(object sender, EventArgs e)
        {

            sqlConnection.Open();
            string ExtendTime = "select TransactionsDate,BookDepositDate from Transactions where ID=@ID";
            SqlCommand ExtendTimeCmd = new SqlCommand(ExtendTime, sqlConnection);
            ExtendTimeCmd.Parameters.AddWithValue("@ID", txt_Id.Text);
            SqlDataReader dr = ExtendTimeCmd.ExecuteReader();
            TimeSpan tS = TimeSpan.FromDays(14);
            if (dr.Read())
            {

                DateTime TransactionDateExtendTime = Convert.ToDateTime(dr["TransactionsDate"]);
                DateTime BookDepositDateExtendTime = Convert.ToDateTime(dr["BookDepositDate"]);
                sqlConnection.Close();
                tS = BookDepositDateExtendTime - TransactionDateExtendTime;

            }
            if (tS.Days == 14)
            {
                sqlConnection.Close();
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
            }
            else
            {
                MessageBox.Show("Bu İşlem İçin Süre Uzatma İşlemi Daha Önce Yapılmıştır.", "2. Defa Gün Uzatma Talebi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
            if (textBox4.Text != "")
            {
                FindMemberNameTransactionsTable(textBox4.Text);
            }
            else
            {
                TransactionsTable();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DateTime BookReturnDate = DateTime.Now;
            DateTime BookDepositDate = DateTime.Now;
            TimeSpan tS = BookReturnDate - BookDepositDate;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();

                BookDepositDate = Convert.ToDateTime(dataGridView1.Rows[i].Cells["BookDepositDate"].Value);
                tS = BookReturnDate - BookDepositDate;
                if (tS.Days > 0)
                {
                    if (sqlConnection.State==ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    
                    SqlCommand UpdateMemberStatus = new SqlCommand($"Update Members set Member_State_ID=3 where ID={Convert.ToInt32(dataGridView1.Rows[i].Cells["Member_ID"].Value)}", sqlConnection);
                    UpdateMemberStatus.ExecuteNonQuery();
                    sqlConnection.Close();
                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;

                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }

        }
    }


}

