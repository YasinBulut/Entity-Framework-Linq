namespace EntityCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMusterisTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        MsteriID = c.Int(nullable: false, identity: true),
                        MusteriAD = c.String(),
                        MusteriSoyad = c.String(),
                    })
                .PrimaryKey(t => t.MsteriID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musteris");
        }
    }
}
