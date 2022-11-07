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
    public partial class RequestsAndComments : Form
    {
        public RequestsAndComments()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
        public int ActiveMemberID;
        public void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from BookComments BC inner join Books b on b.ID=BC.Book_ID inner join Members m on m.ID=BC.Member_ID where BC.State=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns["Book_ID"].Visible = false;
            dataGridView1.Columns["Member_ID"].Visible = false;
            dataGridView1.Columns["Ratings"].HeaderText = "Puan";
            dataGridView1.Columns["Comments"].HeaderText = "Yorum";
            dataGridView1.Columns["CommentDate"].Visible = false;
            dataGridView1.Columns["State"].Visible = false;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Name"].HeaderText = "Kitap";
            dataGridView1.Columns["Author_ID"].Visible = false;
            dataGridView1.Columns["PublicationYear"].Visible = false;
            dataGridView1.Columns["NumberOfPages"].Visible = false;
            dataGridView1.Columns["Language_ID"].Visible = false;
            dataGridView1.Columns["Publisher_ID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["State1"].Visible = false;
            dataGridView1.Columns["ShelfNumber"].Visible = false;
            dataGridView1.Columns["Category_ID"].Visible = false;
            dataGridView1.Columns["Photo"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["Name1"].Visible = false;
            dataGridView1.Columns["Surname"].Visible = false;
            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["BirthDate"].Visible = false;
            dataGridView1.Columns["Phone"].Visible = false;
            dataGridView1.Columns["IdentityNumber"].Visible = false;
            dataGridView1.Columns["Mail"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["Member_State_ID"].Visible = false;
            dataGridView1.Columns["MemberDate"].Visible = false;
            dataGridView1.Columns["Password"].Visible = false;
            dataGridView1.Columns["DeletedState1"].Visible = false;
            dataGridView1.Columns["DeletedInfo1"].Visible = false;
            dataGridView1.Columns["DeletedDate1"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID1"].Visible = false;
       


        }
        private void Requests()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Requests where RequestState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;
            sqlConnection.Close();
            dataGridView2.Columns["RequestType_ID"].Visible = false;
            dataGridView2.Columns["RequestNote"].Visible = false;
            dataGridView2.Columns["Request"].HeaderText = "Talep";
            dataGridView2.Columns["Member_ID"].Visible = false;
            dataGridView2.Columns["RequestOpenDate"].Visible = false;
            dataGridView2.Columns["RequestCloseDate"].Visible = false;
            dataGridView2.Columns["ID"].Visible = false;
            dataGridView2.Columns["RequestState"].Visible = false;
            //dataGridView1.Columns["Author_ID"].Visible = false;
            //dataGridView1.Columns["PublicationYear"].Visible = false;
            //dataGridView1.Columns["NumberOfPages"].Visible = false;
            //dataGridView1.Columns["Language_ID"].Visible = false;
            //dataGridView1.Columns["Publisher_ID"].Visible = false;
            //dataGridView1.Columns["Description"].Visible = false;
            //dataGridView1.Columns["State1"].Visible = false;
            //dataGridView1.Columns["ShelfNumber"].Visible = false;
            //dataGridView1.Columns["Category_ID"].Visible = false;
            //dataGridView1.Columns["Photo"].Visible = false;
            //dataGridView1.Columns["DeletedState"].Visible = false;
            //dataGridView1.Columns["DeletedInfo"].Visible = false;
            //dataGridView1.Columns["DeletedDate"].Visible = false;
            //dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            //dataGridView1.Columns["ID1"].Visible = false;
            //dataGridView1.Columns["Name1"].Visible = false;
            //dataGridView1.Columns["Surname"].Visible = false;
            //dataGridView1.Columns["Gender"].Visible = false;
            //dataGridView1.Columns["BirthDate"].Visible = false;
            //dataGridView1.Columns["Phone"].Visible = false;
            //dataGridView1.Columns["IdentityNumber"].Visible = false;
            //dataGridView1.Columns["Mail"].Visible = false;
            //dataGridView1.Columns["Address"].Visible = false;
            //dataGridView1.Columns["Member_State_ID"].Visible = false;
            //dataGridView1.Columns["MemberDate"].Visible = false;
            //dataGridView1.Columns["Password"].Visible = false;
            //dataGridView1.Columns["DeletedState1"].Visible = false;
            //dataGridView1.Columns["DeletedInfo1"].Visible = false;
            //dataGridView1.Columns["DeletedDate1"].Visible = false;
            //dataGridView1.Columns["DeletedEmployeeID1"].Visible = false;

        }
        private void MyRequest()
        {
            //SqlDataAdapter adp = new SqlDataAdapter($"select * from Requests r inner join RequestTypes rT on rt.ID=r.RequestType_ID where Member_ID=@Member_ID", sqlConnection);
            //adp.SelectCommand.Parameters.AddWithValue("@Member_ID",ActiveMemberID);
            //DataTable dt = new DataTable();
            //sqlConnection.Open();
            //adp.Fill(dt);
            //dataGridView4.DataSource = dt;
            //sqlConnection.Close();
            //dataGridView4.Columns["ID"].Visible = false;
            //dataGridView4.Columns["RequestType_ID"].Visible = false;
            //dataGridView4.Columns["RequestState"].Visible = false;
            //dataGridView4.Columns["Member_ID"].Visible = false;
            //dataGridView4.Columns["ID1"].Visible = false;
            //dataGridView4.Columns["Request"].HeaderText = "Talebim";
            //dataGridView4.Columns["Request"].Width = 250;
            //dataGridView4.Columns["RequestNote"].HeaderText = "Talep Sonucu";
            //dataGridView4.Columns["RequestNote"].Width = 340;
            //dataGridView4.Columns["RequestOpenDate"].HeaderText = "Talep Oluşturma Tarihi";
            //dataGridView4.Columns["RequestOpenDate"].Width = 150;
            //dataGridView4.Columns["RequestCloseDate"].HeaderText = "Talep Sonuçlanma Tarihi";
            //dataGridView4.Columns["RequestCloseDate"].Width =150;
            //dataGridView4.Columns["RequestType"].HeaderText = "Talep Türü";
            //dataGridView4.Columns["RequestType"].Width = 200;
        }
        private void NowReadBooks()
        {
            //SqlDataAdapter adp = new SqlDataAdapter($"select b.Name as 'Kitap Adı' ,a.NameSurname as 'Yazarı' from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID={ActiveMemberID} and TransactionState=0", sqlConnection);
            //DataTable dt = new DataTable();
            //sqlConnection.Open();
            //adp.Fill(dt);
            //dataGridView3.DataSource = dt;
            //sqlConnection.Close();
            //dataGridView3.Columns["Kitap Adı"].Width = 250;
            //dataGridView3.Columns["Yazarı"].Width = 200;

        }
        private void Members_Load(object sender, EventArgs e)
        {
            MyRequest();
            TableReflesh();
            Requests();
            NowReadBooks();
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            //txt_Name.MaxLength = 50;
            //txt_Surname.MaxLength = 50;
            //txt_Phone.MaxLength = 11;
            //txt_Mail.MaxLength = 50;
            //rTxt_Address.MaxLength = 200;
            //txt_Password.MaxLength = 50;
            //sqlConnection.Open();
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal
            //dataGridView3.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            //dataGridView3.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //dataGridView3.AllowUserToAddRows = false; // satır ekleme iptal
            //dataGridView4.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            //dataGridView4.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            //dataGridView4.AllowUserToAddRows = false; // satır ekleme iptal
            ActiveRequestFind();

        }


        //int ActiveRequest = 0;
        private void ActiveRequestFind() {
           
           
            //string updateInfo = $"select Count(RequestType_ID) as'count' from Requests where RequestState=0 and Member_ID=@MemberID and RequestType_ID=4 group by RequestType_ID";
            //SqlCommand MemberCmd = new SqlCommand(updateInfo, sqlConnection);
            //MemberCmd.Parameters.AddWithValue("@MemberID", ActiveMemberID);
            //SqlDataReader dr2 = MemberCmd.ExecuteReader();
            //if (dr2.Read())
            //{
            //    ActiveRequest = Convert.ToInt32(dr2["count"]);
            //    sqlConnection.Close();
            //   // MessageBox.Show(ActiveRequest.ToString());

            //}
            //sqlConnection.Close();
            //if (ActiveRequest > 0)
            //{
            //    button3.Enabled = false;
            //    button3.Text = "Güncelleme Onayı Bekleniyor";
            //}
            //sqlConnection.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
           



              //SqlDataAdapter adp = new SqlDataAdapter($"select * from Members where ID={ActiveMemberID}", sqlConnection);
              //  DataTable dt = new DataTable();
              //  sqlConnection.Open();
              //  adp.Fill(dt);
              //  dataGridView1.DataSource = dt;
              //  sqlConnection.Close();
              //  string NameInfo = dt.Rows[0]["Name"].ToString();
              //  string SurnameInfo = dt.Rows[0]["Surname"].ToString();
              //  string Gender = dt.Rows[0]["Gender"].ToString();
              //  string BirthDay = dt.Rows[0]["BirthDate"].ToString();
              //  string Phone = dt.Rows[0]["Phone"].ToString();
              //  string Mail = dt.Rows[0]["Mail"].ToString();
              //  string Address = dt.Rows[0]["Address"].ToString();

              //  string request = $"ID: {ActiveMemberID} \n" +
              //     $"Adı: {NameInfo} \nTalep Edilen Ad: {txt_Name.Text} \n" +
              //     $"Soyadı: {SurnameInfo} \nTalep Edilen Soyad: {txt_Surname.Text} \n" +
              //     $"Cinsiyet: {Gender} \nTalep Edilen Cinsiyet: {comboBox1.Text} \n" +
              //     $"Doğum Tarihi: {BirthDay} \nTalep Edilen Doğum Tarihi: {dateTimePicker1.Text} \n" +
              //     $"Telefon Numarası: {Phone} \nTalep Edilen Telefon Numarası: {txt_Phone.Text} \n" +
              //     $"Mail: {Mail} \nTalep Edilen Mail: {txt_Mail.Text} \n" +
              //     $"Adres: {Address} \nTalep Edilen Adres: {rTxt_Address.Text} \n";


                sqlConnection.Open();
                SqlCommand Update = new SqlCommand();
                Update.Connection = sqlConnection;
                Update.CommandText = "AddRequestUpdateProfile"; //stoured procedure'un saklandığı yer.
                Update.CommandType = CommandType.StoredProcedure; //bağlantı tipi stoured procedure olarak ayarlandı.

                Update.Parameters.AddWithValue("@Member_ID", ActiveMemberID);
                //Update.Parameters.AddWithValue("@Request", request);
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
           
             //       MemberUpdatePassword UpdatePassword = new MemberUpdatePassword();
             //       UpdatePassword.ActiveMemberID = Convert.ToInt32(txt_Id.Text);
             //       UpdatePassword.ShowDialog();
             ////       Default();
             //       TableReflesh();
               
        }

        private void cB_State_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         

            //string Request = (dataGridView4.CurrentRow.Cells["Request"].Value).ToString();
            //string RequestNote = dataGridView4.CurrentRow.Cells["RequestNote"].Value.ToString();
            //string RequestOpenDate = dataGridView4.CurrentRow.Cells["RequestOpenDate"].Value.ToString();
            //string RequestCloseDate = (dataGridView4.CurrentRow.Cells["RequestCloseDate"].Value).ToString();
            //string RequestType = dataGridView4.CurrentRow.Cells["RequestType"].Value.ToString();
            //string RequestMsgShowBox = $"Talebimin Sonucu: {RequestNote}\nTalebim: {Request}\nTalep Tarihi: {RequestOpenDate}";
            //MessageBox.Show(RequestMsgShowBox, RequestType+" "+ RequestCloseDate);
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for (int i = 0; i < dataGridView4.Rows.Count; i++)
            //{
            //    DataGridViewCellStyle renk = new DataGridViewCellStyle();
            //    if (dataGridView4.Rows[i].Cells["RequestCloseDate"].Value == null)
            //    {
            //        renk.BackColor = Color.YellowGreen;
            //    }
            //    else if (dataGridView4.Rows[i].Cells["RequestCloseDate"].Value!= null)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tB_BookID.Text = dataGridView1.CurrentRow.Cells["Book_ID"].Value.ToString();
            tB_MemberID.Text = dataGridView1.CurrentRow.Cells["Member_ID"].Value.ToString();
            rTB_Comment.Text = dataGridView1.CurrentRow.Cells["Comments"].Value.ToString();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
           SqlCommand adp = new SqlCommand($"Update BookComments set State=1, Comments=@Comments where Member_ID = @Member_ID and Book_ID = @Book_ID", sqlConnection);
            adp.Parameters.AddWithValue("@Comments",rTB_Comment.Text);
            adp.Parameters.AddWithValue("@Member_ID", tB_MemberID.Text);
            adp.Parameters.AddWithValue("@Book_ID", tB_BookID.Text);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            adp.ExecuteNonQuery();
           sqlConnection.Close();
            TableReflesh();
            rTB_Comment.Text = "";

            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tB_RequestID.Text = dataGridView2.CurrentRow.Cells["ID"].Value.ToString();
            richTextBox1.Text = dataGridView2.CurrentRow.Cells["Request"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand adp = new SqlCommand($"Update Requests set RequestState=1,RequestNote=@RequestNote,RequestCloseDate=@Now where ID = @ID", sqlConnection);
            adp.Parameters.AddWithValue("@RequestNote", richTextBox2.Text);
       //    string BirthDate = DateTime.Now.ToString("yyyy-MM-dd");
   //         komut.Parameters.AddWithValue("@BirthDate", BirthDate);
            adp.Parameters.AddWithValue("@Now", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            adp.Parameters.AddWithValue("@ID", tB_RequestID.Text);
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            adp.ExecuteNonQuery();
            sqlConnection.Close();
            TableReflesh();
            richTextBox2.Text = "";
            Requests();
           
        }
    }
}

