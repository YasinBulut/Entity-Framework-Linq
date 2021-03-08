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

namespace Proje_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        DBEntityEğitimEntities db = new DBEntityEğitimEntities();
        private void btnderliste_Click(object sender, EventArgs e)
        {
            SqlConnection baglantı = new SqlConnection(@"Data Source=DESKTOP-FEPGLU4;Initial Catalog=DBEntityEğitim;Integrated Security=True");
            SqlCommand komut = new SqlCommand("select * from tbl_ders", baglantı);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridView1.DataSource = db.Tbl_Not.ToList();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Ogrenci.ToList();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }

        private void btnnotlist_Click(object sender, EventArgs e)
        {
            var query = from item in db.Tbl_Not
                        select new
                        {
                            item.NOTID,
                            item.Tbl_Ogrenci.AD,
                            item.Tbl_Ogrenci.SOYAD,
                            item.Tbl_Ders.DERSAD,
                            item.SINAV1,
                            item.SINAV2,
                            item.SINAV3,
                            item.ORTALAMA,
                            item.DURUM
                        };
            dataGridView1.DataSource = query.ToList();
            //dataGridView1.DataSource = db.Tbl_Not.ToList();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            Tbl_Ogrenci t = new Tbl_Ogrenci();
            t.AD = txtogrenciad.Text;
            t.SOYAD = txtogrencisoyad.Text;
            //t.FOTOGRAF = txtogrencifoto.Text;
            db.Tbl_Ogrenci.Add(t);
            db.SaveChanges();
            MessageBox.Show("ÖĞRENCİ  EKLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtogrenciıd.Text);
            var x = db.Tbl_Ogrenci.Find(id);
            db.Tbl_Ogrenci.Remove(x);
            db.SaveChanges();
            MessageBox.Show("ÖĞRENCİ SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtogrenciıd.Text);
            var x = db.Tbl_Ogrenci.Find(id);
            x.AD = txtogrenciad.Text;
            x.SOYAD = txtogrencisoyad.Text;
            x.FOTOGRAF = txtogrencifoto.Text;
            db.SaveChanges();
            MessageBox.Show("ÖĞRENCİ GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtogrenciıd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtogrenciad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtogrencisoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            //txts1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //txts2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            //txts3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            //txtortalama.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            //txtdurum.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            //txtdersad.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            //txtdersıd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTESI();
        }

        private void btnbul_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Tbl_Ogrenci.Where(x => x.AD == txtogrenciad.Text).ToList();
        }

        private void txtogrenciad_TextChanged(object sender, EventArgs e)
        {
            //string aranan = txtogrenciad.Text;
            //var degerler = from item in db.Tbl_Ogrenci
            //               where item.AD.Contains(aranan)
            //               select item;
            //dataGridView1.DataSource = degerler.ToList(); 
        }

        private void btnlinq_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //asc-ascending
                List<Tbl_Ogrenci> liste1 = db.Tbl_Ogrenci.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked == true)
            {
                //desc-descending
                List<Tbl_Ogrenci> liste2 = db.Tbl_Ogrenci.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = liste2;
            }
            if (radioButton3.Checked == true)
            {
                List<Tbl_Ogrenci> liste3 = db.Tbl_Ogrenci.OrderBy(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = liste3;
            }
            if (radioButton4.Checked == true)
            {
                List<Tbl_Ogrenci> liste4 = db.Tbl_Ogrenci.Where(p => p.ID == 5).ToList();
                dataGridView1.DataSource = liste4;
            }
            if (radioButton5.Checked == true)
            {
                List<Tbl_Ogrenci> liste5 = db.Tbl_Ogrenci.Where(p => p.AD.StartsWith("a")).ToList();
                dataGridView1.DataSource = liste5;
            }
            if (radioButton6.Checked == true)
            {
                List<Tbl_Ogrenci> liste6 = db.Tbl_Ogrenci.Where(p => p.AD.EndsWith("a")).ToList();
                dataGridView1.DataSource = liste6;
            }
            if (radioButton7.Checked == true)
            {
                bool deger = db.Tbl_Ogrenci.Any();
                MessageBox.Show(deger.ToString(), "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton8.Checked == true)
            {
                int toplam = db.Tbl_Ogrenci.Count();
                MessageBox.Show(toplam.ToString(), "TOPLAM ÖĞRENCİ SAYISI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton9.Checked == true)
            {
                //SINAV-1 TOPLAMI   
                //var toplam = db.Tbl_Not.Sum(p => p.SINAV1);
                //MessageBox.Show(toplam.ToString(), "SINAV-1 ORTALAMA ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var ORTALAMA = db.Tbl_Not.Average(p => p.SINAV1);
                MessageBox.Show(ORTALAMA.ToString(), "SINAV-1 ORTALAMA ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton10.Checked == true)
            {
                var ORTALAMA = db.Tbl_Not.Average(p => p.SINAV2);
                MessageBox.Show(ORTALAMA.ToString(), "SINAV-2 ORTALAMA ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton11.Checked == true)
            {
                var ORTALAMA = db.Tbl_Not.Average(p => p.SINAV3);
                MessageBox.Show(ORTALAMA.ToString(), "SINAV-3 ORTALAMA ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton12.Checked == true)
            {
                var enyuksek = db.Tbl_Not.Max(p => p.SINAV1);
                MessageBox.Show(enyuksek.ToString(), "SINAV-1 EN YÜKSEK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton13.Checked == true)
            {
                var enyuksek = db.Tbl_Not.Max(p => p.SINAV2);
                MessageBox.Show(enyuksek.ToString(), "SINAV-2 EN YÜKSEK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton14.Checked == true)
            {
                var enyuksek = db.Tbl_Not.Max(p => p.SINAV3);
                MessageBox.Show(enyuksek.ToString(), "SINAV-3 EN YÜKSEK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton15.Checked == true)
            {
                var endusuk = db.Tbl_Not.Min(p => p.SINAV1);
                MessageBox.Show(endusuk.ToString(), "SINAV-1 EN DÜŞÜK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton16.Checked == true)
            {
                var endusuk = db.Tbl_Not.Min(p => p.SINAV2);
                MessageBox.Show(endusuk.ToString(), "SINAV-2 EN DÜŞÜK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton17.Checked == true)
            {
                var endusuk = db.Tbl_Not.Min(p => p.SINAV3);
                MessageBox.Show(endusuk.ToString(), "SINAV-3 EN DÜŞÜK NOTU ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (radioButton18.Checked==true)
            //{
            //    var yuksek = db.Tbl_Not.Max(p => p.SINAV1);
            //    var sorgu = from item in db.NOTLISTESI().Where(p => p.SINAV1 == yuksek)
            //                select new { item.AD_SOYAD };
            //    dataGridView1.DataSource = sorgu.ToList();
            //    MessageBox.Show(sorgu.ToString(), "SINIFIN GURURU ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }

        private void BTNJOİN_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.Tbl_Not
                        join d2 in db.Tbl_Ogrenci
                        on d1.OGR equals d2.ID
                        join d3 in db.Tbl_Ders
                        on d1.DERS equals d3.DERSID
                        select new
                        {
                            OGRENCİ = d2.AD +" "+d2.SOYAD,
                            DERS=d3.DERSAD,
                            SINA1 = d1.SINAV1,
                            SINAV2 = d1.SINAV2,
                            SINAV3 = d1.SINAV3,
                            ORTALAMA = d1.ORTALAMA,
                            DURUM = d1.DURUM
                        };
            dataGridView1.DataSource = sorgu.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();

        }
    }
}

