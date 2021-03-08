namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteKategoriDetayColumnInKategorisTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kategoris", "KategoriDETAY");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kategoris", "KategoriDETAY", c => c.String());
        }
    }
}
