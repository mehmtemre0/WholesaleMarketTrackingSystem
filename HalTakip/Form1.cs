using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //Access bağlantı dosyaları

namespace mal_kabul_sistemi
{
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbConnection con;

        public Form1()
        {
            InitializeComponent();
        }
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * from sebze", baglanti);
            adtr.Fill(ds, "sebze");
            dataGridView1.DataSource = ds.Tables["sebze"];
            adtr.Dispose();
            baglanti.Close();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            {
                con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hal.accdb");
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tedarikci ORDER BY id_no ASC ", con);
                da.Fill(dt);
                uk.ValueMember = "id_no";
                uk.DisplayMember = "sirket_adi";
                uk.DataSource = dt;

            }


            uk.Text = Form3.sirketveri;
            ud.Text = Form3.urunveri;


            listele();
        }
        // silme bölümü
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Delete from sebze where s_no=" + sira.Text + "";
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            ds.Clear();
            listele();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        //kayıt ekle
        private void button3_Click(object sender, EventArgs e)
        {
            //label11.Text = pictureBox1.ImageLocation;
            if (uk.Text != "" && ud.Text != "" && ubf.Text != "" && um.Text != "" && utf.Text != "" && uo.Text != "" && uc.Text != "" && dateTimePicker1.Text != "")
            {
                komut.Connection = baglanti;
                komut.CommandText = "Insert Into sebze(sirket_no,mal_adi,mal_fiyati,miktari,toplam_fiyat,omru,cinsi,tarih) Values ('" + uk.Text + "','" + ud.Text + "','" + ubf.Text + "','" + um.Text + "','" + utf.Text + "','" + uo.Text + "','" + uc.Text + "' , '" + dateTimePicker1.Value + "')";
                baglanti.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglanti.Close();
                MessageBox.Show("Kayıt Tamamlandı!");
                ds.Clear();
                listele();
            }
            else
            {
                MessageBox.Show("Boş alan geçmeyiniz!");
            }
        }
        //kayıt arama
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hal.accdb");
            adtr = new OleDbDataAdapter("Select * from sebze where s_no like '" + sira.Text + "%'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            adtr.Fill(ds, "sebze");
            dataGridView1.DataSource = ds.Tables["sebze"];
            baglanti.Close();
        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            sira.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mehmet Emre Akçay 200017733");
        }

        private void ur_TextChanged(object sender, EventArgs e)
        {

        }

       // takvim script
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=hal.accdb");
            adtr = new OleDbDataAdapter("Select * from sebze where tarih like '" + dateTimePicker1.Value.Date + "%'", baglanti);
            ds = new DataSet();
            baglanti.Open();
            adtr.Fill(ds, "sebze");
            dataGridView1.DataSource = ds.Tables["sebze"];
            baglanti.Close();
        }

        private void uk_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uk.SelectedIndex != -1)
            {
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from mallar where sirket_adi = " + uk.SelectedValue, con);
                da.Fill(dt);
                ud.ValueMember = "sirket_adi";
                ud.DisplayMember = "urunler";
                ud.DataSource = dt;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





