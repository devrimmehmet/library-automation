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
    public partial class MoneyTransactions : Form
    {
        public MoneyTransactions()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int activeEmployeeID=0;
        private void MoneyTransaction()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Exes e inner join Employees em on em.ID=e.Employee_ID", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns["Contribution"].HeaderText = "Kullanım Amacı";
            dataGridView1.Columns["Contribution"].Width = 170;
            dataGridView1.Columns["Money"].HeaderText = "Miktarı";
            dataGridView1.Columns["Money"].Width = 100;
          
            dataGridView1.Columns["TransactionDate"].HeaderText = "Kullanım Tarihi";
            dataGridView1.Columns["TransactionDate"].Width = 150;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Personel Adı";
            dataGridView1.Columns["Name"].Width = 160;
            dataGridView1.Columns["Surname"].HeaderText = "Personel Soyadı";
            dataGridView1.Columns["Surname"].Width = 160;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Employee_ID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["Phone"].Visible = false;
            dataGridView1.Columns["IdentityNumber"].Visible = false;
            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["BirthDate"].Visible = false;
            dataGridView1.Columns["Permission_ID"].Visible = false;
            dataGridView1.Columns["Mail"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
           
        }
        decimal amount = 0;
        decimal amountFoundation = 0;
        decimal employeeContribution = 0;
        decimal bookContribution = 0;
        decimal nowAmountFoundation = 0;
        decimal nowEmployeeContribution = 0;
        decimal nowBookContribution = 0;
       private void startExes()
        {
            sqlConnection.Open();

            string Member = "select SUM(Punishment) as 'Toplam Ceza' from Punishments ";
            SqlCommand MemberCmd = new SqlCommand(Member, sqlConnection);
            SqlDataReader dr2 = MemberCmd.ExecuteReader();
            if (dr2.Read())
            {

                amount = Convert.ToDecimal(dr2["Toplam Ceza"]);
                sqlConnection.Close();
                total_Label.Text = amount.ToString() + " TL";
            }
            sqlConnection.Close();
            amountFoundation = amount / 3;
            employeeContribution = amount / 3;
            bookContribution = amount / 3;
            sqlConnection.Open();

            string Foundation = "select Sum(Money) as 'Foundation' from Exes where Contribution='Vakıf Katkı Payı'";
            SqlCommand Foundationcmd = new SqlCommand(Foundation, sqlConnection);
            SqlDataReader dr3 = Foundationcmd.ExecuteReader();
            if (dr3.Read())
            {

                nowAmountFoundation = amountFoundation - Convert.ToDecimal(dr3["Foundation"]);
                sqlConnection.Close();
                label11.Text = nowAmountFoundation.ToString() + " TL";
            }
            sqlConnection.Close();
            sqlConnection.Open();

            string Employee = "select Sum(Money) as 'Employee' from Exes where Contribution='Personel Katkı Payı'";
            SqlCommand EmployeeCmd = new SqlCommand(Employee, sqlConnection);
            SqlDataReader dr4 = EmployeeCmd.ExecuteReader();
            if (dr4.Read())
            {

                nowEmployeeContribution = employeeContribution - Convert.ToDecimal(dr4["Employee"]);
                sqlConnection.Close();
                label10.Text = nowEmployeeContribution.ToString() + " TL";
            }
            sqlConnection.Close();
            sqlConnection.Open();

            string Book = "select Sum(Money) as 'book' from Exes where Contribution='Kitap Katkı Payı'";
            SqlCommand BookCmd = new SqlCommand(Book, sqlConnection);
            SqlDataReader dr5 = BookCmd.ExecuteReader();
            if (dr5.Read())
            {

                nowBookContribution = bookContribution - Convert.ToDecimal(dr5["book"]);
                sqlConnection.Close();
                label7.Text = nowBookContribution.ToString() + " TL";
            }
            sqlConnection.Close();

            lbl_amountFoundation.Text = amountFoundation.ToString() + " TL";
            lbl_bookContribution.Text = employeeContribution.ToString() + " TL";
            lbl_employeeContribution.Text = bookContribution.ToString() + " TL";

        }
        private void MoneyTransactions_Load(object sender, EventArgs e)
        {
            Default();
            MoneyTransaction();
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            startExes();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {  
            if (mTB_money.Text=="")
            {
                MessageBox.Show("Para Kısmı Boş Geçilemez.");
            }
            {
                if (richTextBox1.Text=="")
                {
                    MessageBox.Show("Lütfen Detaylı Bir Açıklama Giriniz.");

                }
                else
                {
                    decimal money = Convert.ToDecimal((mTB_money.Text).Remove(0, 1));

                    sqlConnection.Open();
                    string exesAddStr = "insert into Exes (Contribution,Money,Employee_ID,Description) values (@Contribution,@Money,@Employee_ID,@Description)";
                    SqlCommand komut = new SqlCommand(exesAddStr, sqlConnection);
                    komut.Parameters.AddWithValue("@Contribution", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Money", money);
                    komut.Parameters.AddWithValue("@Employee_ID", activeEmployeeID);
                    komut.Parameters.AddWithValue("@Description", richTextBox1.Text);
                    int eklenti = komut.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (eklenti > 0)
                    {
                        MessageBox.Show("Katkı Payı Kullanıldı.");
                        startExes();
                        Default();
                    }
                    sqlConnection.Close();

                    MoneyTransaction();
                }
              
            }
        }
        private void Default()
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
            mTB_money.Text = "";
            comboBox1.SelectedIndex = 0;


        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBox2.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            decimal cubic = Convert.ToDecimal(mTB_money.Text);
            mTB_money.Text = string.Format("{0:c}", Convert.ToDecimal(cubic));
        }
        string RemoveCurrencyFormating(string input)
        {
            if (input.IndexOf(" ") != -1)
            {
                var money = input.Substring(0, input.IndexOf(" ") - 1);
                return String.Format("{0:D0}", money);
            }
            return ""; // Todo: add Error Handling
        }
        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)  && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ','
                && (sender as MaskedTextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            var tb = sender as MaskedTextBox;
            mTB_money.Text = RemoveCurrencyFormating(mTB_money.Text);
        }

      
    }
}

