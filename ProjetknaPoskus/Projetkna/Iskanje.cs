using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projetkna
{
    public partial class Iskanje : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public Iskanje()
        {
            InitializeComponent();
        }

        private void Iskanje_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Ime Izvajalca");
            listView1.Columns.Add("Ime pesmi");
            listView2.View = View.Details;
            listView2.Columns.Add("Ime pesmi");
            listView2.Columns.Add("zvrst");
            comboBox1.Items.Add("Pop");
            comboBox1.Items.Add("Hip-Hop");
            comboBox1.Items.Add("Goveja");

            MySqlConnection conn = new MySqlConnection(dbConnectionString);


            conn.Open();
            string query = ("SELECT izvajalec_ime FROM muzike;");
            MySqlCommand comm = new MySqlCommand(query, conn);



            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                reader.GetString(0);

                comboBox2.Items.Add(reader.GetString(0));

            }
            reader.Close();

        }

    
        

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(dbConnectionString);


            conn.Open();
            string izbrano = "";
            izbrano = this.comboBox1.SelectedItem.ToString();
            string aa = ("SELECT izvajalec_ime,glasba_ime FROM muzike WHERE zvrst='" + izbrano + "';");
            MySqlCommand com = new MySqlCommand(aa, conn);
           

                    

            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
                    {
                        var item = new ListViewItem();

                        item.Text = reader["izvajalec_ime"].ToString();
                        item.SubItems.Add(reader["glasba_ime"].ToString());


                        listView1.Items.Add(item);
                    }
                    reader.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string izbrano2 = "";
            izbrano2 = this.comboBox2.SelectedItem.ToString();

            MySqlConnection conn = new MySqlConnection(dbConnectionString);


            conn.Open();
            string izbrano = "";
            izbrano = this.comboBox1.SelectedItem.ToString();
            string aa = ("SELECT glasba_ime,zvrst FROM muzike WHERE izvajalec_ime='" + izbrano2 + "';");
            MySqlCommand com2 = new MySqlCommand(aa, conn);
            MySqlDataReader reader = com2.ExecuteReader();
          
              

                  

                    while (reader.Read())
                    {
                        var item2= new ListViewItem();

                        item2.Text = reader["glasba_ime"].ToString();
                        item2.SubItems.Add(reader["zvrst"].ToString());

                        listView2.Items.Add(item2);
                    }
                    reader.Close();

                
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Izvajalec");
            listView1.Columns.Add("Ime pesmi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView2.Clear();
            listView2.View = View.Details;
            listView2.Columns.Add("Ime pesmi");
            listView2.Columns.Add("zvrst");
        }
    }
}

