using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projetkna
{
    public partial class Registracija : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public Registracija()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
                MySqlConnection conn = new MySqlConnection(dbConnectionString);
                conn.Open();


                string query = ("INSERT INTO uporabniki (ime,geslo) Values('" + textBox1.Text + "','" + textBox2.Text + "');");
                MySqlCommand pov = new MySqlCommand(query, conn);




                pov.ExecuteNonQuery();

                pov.Dispose();
         }

        private void button2_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}

