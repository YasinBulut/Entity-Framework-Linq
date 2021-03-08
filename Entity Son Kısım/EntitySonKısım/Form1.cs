using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntitySonKısım
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBEntityEğitimEntities db = new DBEntityEğitimEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            var degerler = db.Tbl_Ogrenci.OrderBy(x => x.SEHIR).GroupBy(y => y.SEHIR).
                Select(z => new { Sehir = z.Key, Toplam = z.Count() });
            dataGridView1.DataSource = degerler.ToList(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = db.Tbl_Not.Max(x => x.ORTALAMA).ToString();
            label2.Text=db.Tbl_Not.Min(x => x.ORTALAMA).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
