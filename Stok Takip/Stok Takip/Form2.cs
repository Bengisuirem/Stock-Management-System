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
    public partial class yonetici : Form
    {
        public yonetici()
        {
            InitializeComponent();
        }

        OleDbConnection conn = new OleDbConnection("Provider=OraOLEDB.Oracle;Data Source=localhost;User ID=SYSTEM;Password=Bosti.88;Unicode=True");

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }
    }
}
