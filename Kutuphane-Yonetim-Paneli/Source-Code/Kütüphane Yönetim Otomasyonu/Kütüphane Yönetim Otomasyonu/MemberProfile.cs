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
    public partial class MemberProfile : Form
    {
        public MemberProfile()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int ActiveMemberID;
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Members where ID={ActiveMemberID}", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();   
            txt_Id.Text = dt.Rows[0]["ID"].ToString();
            txt_Name.Text = dt.Rows[0]["Name"].ToString();
            txt_Surname.Text = dt.Rows[0]["Surname"].ToString(); 
            comboBox1.Text = dt.Rows[0]["Gender"].ToString();
            dateTimePicker1.Text = dt.Rows[0]["BirthDate"].ToString();
            txt_Phone.Text = dt.Rows[0]["Phone"].ToString();
            txt_TC.Text = dt.Rows[0]["IdentityNumber"].ToString(); 
            txt_Mail.Text = dt.Rows[0]["Mail"].ToString();
            rTxt_Address.Text = dt.Rows[0]["Address"].ToString(); 
            dateTimePicker2.Text = dt.Rows[0]["MemberDate"].ToString(); 
            txt_Password.Text = dt.Rows[0]["Password"].ToString(); 
        }
        private void ReadBooks()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Transactions t inner join Books b on b.ID=t.Book_ID where Member_ID={ActiveMemberID} and TransactionState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            sqlConnection.Close();
        }

        private void Members_Load(object sender, EventArgs e)
        {
            TableReflesh();
            ReadBooks();
            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            rTxt_Address.MaxLength = 200;
            txt_Password.MaxLength = 50;     
        }

     

     
        private void button3_Click(object sender, EventArgs e)
        {

            if (txt_Phone.TextLength > 10)
            {
                if (!this.txt_Mail.Text.Contains('@') || !this.txt_Mail.Text.Contains('.'))
                {
                    MessageBox.Show("Lütfen Geçerli Bir Mail Adresi giriniz.", "Geçersiz Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand Update = new SqlCommand();
                    Update.Connection = sqlConnection;
                    Update.CommandText = "UpdateFromMembersForMember"; //stoured procedure'un saklandığı yer.
                    Update.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.
                    Update.Parameters.AddWithValue("@ID", ActiveMemberID);
                    Update.Parameters.AddWithValue("@Name", txt_Name.Text);
                    Update.Parameters.AddWithValue("@Surname", txt_Surname.Text);
                    Update.Parameters.AddWithValue("@Gender", comboBox1.Text);
                    Update.Parameters.AddWithValue("@BirthDate", dateTimePicker1.Text);
                    Update.Parameters.AddWithValue("@Phone", txt_Phone.Text);
                    Update.Parameters.AddWithValue("@Mail", txt_Mail.Text);
                    Update.Parameters.AddWithValue("@Address", rTxt_Address.Text);
                    Update.Parameters.AddWithValue("@Password", txt_Password.Text);
                    Update.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh(); 
                }
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Telefon Numarası giriniz.", "Geçersiz Telefon", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }      
    }
}

