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
        public void TableReflesh()
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
            string State = dt.Rows[0]["Member_State_ID"].ToString();
            if (State=="1")
            {
                cB_State.Text = "Aktif";
            }else if (State=="2")
            {
                cB_State.Text = "Pasif";
            }else if (State=="3")
            {
                cB_State.Text = "Cezalı";
            }


        }
        private void ReadBooks()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select b.Name as 'Kitap Adı' ,a.NameSurname as 'Yazarı' from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID={ActiveMemberID} and TransactionState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            sqlConnection.Close();
           dataGridView2.Columns["Kitap Adı"].Width = 250;
            dataGridView2.Columns["Yazarı"].Width = 200;
            
        }
        private void MyRequest()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Requests r inner join RequestTypes rT on rt.ID=r.RequestType_ID where Member_ID=@Member_ID", sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Member_ID",ActiveMemberID);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView4.DataSource = dt;
            sqlConnection.Close();
            dataGridView4.Columns["ID"].Visible = false;
            dataGridView4.Columns["RequestType_ID"].Visible = false;
            dataGridView4.Columns["RequestState"].Visible = false;
            dataGridView4.Columns["Member_ID"].Visible = false;
            dataGridView4.Columns["ID1"].Visible = false;
            dataGridView4.Columns["Request"].HeaderText = "Talebim";
            dataGridView4.Columns["Request"].Width = 250;
            dataGridView4.Columns["RequestNote"].HeaderText = "Talep Sonucu";
            dataGridView4.Columns["RequestNote"].Width = 340;
            dataGridView4.Columns["RequestOpenDate"].HeaderText = "Talep Oluşturma Tarihi";
            dataGridView4.Columns["RequestOpenDate"].Width = 150;
            dataGridView4.Columns["RequestCloseDate"].HeaderText = "Talep Sonuçlanma Tarihi";
            dataGridView4.Columns["RequestCloseDate"].Width =150;
            dataGridView4.Columns["RequestType"].HeaderText = "Talep Türü";
            dataGridView4.Columns["RequestType"].Width = 200;
        }
        private void NowReadBooks()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select b.Name as 'Kitap Adı' ,a.NameSurname as 'Yazarı' from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID={ActiveMemberID} and TransactionState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView3.DataSource = dt;
            sqlConnection.Close();
            dataGridView3.Columns["Kitap Adı"].Width = 250;
            dataGridView3.Columns["Yazarı"].Width = 200;

        }
        private void Members_Load(object sender, EventArgs e)
        {
            MyRequest();
            TableReflesh();
            ReadBooks();
            NowReadBooks();
            txt_Name.MaxLength = 50;
            txt_Surname.MaxLength = 50;
            txt_Phone.MaxLength = 11;
            txt_Mail.MaxLength = 50;
            rTxt_Address.MaxLength = 200;
            txt_Password.MaxLength = 50;
            sqlConnection.Open();
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView3.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView4.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView4.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView4.AllowUserToAddRows = false; // satır ekleme iptal
            ActiveRequestFind();

        }


        int ActiveRequest = 0;
        private void ActiveRequestFind() {
            if (sqlConnection.State==ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
           
            string updateInfo = $"select Count(RequestType_ID) as'count' from Requests where RequestState=0 and Member_ID=@MemberID and RequestType_ID=4 group by RequestType_ID";
            SqlCommand MemberCmd = new SqlCommand(updateInfo, sqlConnection);
            MemberCmd.Parameters.AddWithValue("@MemberID", ActiveMemberID);
            SqlDataReader dr2 = MemberCmd.ExecuteReader();
            if (dr2.Read())
            {
                ActiveRequest = Convert.ToInt32(dr2["count"]);
                sqlConnection.Close();
               // MessageBox.Show(ActiveRequest.ToString());

            }
            sqlConnection.Close();
            if (ActiveRequest > 0)
            {
                button3.Enabled = false;
                button3.Text = "Güncelleme Onayı Bekleniyor";
            }
            sqlConnection.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
           



              SqlDataAdapter adp = new SqlDataAdapter($"select * from Members where ID={ActiveMemberID}", sqlConnection);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                sqlConnection.Close();
                string NameInfo = dt.Rows[0]["Name"].ToString();
                string SurnameInfo = dt.Rows[0]["Surname"].ToString();
                string Gender = dt.Rows[0]["Gender"].ToString();
                string BirthDay = dt.Rows[0]["BirthDate"].ToString();
                string Phone = dt.Rows[0]["Phone"].ToString();
                string Mail = dt.Rows[0]["Mail"].ToString();
                string Address = dt.Rows[0]["Address"].ToString();

                string request = $"ID: {ActiveMemberID} \n" +
                   $"Adı: {NameInfo} \nTalep Edilen Ad: {txt_Name.Text} \n" +
                   $"Soyadı: {SurnameInfo} \nTalep Edilen Soyad: {txt_Surname.Text} \n" +
                   $"Cinsiyet: {Gender} \nTalep Edilen Cinsiyet: {comboBox1.Text} \n" +
                   $"Doğum Tarihi: {BirthDay} \nTalep Edilen Doğum Tarihi: {dateTimePicker1.Text} \n" +
                   $"Telefon Numarası: {Phone} \nTalep Edilen Telefon Numarası: {txt_Phone.Text} \n" +
                   $"Mail: {Mail} \nTalep Edilen Mail: {txt_Mail.Text} \n" +
                   $"Adres: {Address} \nTalep Edilen Adres: {rTxt_Address.Text} \n";


                sqlConnection.Open();
                SqlCommand Update = new SqlCommand();
                Update.Connection = sqlConnection;
                Update.CommandText = "AddRequestUpdateProfile"; //stoured procedure'un saklandığı yer.
                Update.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.

                Update.Parameters.AddWithValue("@Member_ID", ActiveMemberID);
                Update.Parameters.AddWithValue("@Request", request);
                Update.ExecuteNonQuery();
                sqlConnection.Close();
                TableReflesh();
            ActiveRequestFind();


        }

        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btn_UpdatePassword_Click(object sender, EventArgs e)
        {
           
                    MemberUpdatePassword UpdatePassword = new MemberUpdatePassword();
                    UpdatePassword.ActiveMemberID = Convert.ToInt32(txt_Id.Text);
                    UpdatePassword.ShowDialog();
             //       Default();
                    TableReflesh();
               
        }

        private void cB_State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         

            string Request = (dataGridView4.CurrentRow.Cells["Request"].Value).ToString();
            string RequestNote = dataGridView4.CurrentRow.Cells["RequestNote"].Value.ToString();
            string RequestOpenDate = dataGridView4.CurrentRow.Cells["RequestOpenDate"].Value.ToString();
            string RequestCloseDate = (dataGridView4.CurrentRow.Cells["RequestCloseDate"].Value).ToString();
            string RequestType = dataGridView4.CurrentRow.Cells["RequestType"].Value.ToString();
            string RequestMsgShowBox = $"Talebimin Sonucu: {RequestNote}\nTalebim: {Request}\nTalep Tarihi: {RequestOpenDate}";
            MessageBox.Show(RequestMsgShowBox, RequestType+" "+ RequestCloseDate);
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for (int i = 0; i < dataGridView4.Rows.Count; i++)
            //{
            //    MessageBox.Show((dataGridView4.Rows[i].Cells["RequestCloseDate"].Value).ToString());
            //    DataGridViewCellStyle renk = new DataGridViewCellStyle();
            //    if ((dataGridView4.Rows[i].Cells["RequestCloseDate"].Value).ToString() != "")
            //    {
            //        renk.BackColor = Color.YellowGreen;
            //    }else if ((dataGridView4.Rows[i].Cells["RequestCloseDate"].Value).ToString() == "")
            //    {
            //        renk.BackColor = Color.Red;
            //        renk.ForeColor = Color.White;
            //    }
            //    dataGridView4.Rows[i].DefaultCellStyle = renk;
            //}
        }

        private void btn_AddRequest_Click(object sender, EventArgs e)
        {
            MemberAddRequest deleteWithDescriptionMembers = new MemberAddRequest();
            deleteWithDescriptionMembers.ActiveMemberID = ActiveMemberID;
            deleteWithDescriptionMembers.ShowDialog();
           
            TableReflesh();
        }
    }
}

