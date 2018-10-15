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
    public partial class LogIn : Form
    {
        string dbConnectionString = ("data source=sql7.freemysqlhosting.net; username=sql7261113; password=vmTuupzZjt; database=sql7261113; SslMode=none");

        public LogIn()
        {
            InitializeComponent();
        }
        MySqlDataAdapter adapter;

        DataTable table = new DataTable();
        private void LogIn_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(dbConnectionString);
           
            conn.Open();

            adapter = new MySqlDataAdapter("SELECT ime, geslo FROM uporabniki WHERE ime = '" + textBox1.Text + "' AND geslo = '" + textBox2.Text + "'", conn);
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {

                MessageBox.Show("Username Or Password Are Invalid");
            }
            else
            {
               
                this.Hide();
                Main mm = new Main();
                mm.Show();
            }

            table.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplikacija je bila ustvarjena s pomočjo c#. Matevž Glinšek 2018");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Za morebitno pomoč se obrnite na telefonsko števiko 040 272 287");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Registracija aa = new Registracija();
            aa.Show();
        }
    }
}
