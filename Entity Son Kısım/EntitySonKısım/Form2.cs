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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DBEntityEğitimEntities db = new DBEntityEğitimEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = db.Tbl_Urun.Count().ToString();
            //label1.Text = db.Tbl_Urun.Sum(x => x.STOKSAYISI).ToString();
            //label1.Text = db.Tbl_Urun.Count(x => x.AD == "TYT SETİ").ToString();
            //label1.Text = db.Tbl_Urun.Average(x => x.FIYAT).ToString();
            //label1.Text ="Ortalama TYT SET  fiyatı: " + db.Tbl_Urun.Where(x => x.AD == "TYT SETİ").Average(y => y.FIYAT).ToString();
            //label1.Text = (from x in db.Tbl_Urun
            //               orderby x.STOKSAYISI descending
            //               select x.AD).First();
            dataGridView1.DataSource = db.KULUPLER();


        }
    }
}
