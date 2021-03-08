namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameKategoriADToKategoriADIInKategorisTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kategoris", "KategoriADI", c => c.String());
            DropColumn("dbo.Kategoris", "KategoriAD");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "KategoriAD", c => c.String());
            DropColumn("dbo.Kategoris", "KategoriADI");
        }
    }
}
