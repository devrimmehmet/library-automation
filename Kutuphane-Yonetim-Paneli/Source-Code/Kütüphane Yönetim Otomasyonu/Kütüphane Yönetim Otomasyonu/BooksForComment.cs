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
    public partial class BooksForComment : Form
    {
        public BooksForComment()
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
            //       txt_Search_Name.Text = "";
            txt_Search_Shelf.Text = "";
            rTxt_Description.Text = "";
            cB_Author.Text = "";

        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter($"select * from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID={ActiveMemberID} and TransactionState=1", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
            dataGridView1.Columns["Name"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["Name"].Width = 430;
            dataGridView1.Columns["PublicationYear"].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns["PublicationYear"].Width = 120;
            dataGridView1.Columns["NumberOfPages"].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns["NumberOfPages"].Width = 120;
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Member_ID"].Visible = false;
            dataGridView1.Columns["EntrustedEmployee_ID"].Visible = false;
            dataGridView1.Columns["ReturnEmployee_ID"].Visible = false;
            dataGridView1.Columns["Book_ID"].Visible = false;
            dataGridView1.Columns["TransactionsDate"].Visible = false;
            dataGridView1.Columns["BookDepositDate"].Visible = false;
            dataGridView1.Columns["BookReturnDate"].Visible = false;
            dataGridView1.Columns["TransactionNote"].Visible = false;
            dataGridView1.Columns["TransactionState"].Visible = false;
            dataGridView1.Columns["ID1"].Visible = false;
            dataGridView1.Columns["Author_ID"].Visible = false;
            dataGridView1.Columns["Language_ID"].Visible = false;
            dataGridView1.Columns["Publisher_ID"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["State"].Visible = false;
            dataGridView1.Columns["ShelfNumber"].HeaderText = "Raf";
            dataGridView1.Columns["Category_ID"].Visible = false;
            dataGridView1.Columns["Photo"].Visible = false;
            dataGridView1.Columns["DeletedState"].Visible = false;
            dataGridView1.Columns["DeletedInfo"].Visible = false;
            dataGridView1.Columns["DeletedDate"].Visible = false;
            dataGridView1.Columns["DeletedEmployeeID"].Visible = false;
            dataGridView1.Columns["ID2"].Visible = false;
            dataGridView1.Columns["Information"].Visible = false;
            dataGridView1.Columns["DeletedState1"].Visible = false;
            dataGridView1.Columns["NameSurname"].HeaderText = "Yazar";
            dataGridView1.Columns["NameSurname"].Width = 320;



        }

        private void Members_Load(object sender, EventArgs e)
        {
            button3.Visible = false;
            SqlCommand komut3 = new SqlCommand("SELECT Name FROM Categories Where DeletedState=0", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            comboBox1.SelectedIndex = 9;

            sqlConnection.Close();

            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();
            Default();

            txt_Name.MaxLength = 50;
            //   txt_ShelfNumber.MaxLength = 50;
            txt_PageNumber.MaxLength = 11;
            txt_PublishYear.MaxLength = 4;
            rTxt_Description.MaxLength = 1000;
            txt_Search_Shelf.MaxLength = 11;

            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.MultiSelect = false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_Id.Text = (dataGridView1.CurrentRow.Cells["ID1"].Value).ToString();
            txt_Name.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
            txt_PublishYear.Text = dataGridView1.CurrentRow.Cells["PublicationYear"].Value.ToString();
            txt_PageNumber.Text = dataGridView1.CurrentRow.Cells["NumberOfPages"].Value.ToString();
            rTxt_Description.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
            //  txt_ShelfNumber.Text = dataGridView1.CurrentRow.Cells["ShelfNumber"].Value.ToString();
            cB_Author.Text = dataGridView1.CurrentRow.Cells["NameSurname"].Value.ToString();
            //      cB_Category.Text = dataGridView1.CurrentRow.Cells["Name2"].Value.ToString();
            //  cB_Language.Text = dataGridView1.CurrentRow.Cells["Language"].Value.ToString();
            //  cB_Publisher.Text = dataGridView1.CurrentRow.Cells["Name1"].Value.ToString();
            pictureBox3.ImageLocation = dataGridView1.CurrentRow.Cells["Photo"].Value.ToString();
            sqlConnection.Open();

            string Member = "SELECT * FROM BookComments where Book_ID=@ID AND Member_ID=@member";
            SqlCommand MemberCmd = new SqlCommand(Member, sqlConnection);
            MemberCmd.Parameters.AddWithValue("@member", ActiveMemberID);
            MemberCmd.Parameters.AddWithValue("@ID", txt_Id.Text);
            SqlDataReader dr2 = MemberCmd.ExecuteReader();
            if (dr2.Read())
            {
                btn_Add.Enabled = false;
                richTextBox1.Text = dr2["Comments"].ToString();
                button3.Visible = true;
            }
            else
            {
                btn_Add.Enabled = true;
                richTextBox1.Text ="";
                button3.Visible = false;
            }
            sqlConnection.Close();

        }
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    DataGridViewCellStyle renk = new DataGridViewCellStyle();
            //    if (dataGridView1.Rows[i].Cells["State"].Value.ToString() == "False")
            //    {
            //        renk.BackColor = Color.Red;
            //        renk.ForeColor = Color.White;
            //    }
            //    if (dataGridView1.Rows[i].Cells["State"].Value.ToString() == "True")
            //    {
            //        renk.BackColor = Color.Green;
            //        renk.ForeColor = Color.White;
            //    }
            //    dataGridView1.Rows[i].DefaultCellStyle = renk;
            //}
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
            if (CategoryIdforRandomBook == 0)
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
                List<int> readMemberList = new List<int>();
                while (dr4.Read())
                {

                    categoryList.Remove(Convert.ToInt32(dr4["ID"]));
                }
                sqlConnection.Close();
                int RandomFinishNumber = categoryList.Count();
                if (RandomFinishNumber == 0)
                {
                    MessageBox.Show("Sevdiğiniz kategoride okunacak başka kitabımız kalmadı, Tebrikler. Daha sonra tekrar denerseniz kütüphaneye yeni kitaplar geldiğinde size kitap önerebiliriz.");

                }

                Random rnd = new Random();
                int selectedLikeBooks = rnd.Next(0, RandomFinishNumber);
                //    MessageBox.Show(RandomFinishNumber.ToString());
                //     MessageBox.Show("Önerilen Kitap ID" + categoryList[selectedLikeBooks].ToString());
                SqlDataAdapter adp1 = new SqlDataAdapter($"select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.DeletedState=0 and b.ID={categoryList[selectedLikeBooks]}", sqlConnection);
                DataTable dt1 = new DataTable();
                sqlConnection.Open();
                adp1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                sqlConnection.Close();
            }
            //SqlDataAdapter adp = new SqlDataAdapter($"select b.Name as 'Kitap Adı' ,a.NameSurname as 'Yazarı' from Transactions t inner join Books b  on t.Book_ID=b.ID inner join Authors a on a.ID=b.Author_ID where  Member_ID={ActiveMemberID} and TransactionState=1", sqlConnection);
            //DataTable dt = new DataTable();
            //sqlConnection.Open();
            //adp.Fill(dt);
            //dataGridView2.DataSource = dt;
            //sqlConnection.Close();
            //dataGridView2.Columns["Kitap Adı"].Width = 100;
            //dataGridView2.Columns["Yazarı"].Width = 250;
            //TableReflesh();
            //dataGridView1.Rows[1].Cells[1].Selected = true;
            //dataGridView1.CurrentRow.Selected = true;
            //int rowIndex = e.RowIndex;
            //DataGridViewRow row = dataGridView1.Rows[rowIndex];
            //textBox5.Text = row.Cells[1].Value;
            // dataGridView1_CellClick(sender);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text == "")
            {
                MessageBox.Show("Lütfen Yorum yapmak istediğiniz kitabı seçiniz.");
            }
            else
            {

                sqlConnection.Open();
                string CategoryAdd = "insert into BookComments (Book_ID,Member_ID,Ratings,Comments,State) values (@Book_ID,@Member_ID,@Ratings,@Comments,0)";
                SqlCommand komut = new SqlCommand(CategoryAdd, sqlConnection);
                komut.Parameters.AddWithValue("@Book_ID", txt_Id.Text);
                komut.Parameters.AddWithValue("@Member_ID", ActiveMemberID);
                komut.Parameters.AddWithValue("@Ratings", comboBox1.Text);
                komut.Parameters.AddWithValue("@Comments", richTextBox1.Text);
                int eklenti = komut.ExecuteNonQuery();
                sqlConnection.Close();
                if (eklenti > 0)
                {
                    MessageBox.Show("Yorum Eklendi.");
                    TableReflesh();
                }
                sqlConnection.Close();
                Default();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string CategoryAdd = "update BookComments set Ratings=@Ratings, Comments=@Comments,State=0 where Book_ID=@Book_ID and Member_ID=@Member_ID";
            SqlCommand komut = new SqlCommand(CategoryAdd, sqlConnection);
            komut.Parameters.AddWithValue("@Book_ID", txt_Id.Text);
            komut.Parameters.AddWithValue("@Member_ID", ActiveMemberID);
            komut.Parameters.AddWithValue("@Ratings", comboBox1.Text);
            komut.Parameters.AddWithValue("@Comments", richTextBox1.Text);
            int eklenti = komut.ExecuteNonQuery();
            sqlConnection.Close();
            if (eklenti > 0)
            {
                MessageBox.Show("Yorum Güncellendi.");
                TableReflesh();
            }
            sqlConnection.Close();
            Default();
        }
    }
}




