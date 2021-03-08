namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameKategoriADIToKategoriADInKategorisTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "KategoriAD", c => c.String());
            //Sql("Update Kategoris Set KategoriAd=KategoriAdi"); //verileri kaybetmeden isim değişikliği yapmak için
            DropColumn("dbo.Kategoris", "KategoriADI");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "KategoriADI", c => c.String());
            //Sql("Update Kategoris Set KategoriAdi=KategoriAd"); // verileri kaybetmeden isim değişikliği yapmak için
            DropColumn("dbo.Kategoris", "KategoriAD");
        }
    }
}
