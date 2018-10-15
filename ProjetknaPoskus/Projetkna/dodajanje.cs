using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace Projetkna
{
    public partial class dodajanje : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public dodajanje()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            conn.Open();


            string query = ("INSERT INTO muzike (izvajalec_ime,glasba_ime,zvrst,glasovi) Values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "',0);");
            MySqlCommand pov = new MySqlCommand(query, conn);




            pov.ExecuteNonQuery();

            pov.Dispose();






            conn.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            glasovanje mm = new glasovanje();
            mm.Show();
        }
    }
}

