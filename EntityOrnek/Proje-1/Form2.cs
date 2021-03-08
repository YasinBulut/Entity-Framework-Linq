using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        DBEntityEğitimEntities db = new DBEntityEğitimEntities();
        private void btnentity_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var degerler = db.Tbl_Not.Where(x => x.SINAV1 < 50);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton2.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.Where(x => x.AD == "ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton3.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.Where(x => x.AD == textBox1.Text || x.SOYAD == textBox1.Text);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton4.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.Select(x => new { soyadı = x.SOYAD });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton5.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.Select(x => new { Ad = x.AD.ToUpper(), Soyad = x.SOYAD.ToLower() });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton6.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.Select(x => new { Ad = x.AD.ToUpper(), Soyad = x.SOYAD.ToLower() }).Where(x => x.Ad != "Ali");
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton7.Checked == true)
            {
                var degerler = db.Tbl_Not.Select(x =>
                new
                {
                    OgrenciAd = x.OGR,
                    Ortalama = x.ORTALAMA,
                    Durum = x.DURUM == true ? "Geçti" : "Kaldı"

                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton8.Checked == true)
            {
                var degerler = db.Tbl_Not.SelectMany(x => db.Tbl_Ogrenci.Where(y => y.ID == x.OGR), (x, y) => new
                {
                    y.AD,
                    x.ORTALAMA,
                    Durum = x.DURUM == true ? "Geçti" : "Kaldı"
                });
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton9.Checked==true)
            {
                var degerler = db.Tbl_Ogrenci.OrderBy(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton10.Checked==true)
            {
                var degerler = db.Tbl_Ogrenci.OrderByDescending(x => x.ID).Take(3);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton11.Checked==true)
            {
                var degerler = db.Tbl_Ogrenci.OrderByDescending(x => x.AD);
                dataGridView1.DataSource = degerler.ToList();
            }
            if (radioButton12.Checked == true)
            {
                var degerler = db.Tbl_Ogrenci.OrderByDescending(x => x.ID).Skip(5);
                dataGridView1.DataSource = degerler.ToList();
            }
        }
    }
}
