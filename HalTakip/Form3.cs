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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static string sirketveri;
        public static string urunveri;

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();


        private void Form3_Load(object sender, EventArgs e)
        {
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tedarikci ORDER BY id_no ASC ", con);
                da.Fill(dt);
                comboBox1.ValueMember = "id_no";
                comboBox1.DisplayMember = "sirket_adi";
                comboBox1.DataSource = dt;

            }


        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from mallar where sirket_adi = " + comboBox1.SelectedValue, con);
                da.Fill(dt);
                comboBox2.ValueMember = "sirket_adi";
                comboBox2.DisplayMember = "urunler";
                comboBox2.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;


            sirketveri = comboBox1.Text;
            urunveri = comboBox2.Text;
            
            Form1 f2 = new Form1();
            f2.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

