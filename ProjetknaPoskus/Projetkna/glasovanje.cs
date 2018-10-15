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
    public partial class glasovanje : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public glasovanje()
        {
            InitializeComponent();
        }


        private void Zapri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mm = new Main();
            mm.Show();

        }

        private void glasovanje_Load(object sender, EventArgs e)
        {
            string ime = "";
            string pesem = "";

            MySqlConnection conn = new MySqlConnection(dbConnectionString);

            conn.Open();
            string query = ("SELECT izvajalec_ime FROM muzike;");
            MySqlCommand pek = new MySqlCommand(query, conn);

            MySqlDataReader reader = pek.ExecuteReader();


            while (reader.Read())
            {
                reader.GetString(0);
                comboBox1.Items.Add(reader.GetString(0));


            }
            reader.Close();
            pek.Dispose();
        }
      
        int st = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(dbConnectionString);
            con.Open();
            //*Da lahko samo enkrat glasuje
            if (st < 1)
            {
                st++;
                string izvajalec = "";
                string pesem = "";
                izvajalec = this.comboBox1.SelectedItem.ToString();
                 pesem = this.comboBox2.SelectedItem.ToString();
                string query = ("UPDATE muzike SET glasovi=glasovi +1 WHERE (Izvajalec_ime='" + izvajalec + "') AND (glasba_ime='" + pesem + "');");
                MySqlCommand pet = new MySqlCommand(query, con);

                





                pet.ExecuteNonQuery();

                pet.Dispose();





            }

            else
                MessageBox.Show("Glas se ni zabeležil, ste že glasovali");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            dodajanje mm = new dodajanje();
            mm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(dbConnectionString);

            conn.Open();
            string jaa = ("SELECT glasba_ime FROM muzike WHERE izvajalec_ime='" + comboBox1.SelectedItem + "';");
            MySqlCommand tri = new MySqlCommand(jaa, conn);

            MySqlDataReader sedem = tri.ExecuteReader();


            while (sedem.Read())
            {
                sedem.GetString(0);
                comboBox2.Items.Add(sedem.GetString(0));


            }
            sedem.Close();
        }
    }

}

    
    
    
    
    
    
    
    
    
    


