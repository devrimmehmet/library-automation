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
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kütüphane_Yönetim_Otomasyonu
{
    public partial class BooksForMembers : Form
    {
        public BooksForMembers()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
       public int ActiveMemberID = 0;
        private void Default()
        {
            txt_Id.Text = "";
            txt_Name.Text = "";
            txt_PageNumber.Text = "";
            txt_PublishYear.Text = "";
            txt_Search_Name.Text = "";
            txt_Search_Shelf.Text = "";
            rTxt_Description.Text = "";
            cB_Author.Text = "";
            cB_Category.Text = "";
            cB_Language.Text = "";
            cB_Publisher.Text = "";
            cB_CategoryForSearh.Text = "";
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].Visible =false;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 390;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible =false;
            dataGridView1.Columns[7].Visible = false;//açıklama
            dataGridView1.Columns[8].Visible =false;//mevcut
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 70;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedState4"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["ID4"].Visible = false;
            dataGridView1.Columns["NameSurname"].HeaderText = "Yazar";
            dataGridView1.Columns["NameSurname"].Width = 230;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;//Yayınevi
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns["Name2"].HeaderText = "Kategori";
            dataGridView1.Columns["Name2"].Width = 160;
            dataGridView1.Columns[27].Width = 160;
            dataGridView1.Columns[28].Visible = false;
        }
        private void TableComments()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select m.Name+' '+m.Surname as 'Ad-Soyad', BC.Ratings as 'Puan',BC.Comments as 'Yorum', BC.CommentDate as 'Yorum Zamanı' from BookComments BC inner join Books b on b.ID=BC.Book_ID inner join Members m on m.ID=BC.Member_ID where BC.Book_ID=@Book_ID  and BC.State=1", sqlConnection);
            adp.SelectCommand.Parameters.AddWithValue("@Book_ID",txt_Id.Text);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView2.DataSource = dt;

            sqlConnection.Close();
          
        }
        private void TableSearchShelf(string SearchTextShelfNumber)
        {
            string BookSearchStr = "select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where c.Name like '%'+@Text+'%' and b.DeletedState=0";
            SqlDataAdapter BookCmd = new SqlDataAdapter();
            BookCmd.SelectCommand = new SqlCommand(BookSearchStr, sqlConnection);
            BookCmd.SelectCommand.Parameters.AddWithValue("@Text", SearchTextShelfNumber.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            BookCmd.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 390;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;//açıklama
            dataGridView1.Columns[8].Visible = false;//mevcut
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 70;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedState4"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["ID4"].Visible = false;
            dataGridView1.Columns["NameSurname"].HeaderText = "Yazar";
            dataGridView1.Columns["NameSurname"].Width = 230;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;//Yayınevi
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns["Name2"].HeaderText = "Kategori";
            dataGridView1.Columns["Name2"].Width = 160;
            dataGridView1.Columns[27].Width = 160;
            dataGridView1.Columns[28].Visible = false;

        }
        private void TableReflesh(string SearchTextName)
        {
      
            string BookSearchStr = "select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.Name like '%'+@Text+'%' and b.DeletedState=0";
            SqlDataAdapter BookCmd = new SqlDataAdapter();
            BookCmd.SelectCommand = new SqlCommand(BookSearchStr, sqlConnection);
            BookCmd.SelectCommand.Parameters.AddWithValue("@Text", SearchTextName.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            BookCmd.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].Visible =false;
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 390;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 120;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 120;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;//açıklama
            dataGridView1.Columns[8].Visible = false;//mevcut
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 70;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedState4"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
            dataGridView1.Columns["ID4"].Visible = false;
            dataGridView1.Columns["NameSurname"].HeaderText = "Yazar";
            dataGridView1.Columns["NameSurname"].Width = 230;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[18].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;//Yayınevi
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns["Name2"].HeaderText = "Kategori";
            dataGridView1.Columns["Name2"].Width = 160;
            dataGridView1.Columns[27].Width = 160;
            dataGridView1.Columns[28].Visible = false;

        }
        private void Members_Load(object sender, EventArgs e)
        {

            SqlCommand komut3 = new SqlCommand("SELECT Name FROM Categories Where DeletedState=0", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
         
            cB_CategoryForSearh.Items.Clear();

            while (dr3.Read())
            {
                
                cB_CategoryForSearh.Items.Add(dr3["Name"]);
            }

            sqlConnection.Close();
       
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView2.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView2.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView2.AllowUserToAddRows = false; // satır ekleme iptal
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            TableReflesh();
            Default();
            
            txt_Name.MaxLength = 50;
            txt_ShelfNumber.MaxLength = 50;
            txt_PageNumber.MaxLength = 11;
            txt_PublishYear.MaxLength = 4;
            rTxt_Description.MaxLength = 1000;
            txt_Search_Shelf.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.dataGridView1.SelectionMode =DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(dataGridView1.CurrentRow.Cells["State"].Value)==1)
            {
                checkB_State.Checked = true;
            }
            else
            {
                checkB_State.Checked= false;
            }
            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_PublishYear.Text =dataGridView1.CurrentRow.Cells["PublicationYear"].Value.ToString();
            txt_PageNumber.Text = dataGridView1.CurrentRow.Cells["NumberOfPages"].Value.ToString();
            rTxt_Description.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            txt_ShelfNumber.Text = dataGridView1.CurrentRow.Cells["ShelfNumber"].Value.ToString();
            cB_Author.Text=dataGridView1.CurrentRow.Cells["NameSurname"].Value.ToString();
            cB_Category.Text = dataGridView1.CurrentRow.Cells["Name2"].Value.ToString();
            cB_Language.Text = dataGridView1.CurrentRow.Cells["Language"].Value.ToString();
            cB_Publisher.Text = dataGridView1.CurrentRow.Cells["Name1"].Value.ToString();
            pictureBox3.ImageLocation = dataGridView1.CurrentRow.Cells["Photo"].Value.ToString();
            TableComments();

        }
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
      

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            cB_CategoryForSearh.Text = "";
            if (txt_Search_Name.Text != "")
            {
                TableReflesh(txt_Search_Name.Text);
              //  Default();
            }
            else
            {
                TableReflesh();
                Default();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                if (dataGridView1.Rows[i].Cells["State"].Value.ToString() == "False")
                {
                    renk.BackColor = Color.Red;
                    renk.ForeColor = Color.White;
                }
                if (dataGridView1.Rows[i].Cells["State"].Value.ToString() == "True")
                {
                    renk.BackColor = Color.Green;
                    renk.ForeColor = Color.White;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }

    

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png |  Tüm Dosyalar |*.*";
            dosya.ShowDialog();
            string dosyayolu = dosya.FileName;
            textBox1.Text = dosyayolu;
            pictureBox3.ImageLocation = dosyayolu;
        }

        private void cB_CategoryForSearh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            if (cB_CategoryForSearh.Text != "")
            {
                TableSearchShelf(cB_CategoryForSearh.Text);
                
            }
            else
            {
                TableReflesh();
                Default();
            }
        }
        int CategoryIdforRandomBook = 0;
        private void button2_Click(object sender, EventArgs e)
        {
         //   ActiveMemberID = 77;
            SqlCommand komut3 = new SqlCommand("select top 1 b.Category_ID,c.Name,COUNT(*)as 'count' from Transactions t inner join Books b on b.ID=t.Book_ID inner join Categories c on c.ID=b.Category_ID where Member_ID=@memberID group by b.Category_ID, c.Name order by 'count' desc", sqlConnection);
            SqlDataReader dr3;
            komut3.Parameters.AddWithValue("@memberID", ActiveMemberID);
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            if (dr3.Read())
            {
               
                CategoryIdforRandomBook = Convert.ToInt32(dr3["Category_ID"]);
            }
        //    MessageBox.Show($"seçilen kategori {CategoryIdforRandomBook}");
            if (CategoryIdforRandomBook==0)
            {
                MessageBox.Show("Veri toplayıp size uygun kitap önerebilmemiz için öncelikle bir kaç kitap okumanız gerekmektedir.");
            }
            else
            {

           
            sqlConnection.Close();
            SqlCommand komut5 = new SqlCommand($"select ID from Books where Category_ID=@categoryID and State=0", sqlConnection);
            SqlDataReader dr5;
            komut5.Parameters.AddWithValue("@categoryID", CategoryIdforRandomBook);
            sqlConnection.Open();
            dr5 = komut5.ExecuteReader();
            List<int> categoryList = new List<int>();
            while (dr5.Read())
            {

                categoryList.Add(Convert.ToInt32(dr5["ID"]));
            }

            sqlConnection.Close();
            SqlCommand komut4 = new SqlCommand($"select b.ID from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID=@memberID and TransactionState=1 and Category_ID=@categoryID group by b.ID", sqlConnection);
            SqlDataReader dr4;
            komut4.Parameters.AddWithValue("@memberID", ActiveMemberID);
            komut4.Parameters.AddWithValue("@categoryID", CategoryIdforRandomBook);
            
            sqlConnection.Open();
            dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {

                categoryList.Remove(Convert.ToInt32(dr4["ID"]));
            }
            sqlConnection.Close();
                
                SqlCommand komut6 = new SqlCommand($"select b.ID from Transactions t inner join Books b  on t.Book_ID = b.ID inner join Authors a on a.ID = b.Author_ID where Member_ID =@memberID and TransactionState = 0 and Category_ID=@categoryID group by b.ID", sqlConnection);
                SqlDataReader dr6;
                komut6.Parameters.AddWithValue("@memberID", ActiveMemberID);
                komut6.Parameters.AddWithValue("@categoryID", CategoryIdforRandomBook);

                sqlConnection.Open();
                dr6 = komut6.ExecuteReader();
                while (dr6.Read())
                {

                    categoryList.Remove(Convert.ToInt32(dr6["ID"]));
                }
                sqlConnection.Close();
                int RandomFinishNumber = categoryList.Count();
                if (RandomFinishNumber == 0)
                {
                    MessageBox.Show("Sevdiğiniz kategoride okunacak başka kitabımız kalmadı, Tebrikler. Daha sonra tekrar denerseniz kütüphaneye yeni kitaplar geldiğinde size kitap önerebiliriz.");

                }

                Random rnd =new Random();
                int selectedLikeBooks= rnd.Next(0,RandomFinishNumber);
                //    MessageBox.Show(RandomFinishNumber.ToString());
                //     MessageBox.Show("Önerilen Kitap ID" + categoryList[selectedLikeBooks].ToString());
                if (RandomFinishNumber!=0)
                {
                    SqlDataAdapter adp1 = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.DeletedState=0 and b.ID={categoryList[selectedLikeBooks]}", sqlConnection);
                    DataTable dt1 = new DataTable();
                    sqlConnection.Open();
                    adp1.Fill(dt1);
                    dataGridView1.DataSource = dt1;

                    sqlConnection.Close();
                }
               
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string name_surname = (dataGridView2.CurrentRow.Cells["Ad-Soyad"].Value).ToString();
           string Ratings= dataGridView2.CurrentRow.Cells["Puan"].Value.ToString();
           string Comments = dataGridView2.CurrentRow.Cells["Yorum"].Value.ToString();
            string CommentDate= dataGridView2.CurrentRow.Cells["Yorum Zamanı"].Value.ToString();
            MessageBox.Show($"Puan: {Ratings}\nYorum: {Comments}\n",$"{name_surname} {CommentDate}");
        }
    }


}

