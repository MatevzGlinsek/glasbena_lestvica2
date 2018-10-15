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
using MySql.Data.MySqlClient;

namespace Projetkna
{
    public partial class Main : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public Main()
        {
            InitializeComponent();
        }

        private void buttonZapri_Click(object sender, EventArgs e)
        {

            this.Close();
            glasovanje mm = new glasovanje();
            mm.Show();


        }

        private void Main_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Izvajalec");
            listView1.Columns.Add("Ime pesmi");
            listView1.Columns.Add("Zvrst");
            int aa = 0;

            MySqlConnection conn = new MySqlConnection(dbConnectionString);
            //SqlConnection conn = new SqlConnection("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");
           
           
            conn.Open();

            string query = ("SELECT izvajalec_ime,glasba_ime,zvrst FROM muzike LIMIT 5;");
            MySqlCommand comm = new MySqlCommand(query, conn);
            //SqlCommand ja = new SqlCommand("SELECT izvajalec_ime,glasba_ime,zvrst FROM muzike LIMIT 5;");
                
                    
                    //ja.ExecuteNonQuery();

                    MySqlDataReader reader = comm.ExecuteReader();
                   
                    while (reader.Read())
                    {
                        aa ++;
                        var item = new ListViewItem();
                        
                        item.Text = reader["izvajalec_ime"].ToString();       
                        item.SubItems.Add(reader["glasba_ime"].ToString()); 
                        item.SubItems.Add(reader["zvrst"].ToString());
                        listView1.Items.Add(item);
                    }
                    conn.Close();
                
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Iskanje mm = new Iskanje();
            mm.Show();
        }
    }
}
