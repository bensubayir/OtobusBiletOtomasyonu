using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtubeotobus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Data Source=DESKTOP-FTGV0SD\SQLEXPRESS;Initial Catalog=otobbusdeneme;Integrated Security=True
        SqlConnection baglanti =new SqlConnection(@"Data Source=DESKTOP-FTGV0SD\\SQLEXPRESS;Initial Catalog=otobbusdeneme;Integrated Security=True");
        void seferlistesi()
        {
            SqlDataAdapter da =new SqlDataAdapter("select * from tblsefer",baglanti);
            DataTable dt = new DataTable(); 
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            baglanti.ConnectionString = "Data Source=DESKTOP-FTGV0SD\\SQLEXPRESS;Initial Catalog=otobbusdeneme;Integrated Security=True";
            SqlCommand komut = new SqlCommand();
            komut.CommandText= "SELECT Otobus FROM tblsefer";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr;
            baglanti.Open();
            dr= komut.ExecuteReader();
            while (dr.Read())
            {
                cmbOtobus.Items.Add(dr["Otobus"]);
            }
            baglanti.Close();
            komut.CommandText = "SELECT Kalkis FROM tblsefer";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr2;
            baglanti.Open();
            dr2 = komut.ExecuteReader();
            while (dr2.Read())
            {
                cmbKalkis.Items.Add(dr2["Kalkis"]);
            }
            baglanti.Close();
            komut.CommandText = "SELECT Varis FROM tblsefer";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr3;
            baglanti.Open();
            dr3 = komut.ExecuteReader();
            while (dr3.Read())
            {
                cmbVaris.Items.Add(dr3["Varis"]);
            }
            baglanti.Close();
         /*   komut.CommandText = "SELECT Fiyat FROM tblsefer";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;
            SqlDataReader dr4;
            baglanti.Open();
            dr4 = komut.ExecuteReader();
            while (dr4.Read())
            {
                cmbFiyat.Items.Add(dr4["Fiyat"]);
            }
            baglanti.Close();*/
            seferlistesi();
           



        }

        private void cmbOtobus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOtobus.Text)
            {
                case "KamilKoç":
                    KoltukDoldur(12, false);
                    break;
                case "Pamukkale":
                    KoltukDoldur(12, true);
                    break;
                case "Varan":
                    KoltukDoldur(10, false);
                    break;
                case "Safran Turizm":
                    KoltukDoldur(10, true);
                    break;





            }
            void KoltukDoldur(int sira, bool arkaBesliMi)
            {
                yavaslat:
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is Button)
                    {
                        Button btn = ctrl as Button;
                        if (btn.Text == "Kaydet")
                        {
                            continue;
                        }
                        else
                        {
                            this.Controls.Remove(ctrl);
                            goto yavaslat;
                        }
                    }
                }
                int koltukNo = 1;
                for (int i = 0; i < sira; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (arkaBesliMi == true)
                        {
                            if (i != sira - 1 && j == 2)
                            {
                                continue;
                            }
                        }
                        else { 
                        if (j == 2)
                            continue;
                        }
                        Button koltuk = new Button();
                        koltuk.Height = koltuk.Width = 40;
                        koltuk.Top = 30 + (i * 45);
                        koltuk.Left = 5 + (j * 45);
                        koltuk.Text = koltukNo.ToString();
                        koltukNo++;
                        koltuk.ContextMenuStrip = contextMenuStrip1;
                        koltuk.MouseDown += Koltuk_MouseDown;
                        this.Controls.Add(koltuk);

                    }
                }
            }
        }
        Button tiklanan;
        private void Koltuk_MouseDown(object sender, MouseEventArgs e)
        {
            tiklanan = sender as Button;
            
        }

        private void cmbKalkis_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void rezerveEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cmbOtobus.SelectedIndex == -1 || cmbKalkis.SelectedIndex == -1||cmbVaris.SelectedIndex == -1){
                MessageBox.Show("Lütfen önce gerekli alanları doldurunuz.");
                return;
            }
            KayıtFormu kf= new KayıtFormu();
           DialogResult sonuc= kf.ShowDialog();
           /* if (sonuc == DialogResult.OK)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = string.Format("{0} {1}", kf.txtİsim.Text, kf.txtSoyad.Text);
                lvi.SubItems.Add(kf.mskTelefon.Text);
               
                lvi.SubItems.Add(cmbKalkis.Text);
                lvi.SubItems.Add(cmbVaris.Text);
                lvi.SubItems.Add(tiklanan.Text);
                lvi.SubItems.Add(dtpTarih.Text);
                lvi.SubItems.Add(cmbFiyat.Text);
                listView1.Items.Add(lvi);

           } */
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cmbFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

    }
}
