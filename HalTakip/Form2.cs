using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace mal_kabul_sistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr; 
        private void button1_Click(object sender, EventArgs e)
        {
            string ad = kullanici.Text;
            string sifre = tsifre.Text;
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM login where k_adi = '" + kullanici.Text + "' AND k_sifre = '" + tsifre.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Form3 f2 = new Form3();
                f2.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("hatalı");
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
