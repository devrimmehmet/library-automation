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
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Data Source=.; Initial Catalog=Library; Integrated Security=true");
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
            cB_Language.Text = "Türkçe";
            cB_Publisher.Text = "";
        }
        private void TableReflesh()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.DeletedState=0", sqlConnection);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible =false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Mevcut";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
           dataGridView1.Columns[14].HeaderText = "Yazar";
            dataGridView1.Columns[14].Width = 120;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
           dataGridView1.Columns[18].HeaderText = "Dili";
            dataGridView1.Columns[18].Width = 60;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].HeaderText = "Yayınevi";
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].HeaderText = "Kategori";
            dataGridView1.Columns[27].Width = 80;
            dataGridView1.Columns[28].Visible = false;
        }
        private void TableSearchShelf(string SearchTextShelfNumber)
        {
            string BookSearchStr = "select * from Books b inner join Authors a on a.ID=b.Author_ID inner join Languages l on l.ID=b.Language_ID inner join Publishers p on p.ID=b.Publisher_ID inner join Categories c on c.ID=b.Category_ID where b.ShelfNumber like '%'+@Text+'%' and b.DeletedState=0";
            SqlDataAdapter BookCmd = new SqlDataAdapter();
            BookCmd.SelectCommand = new SqlCommand(BookSearchStr, sqlConnection);
            BookCmd.SelectCommand.Parameters.AddWithValue("@Text", SearchTextShelfNumber.ToString());
            DataTable dt = new DataTable();
            sqlConnection.Open();
            BookCmd.Fill(dt);
            dataGridView1.DataSource = dt;

            sqlConnection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Mevcut";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].HeaderText = "Yazar";
            dataGridView1.Columns[14].Width = 120;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].HeaderText = "Dili";
            dataGridView1.Columns[18].Width = 60;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].HeaderText = "Yayınevi";
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].HeaderText = "Kategori";
            dataGridView1.Columns[27].Width = 80;
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
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].HeaderText = "Kitap Adı";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].HeaderText = "Yayın Tarihi";
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].HeaderText = "Sayfa Sayısı";
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Açıklama";
            dataGridView1.Columns[8].HeaderText = "Mevcut";
            dataGridView1.Columns[8].Width = 50;
            dataGridView1.Columns[9].HeaderText = "Raf";
            dataGridView1.Columns[9].Width = 50;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].HeaderText = "Yazar";
            dataGridView1.Columns[14].Width = 120;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].Visible = false;
            dataGridView1.Columns[18].HeaderText = "Dili";
            dataGridView1.Columns[18].Width = 60;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].HeaderText = "Yayınevi";
            dataGridView1.Columns[21].Width = 150;
            dataGridView1.Columns[22].Visible = false;
            dataGridView1.Columns[23].Visible = false;
            dataGridView1.Columns[24].Visible = false;
            dataGridView1.Columns[25].Visible = false;
            dataGridView1.Columns[26].Visible = false;
            dataGridView1.Columns[27].HeaderText = "Kategori";
            dataGridView1.Columns[27].Width = 80;
            dataGridView1.Columns[28].Visible = false;


        }
        private void Members_Load(object sender, EventArgs e)
        {

            checkB_State.Checked = true;

            SqlCommand komut = new SqlCommand("SELECT Language FROM Languages Where DeletedState=0", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            cB_Language.Items.Clear();
            while (dr.Read())
            {
                cB_Language.Items.Add(dr["Language"]);
            }
            sqlConnection.Close();

            SqlCommand komut1 = new SqlCommand("SELECT NameSurname FROM Authors Where DeletedState=0", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            cB_Author.Items.Clear();
            while (dr1.Read())
            {
                cB_Author.Items.Add(dr1["NameSurname"]);
            }
            
            sqlConnection.Close();
            SqlCommand komut2 = new SqlCommand("SELECT Name FROM Publishers Where DeletedState=0", sqlConnection);
            SqlDataReader dr2;
            sqlConnection.Open();
            dr2 = komut2.ExecuteReader();
            cB_Publisher.Items.Clear();
            while (dr2.Read())
            {
                cB_Publisher.Items.Add(dr2["Name"]);
            }

            sqlConnection.Close();


            SqlCommand komut3 = new SqlCommand("SELECT Name FROM Categories Where DeletedState=0", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            cB_Category.Items.Clear();
            while (dr3.Read())
            {
                cB_Category.Items.Add(dr3["Name"]);
            }

            sqlConnection.Close();
       
            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.AllowUserToAddRows = false; // satır ekleme iptal

            TableReflesh();
            Default();
            cB_Language.SelectedIndex = 0;
            txt_Name.MaxLength = 50;
            txt_ShelfNumber.MaxLength = 50;
            txt_PageNumber.MaxLength = 11;
            txt_PublishYear.MaxLength = 4;
            rTxt_Description.MaxLength = 1000;
            txt_Search_Shelf.MaxLength = 11;
            txt_Search_Name.MaxLength = 50;
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
        }
        private void Just_Numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void txt_Search_TC_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Name.Text = "";
            if (txt_Search_Shelf.Text != "")
            {
                TableSearchShelf(txt_Search_Shelf.Text);
                Default();
            }
            else
            {
                TableReflesh();
                Default();
            }
        }

        private void txt_Search_Name_TextChanged(object sender, EventArgs e)
        {
            txt_Search_Shelf.Text = "";
            if (txt_Search_Name.Text != "")
            {
                TableReflesh(txt_Search_Name.Text);
                Default();
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != "")
            {
                if (MessageBox.Show("Kitap Silmeyi Onaylıyormusunuz?", "Onay Verin", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    int IDD = Convert.ToInt32(txt_Id.Text);
                    sqlConnection.Open();
                    SqlCommand Sil = new SqlCommand($"DeleteFromBooks {IDD}", sqlConnection);
                    Sil.ExecuteNonQuery();
                    sqlConnection.Close();
                    TableReflesh();
                    Default();
                }
                else
                {
                    MessageBox.Show("Silme işlemi tarafınızca iptal edilmiştir.", "Silme İşlemi İptal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Lütfen silinecek kaydı seçiniz");
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            int AuthorID = 0;
            SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Authors where NameSurname='{cB_Author.Text}' and DeletedState=0", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                AuthorID = Convert.ToInt32(dr1["ID"]);
            }
            sqlConnection.Close();

            int LanguageID = 0;
            SqlCommand komut = new SqlCommand($"SELECT ID FROM Languages where Language='{cB_Language.Text}' and DeletedState=0", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LanguageID = Convert.ToInt32(dr["ID"]);
            }
            sqlConnection.Close();

            int PublisherID = 0;
            SqlCommand komut2 = new SqlCommand($"SELECT ID FROM Publishers where Name='{cB_Publisher.Text}' and DeletedState=0", sqlConnection);
            SqlDataReader dr2;
            sqlConnection.Open();
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                PublisherID = Convert.ToInt32(dr2["ID"]);
            }
            sqlConnection.Close();

            int CategoryID = 0;
            SqlCommand komut3 = new SqlCommand($"SELECT ID FROM Categories where Name='{cB_Category.Text}' and DeletedState=0", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CategoryID = Convert.ToInt32(dr3["ID"]);
            }
            sqlConnection.Close();
            int State = 0;
            if (checkB_State.Checked == true)
            {
                State = 1;
            }
            else
            {
                State = 0;
            }

            if (txt_PublishYear.Text != "")
            {

                if (txt_PageNumber.Text == "")
                {
                    txt_PageNumber.Text = "0";
                }
                if (cB_Language.Text != "")
                {
                    if (cB_Publisher.Text != "")
                    {
                        if (txt_ShelfNumber.Text != "")
                        {
                            if (rTxt_Description.Text == "")
                            {
                                rTxt_Description.Text = " ";
                            }
                            if (cB_Category.Text != "")
                            {

                                if (cB_Author.Text != "")
                                {
                                    if (txt_Name.Text != "")
                                    {
                                        sqlConnection.Open();
                                        string BooksFindStr = "SELECT * FROM books where ShelfNumber=@ShelfNumber";
                                        SqlCommand BooksFind = new SqlCommand(BooksFindStr, sqlConnection);
                                        BooksFind.Parameters.AddWithValue("@ShelfNumber", txt_ShelfNumber.Text);
                                        SqlDataReader dr4 = BooksFind.ExecuteReader();
                                        if (dr4.Read())
                                        {
                                            MessageBox.Show("Bu Raf numarasına ait başka bir kitap var !!! Başka bir raf numarası giriniz.");
                                            sqlConnection.Close();

                                        }
                                        else
                                        {
                                            sqlConnection.Close();
                                            sqlConnection.Open();
                                            string BooksAddStr = "insert into Books(Name, Author_ID, PublicationYear, NumberOfPages, Language_ID, Publisher_ID, Description, State, ShelfNumber, Category_ID) values(@Name,@Author_ID,@PublicationYear,@NumberOfPages,@Language_ID,@Publisher_ID,@Description,@State,@ShelfNumber,@Category_ID)";
                                            SqlCommand Add = new SqlCommand(BooksAddStr, sqlConnection);
                                            Add.Parameters.AddWithValue("@Name", txt_Name.Text);
                                            Add.Parameters.AddWithValue("@Author_ID", AuthorID);
                                            Add.Parameters.AddWithValue("@PublicationYear", txt_PublishYear.Text);
                                            Add.Parameters.AddWithValue("@NumberOfPages", txt_PageNumber.Text);
                                            Add.Parameters.AddWithValue("@Language_ID", LanguageID);
                                            Add.Parameters.AddWithValue("@Publisher_ID", PublisherID);
                                            Add.Parameters.AddWithValue("@Description", rTxt_Description.Text);
                                            Add.Parameters.AddWithValue("@State", State);
                                            Add.Parameters.AddWithValue("@ShelfNumber", txt_ShelfNumber.Text);
                                            Add.Parameters.AddWithValue("@Category_ID", CategoryID);
                                            Add.ExecuteNonQuery();
                                            sqlConnection.Close();
                                            TableReflesh();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Kitabın adını giriniz! Boş Geçilemez");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Kitabın Yazarını Seçiniz! Boş Geçilemez");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Kitabın Kategorisini Giriniz! Boş Geçilemez");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Kitabın Raf Numarasını Giriniz! Boş Geçilemez");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Kitabın Yayınevini Seçiniz! Boş Geçilemez");
                    }

                }
                else
                {
                    MessageBox.Show("Kitabın Yayım Dilini Seçiniz! Boş Geçilemez");

                }

            }
            else
            {
                MessageBox.Show("Yayınlanma Tarihi Boş Geçilemez");

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int AuthorID = 0;
            SqlCommand komut1 = new SqlCommand($"SELECT ID FROM Authors where NameSurname='{cB_Author.Text}'", sqlConnection);
            SqlDataReader dr1;
            sqlConnection.Open();
            dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                AuthorID = Convert.ToInt32(dr1["ID"]);
            }
            sqlConnection.Close();

            int LanguageID = 0;
            SqlCommand komut = new SqlCommand($"SELECT ID FROM Languages where Language='{cB_Language.Text}'", sqlConnection);
            SqlDataReader dr;
            sqlConnection.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LanguageID = Convert.ToInt32(dr["ID"]);
            }
            sqlConnection.Close();

            int PublisherID = 0;
            SqlCommand komut2 = new SqlCommand($"SELECT ID FROM Publishers where Name='{cB_Publisher.Text}'", sqlConnection);
            SqlDataReader dr2;
            sqlConnection.Open();
            dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                PublisherID = Convert.ToInt32(dr2["ID"]);
            }
            sqlConnection.Close();

            int CategoryID = 0;
            SqlCommand komut3 = new SqlCommand($"SELECT ID FROM Categories where Name='{cB_Category.Text}'", sqlConnection);
            SqlDataReader dr3;
            sqlConnection.Open();
            dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                CategoryID = Convert.ToInt32(dr3["ID"]);
            }
            sqlConnection.Close();

            int State = 0;
            if (checkB_State.Checked == true)
            {
                State = 1;
            }
            else
            {
                State = 0;
            }

            if (txt_PublishYear.Text != "")
            {

                if (txt_PageNumber.Text == "")
                {
                    txt_PageNumber.Text = "0";
                }
                if (cB_Language.Text != "")
                {
                    if (cB_Publisher.Text != "")
                    {
                        if (txt_ShelfNumber.Text != "")
                        {
                            if (rTxt_Description.Text == "")
                            {
                                rTxt_Description.Text = " ";
                            }
                            if (cB_Category.Text != "")
                            {

                                if (cB_Author.Text != "")
                                {
                                    if (txt_Name.Text != "")
                                    {
                                        sqlConnection.Open();
                                        string BooksFindStr = "SELECT * FROM books where ShelfNumber=@ShelfNumber and ID!=@ID";
                                        SqlCommand BooksFind = new SqlCommand(BooksFindStr, sqlConnection);
                                        BooksFind.Parameters.AddWithValue("@ShelfNumber", txt_ShelfNumber.Text);
                                        BooksFind.Parameters.AddWithValue("@ID", Convert.ToInt32(txt_Id.Text));
                                        SqlDataReader dr4 = BooksFind.ExecuteReader();
                                        if (dr4.Read())
                                        {
                                            MessageBox.Show("Bu Raf numarasına ait başka bir kitap var !!! Başka bir raf numarası giriniz.");
                                            sqlConnection.Close();

                                        }
                                        else
                                        {
                                            sqlConnection.Close();
                                            if (txt_Id.Text != "")
                                            {
                                                int IDD = Convert.ToInt32(txt_Id.Text);
                                                sqlConnection.Open();
                                                SqlCommand BooksUpdate = new SqlCommand($"UpdateFromBooks @ID,@Name,@Author_ID,@PublicationYear,@NumberOfPages,@Language_ID,@Publisher_ID,@Description,@State,@ShelfNumber,@Category_ID", sqlConnection);
                                                BooksUpdate.Parameters.AddWithValue("@ID", IDD);
                                                BooksUpdate.Parameters.AddWithValue("@Name", txt_Name.Text);
                                                BooksUpdate.Parameters.AddWithValue("@Author_ID", AuthorID);
                                                BooksUpdate.Parameters.AddWithValue("@PublicationYear", txt_PublishYear.Text);
                                                BooksUpdate.Parameters.AddWithValue("@NumberOfPages", txt_PageNumber.Text);
                                                BooksUpdate.Parameters.AddWithValue("@Language_ID", LanguageID);
                                                BooksUpdate.Parameters.AddWithValue("@Publisher_ID", PublisherID);
                                                BooksUpdate.Parameters.AddWithValue("@Description", rTxt_Description.Text);
                                                BooksUpdate.Parameters.AddWithValue("@State", State);
                                                BooksUpdate.Parameters.AddWithValue("@ShelfNumber", txt_ShelfNumber.Text);
                                                BooksUpdate.Parameters.AddWithValue("@Category_ID", CategoryID);
                                                BooksUpdate.ExecuteNonQuery();
                                                sqlConnection.Close();
                                                TableReflesh();
                                                Default();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Lütfen güncellenecek kitabı seçiniz");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Kitabın adını giriniz! Boş Geçilemez");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Kitabın Yazarını Seçiniz! Boş Geçilemez");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Kitabın Kategorisini Giriniz! Boş Geçilemez");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Kitabın Raf Numarasını Giriniz! Boş Geçilemez");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Kitabın Yayınevini Seçiniz! Boş Geçilemez");
                    }

                }
                else
                {
                    MessageBox.Show("Kitabın Yayım Dilini Seçiniz! Boş Geçilemez");

                }

            }
            else
            {
                MessageBox.Show("Yayınlanma Tarihi Boş Geçilemez");

            }



        }
    }


}

