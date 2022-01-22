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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=localhost;User ID=SYSTEM;Password=Bosti.88;Unicode=True");

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;

            OleDbDataAdapter da = new OleDbDataAdapter("select count(*) from Personel where PERSONEL_SIFRE='" + password + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (password.Equals(""))
            {
                MessageBox.Show("Şifre Alanı Boş Bırakılamaz!");
            }
            else if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Giriş başarılı!");
                Form6 fr6 = new Form6();
                fr6.ShowDialog();
                //form6.Show();
                this.Hide();

              
            }
            else
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!");

        }
    }
}
