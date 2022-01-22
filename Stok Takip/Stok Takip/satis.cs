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
    public partial class satis : Form
    {
        public satis()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=localhost;User ID=SYSTEM;Password=Bosti.88;Unicode=True");
        DataSet ds = new DataSet();

        private void satis_Load(object sender, EventArgs e)
        {
            kayıt_goster();
        }

        private void kayıt_goster()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Satis", conn);
            da.Fill(ds, "Satis");
            dataGridView1.DataSource = ds.Tables["Satis"];
            conn.Close();
        }

        private void kayıt_goster_urun()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Stok", conn);
            da.Fill(ds, "Stok");
            dataGridView2.DataSource = ds.Tables["Stok"];
            conn.Close();
        }

        private void kayıt_goster_personel()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Personel", conn);
            da.Fill(ds, "Personel");
            dataGridView3.DataSource = ds.Tables["Personel"];
            conn.Close();
        }

        private void kayıt_goster_musteri()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Musteri", conn);
            da.Fill(ds, "Musteri");
            dataGridView4.DataSource = ds.Tables["Musteri"];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open(); 
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Stok(satis_adet,urun_id,personel_id,musteri_id) VALUES ('" + int.Parse(textBox1.Text) + "','" + int.Parse(textBox2.Text) + "','" + int.Parse(textBox3.Text) + "','" + int.Parse(textBox4.Text) + "')", conn);
            //cmd.Parameters.AddWithValue("@satis_adet", int.Parse(textBox1.Text));
            //cmd.Parameters.AddWithValue("@urun_id", int.Parse(textBox2.Text));
            //cmd.Parameters.AddWithValue("@personel_id", int.Parse(textBox3.Text));
            //cmd.Parameters.AddWithValue("@musteri_id", int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Satis"].Clear();
            ara();
            MessageBox.Show("Satış kaydı yapıldı");
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
            if (textBox5.Text != "")
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE SATIS SET SATIS_ADET ='" + int.Parse(textBox1.Text) + "',URUN_ID = '" + int.Parse(textBox2.Text) + "',PERSONEL_ID = '" + int.Parse(textBox3.Text) + "',MUSTERI_ID = '" + int.Parse(textBox4.Text) + "' WHERE satis_id = '" + int.Parse(textBox5.Text) + "'", conn);
                //cmd.Parameters.AddWithValue("@satis_id", int.Parse(textBox5.Text));
                //cmd.Parameters.AddWithValue("@satis_adet", int.Parse(textBox1.Text));
                //cmd.Parameters.AddWithValue("@urun_id", int.Parse(textBox2.Text));
                //cmd.Parameters.AddWithValue("@personel_id", int.Parse(textBox3.Text));
                //cmd.Parameters.AddWithValue("@musteri_id", int.Parse(textBox4.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                ds.Tables["Satis"].Clear();
                ara();
                MessageBox.Show("Satış kaydı güncellendi");
            }
            else
            {
                MessageBox.Show("Satış id belirtilmedi");
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
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Satis WHERE satis_id='" + dataGridView1.CurrentRow.Cells["satis_id"].Value.ToString() + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Satis"].Clear();
            kayıt_goster();
            MessageBox.Show("Satış kaydı silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ara();
        }

        private void ara()
        {
            DataTable dt = new DataTable();
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Satis WHERE satis_id LIKE '%" + textBox6.Text + "%'", conn);
            da.Fill(dt);
            int satısAdedi = int.Parse(dt.Rows[0][1].ToString()); ;
            dataGridView1.DataSource = dt;
            conn.Close();

            DataTable dt2 = new DataTable();
            conn.Open();
            OleDbDataAdapter da2 = new OleDbDataAdapter("SELECT * FROM Stok WHERE URUN_id LIKE '%" + dt.Rows[0][2].ToString() + "%'", conn);
            da2.Fill(dt2);
            int birimFiyat = int.Parse(dt2.Rows[0][2].ToString());
            dataGridView2.DataSource = dt2;
            conn.Close();

            DataTable dt3 = new DataTable();
            conn.Open();
            OleDbDataAdapter da3 = new OleDbDataAdapter("SELECT * FROM Personel WHERE personel_id LIKE '%" + int.Parse(dt.Rows[0][3].ToString()) + "%'", conn);
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
            conn.Close();

            DataTable dt4 = new DataTable();
            conn.Open();
            OleDbDataAdapter da4 = new OleDbDataAdapter("SELECT * FROM Musteri WHERE musteri_id LIKE '%" + int.Parse(dt.Rows[0][4].ToString()) + "%'", conn);
            da4.Fill(dt4);
            dataGridView4.DataSource = dt4;
            conn.Close();

           // textBox7.Text = (satısAdedi*birimFiyat).ToString();
           /* DataTable dt5 = new DataTable();
            conn.Open();
            OleDbDataAdapter da5 = new OleDbDataAdapter("PROCEDURE1", conn);
            da5.Fill(dt5);
            textBox7.Text = dt5.ToString();*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ds.Clear();
            kayıt_goster();
            kayıt_goster_urun();
            kayıt_goster_personel();
            kayıt_goster_musteri();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox5.Text = dataGridView1.CurrentRow.Cells["satis_id"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["satis_adet"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["urun_id"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["personel_id"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["musteri_id"].Value.ToString();
        }
    }
}
