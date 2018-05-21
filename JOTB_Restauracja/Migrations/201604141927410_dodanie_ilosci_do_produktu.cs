namespace JOTB_Restauracja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_ilosci_do_produktu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProduktyModels", "Ilosc", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProduktyModels", "Ilosc");
        }
    }
}
