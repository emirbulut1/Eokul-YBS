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

namespace eokulörnek
{
    
    public partial class notislemform : Form
    {
        public string ogradsoyad;
        public string ogrid;
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT\SQLEXPRESS;Initial Catalog=dbEokul;Integrated Security=True;");
        public notislemform()
        {
            InitializeComponent();
        }
        
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notislemform_Load(object sender, EventArgs e)
        {
            label7.Text = ogradsoyad +" isimli öğrenci için işlem yapılıyor!";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_not where ogrenciid= " + ogrid, baglanti);
            baglanti.Close();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_not where ogrenciid= " + ogrid, baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        

        private void ogretmendetay_Load(object sender, EventArgs e)
        {
           
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            
        }
    }
}
