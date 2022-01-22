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
    public partial class musteri : Form
    {
        public musteri()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=localhost;User ID=SYSTEM;Password=Bosti.88;Unicode=True");
        DataSet ds = new DataSet();

        private void musteri_Load(object sender, EventArgs e)
        {
            kayıt_goster();
        }

        private void kayıt_goster()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Musteri", conn);
            da.Fill(ds, "Musteri");
            dataGridView1.DataSource = ds.Tables["Musteri"];
            conn.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO Musteri (musteri_ad,musteri_soyad,musteri_adres,musteri_tel,musteri_mail) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + int.Parse(textBox5.Text)+"' , '"+ textBox6.Text + "')", conn);
          //cmd.Parameters.AddWithValue("@musteri_ad", textBox2.Text);
          //cmd.Parameters.AddWithValue("@musteri_soyad", textBox3.Text);
          //cmd.Parameters.AddWithValue("@musteri_adres", textBox4.Text);
          //cmd.Parameters.AddWithValue("@musteri_tel", int.Parse(textBox5.Text));
          //cmd.Parameters.AddWithValue("@musteri_mail", textBox6.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Musteri"].Clear();
            kayıt_goster();
            MessageBox.Show("Müşteri kaydı eklendi");
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
                OleDbCommand cmd = new OleDbCommand("UPDATE Musteri SET musteri_ad='" + textBox2.Text + "',musteri_soyad= '" + textBox3.Text + "',musteri_adres = '" + textBox4.Text + "' ,musteri_tel = '" + int.Parse(textBox5.Text) + "',musteri_mail= '" + textBox6.Text + "' WHERE musteri_id = " + dataGridView1.CurrentRow.Cells["musteri_id"].Value.ToString() + "'", conn);
                //cmd.Parameters.AddWithValue("@musteri_ad", textBox2.Text);
                //cmd.Parameters.AddWithValue("@musteri_soyad", textBox3.Text);
                //cmd.Parameters.AddWithValue("@musteri_adres", textBox4.Text);
                //cmd.Parameters.AddWithValue("@musteri_tel", int.Parse(textBox5.Text));
                //cmd.Parameters.AddWithValue("@musteri_mail", textBox6.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                ds.Tables["Musteri"].Clear();
                kayıt_goster();
                MessageBox.Show("Müşteri kaydı güncellendi");
            }
            else
            {
                MessageBox.Show("Müşteri id belirtilmedi");
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
            OleDbCommand cmd = new OleDbCommand("DELETE FROM Musteri WHERE musteri_id='" + dataGridView1.CurrentRow.Cells["musteri_id"].Value.ToString() + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            ds.Tables["Musteri"].Clear();
            kayıt_goster();
            MessageBox.Show("Kayıt silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Musteri WHERE musteri_id LIKE '%" + textBox7.Text + "%'", conn);
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
            textBox1.Text = dataGridView1.CurrentRow.Cells["musteri_id"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["musteri_ad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["musteri_soyad"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["musteri_adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["musteri_tel"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["musteri_mail"].Value.ToString();
        }
    }
}
