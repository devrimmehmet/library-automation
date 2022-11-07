using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class MemberAddRequest : Form
    {
        public MemberAddRequest()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection($"Data Source=.;Initial Catalog=Library;Integrated Security=True");
        public int ActiveMemberID = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (rTxt_Description.Text=="")
            {
                MessageBox.Show("Talep Yazmadınız.");
            }
            else
            {

           
            sqlConnection.Open();
            SqlCommand komut1 = new SqlCommand("SELECT * FROM RequestTypes where RequestType=@RequestType", sqlConnection);
            komut1.Parameters.AddWithValue("@RequestType",cB_RequestType.Text);
           
            SqlDataReader dr1;
            int RequestType_ID = 0;
            dr1 = komut1.ExecuteReader();
            if (dr1.Read())
            {
             RequestType_ID=Convert.ToInt32(dr1["ID"]);
            }
            sqlConnection.Close();
            sqlConnection.Open();
            string RequestAddStr = "insert into Requests(RequestType_ID, Request, RequestState, Member_ID) values(@RequestType_ID,@Request,@RequestState,@Member_ID)";
            SqlCommand Add = new SqlCommand(RequestAddStr, sqlConnection);
            Add.Parameters.AddWithValue("@RequestType_ID", RequestType_ID);
            Add.Parameters.AddWithValue("@Request", rTxt_Description.Text);
            Add.Parameters.AddWithValue("@RequestState", 0);
            Add.Parameters.AddWithValue("@Member_ID", ActiveMemberID);
         
            Add.ExecuteNonQuery();
            sqlConnection.Close();
                MessageBox.Show("Talep Gönderildi.");
                this.Close();
            }
        }

       
        private void Login_Load(object sender, EventArgs e)
        {
        
           
            SqlCommand komut1 = new SqlCommand("SELECT RequestType FROM RequestTypes", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            cB_RequestType.Items.Clear();
            while (dr1.Read())
            {
                cB_RequestType.Items.Add(dr1["RequestType"]);
            }
            cB_RequestType.SelectedIndex = 4;
            sqlConnection.Close();

        }

      
    }
}
