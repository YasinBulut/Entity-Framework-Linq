namespace SihirbazKullanım
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Urunler
    {
        [Key]
        public int URUNID { get; set; }

        public string URUNAD { get; set; }

        public string URUNMARKA { get; set; }

        public string URUNKATEGORİ { get; set; }

        public int URUNSTOK { get; set; }

        public string Aciklama { get; set; }

        public int? Kategori_KategoriID { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
