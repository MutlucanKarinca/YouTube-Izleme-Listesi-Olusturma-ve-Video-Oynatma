using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Youtube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti=new SqlConnection("Data Source=DESKTOP-261BOQO;Initial Catalog=YoutubeChannel;Integrated Security=True");
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut=new SqlCommand("Insert into TBL_YOUTUBE (AD,KATEGORI,LINK) values (@P1,@P2,@P3)",baglanti);
            komut.Parameters.AddWithValue("@P1", txtVideoAd.Text);
            komut.Parameters.AddWithValue("@P2", txtKategori.Text);
            komut.Parameters.AddWithValue("@P3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Video Listenize Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        void videolar()
        {
            SqlDataAdapter da=new SqlDataAdapter("Select * From TBL_YOUTUBE",baglanti);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videolar();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            webBrowser1.Navigate(link);
        }
    }
}
