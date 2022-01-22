using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Stok_Takip
{
    public partial class urun : Form
    {
        public urun()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=localhost;User ID=SYSTEM;Password=Bosti.88;Unicode=True");
        DataSet ds = new DataSet();

        private void Form5_Load(object sender, EventArgs e)
        {
            kayıt_goster();
        }

        private void kayıt_goster()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Stok", conn);
            da.Fill(ds, "Stok");
            dataGridView1.DataSource = ds.Tables["Stok"];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Stok( urun_ad, urun_fiyat, stok_adet) VALUES ('"+textBox2.Text+ "','"+int.Parse(textBox3.Text) + "','"+int.Parse(textBox4.Text) +"')", conn);
            //cmd.Parameters.AddWithValue("@urun_ad", textBox2.Text);
           // cmd.Parameters.AddWithValue("@urun_fiyat", int.Parse(textBox3.Text));
           // cmd.Parameters.AddWithValue("@stok_adet", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Stok"].Clear();
            kayıt_goster();
            MessageBox.Show("Ürün  kaydı eklendi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                conn.Open(); 
                OleDbCommand cmd = new OleDbCommand("UPDATE Stok SET urun_ad ='" + textBox2.Text + "',urun_fiyat = " + int.Parse(textBox3.Text) + "',stok_adet = " + int.Parse(textBox4.Text) + " WHERE urun_id = " + dataGridView1.CurrentRow.Cells["urun_id"].Value.ToString() + "'", conn);
                //cmd.Parameters.AddWithValue("@urun_ad", textBox2.Text);
                //cmd.Parameters.AddWithValue("@urun_fiyat", double.Parse(textBox3.Text));
                //cmd.Parameters.AddWithValue("@stok_adet", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                ds.Tables["Stok"].Clear();
                kayıt_goster();
                MessageBox.Show("Ürün kaydı güncellendi");
            }
            else
            {
                MessageBox.Show("Ürün id belirtilmedi");
            }
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Stok WHERE urun_id='" + dataGridView1.CurrentRow.Cells["urun_id"].Value.ToString() + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Stok"].Clear();
            kayıt_goster();
            MessageBox.Show("Kayıt silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Stok WHERE urun_id LIKE '%" + textBox5.Text + "%'", conn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds.Clear();
            kayıt_goster();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["urun_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["urun_ad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["urun_fiyat"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["stok_adet"].Value.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
