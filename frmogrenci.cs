using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace eokulörnek
{
    public partial class frmogrenci : Form
    {
        //DataSet1TableAdapters.tbl_ogrenciTableAdapter ds = new DataSet1TableAdapters.tbl_ogrenciTableAdapter();
        DataSet2TableAdapters.tbl_ogrenciTableAdapter ds = new DataSet2TableAdapters.tbl_ogrenciTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=BILALT\SQLEXPRESS;Initial Catalog=dbEokul;Integrated Security=True;");

        public frmogrenci()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmogrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.GetData();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulup", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kulupad";
            comboBox1.ValueMember = "kulupid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        string c = "belirtilmedi";
        private void btnekle_Click(object sender, EventArgs e)
        {
           
            ds.InsertQuery(txtad.Text, txtsoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("ÖĞRENCİ EKLEME İŞLEMİ BAŞARI İLE GERÇEKLEŞTİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.GetData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            ds.DeleteQuery(int.Parse(txtid.Text));
            MessageBox.Show("ÖĞRENCİ BAŞARI İLE SİLİNDİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.GetData();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            ds.UpdateQuery(txtad.Text, txtsoyad.Text, int.Parse(comboBox1.SelectedIndex.ToString())+1, c, int.Parse(txtid.Text));
            MessageBox.Show("ÖĞRENCİ BAŞARI İLE GÜNCELLENDİ", "BİLGİ EKRANI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = ds.GetData();
        }

        private void rderkek_CheckedChanged(object sender, EventArgs e)
        {
           
            if (rderkek.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void rdkiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rdkiz.Checked == true)
            {
                c = "Kız";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text == String.Empty)
            {
                MessageBox.Show("Lütfen bir öğrenci seçiniz", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else { 
                notislemform notislemform = new notislemform();
                notislemform.ogradsoyad = txtad.Text + " " + txtsoyad.Text;
                notislemform.ogrid = txtid.Text;
                notislemform.Show();

            }
        }
    }
}
