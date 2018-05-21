namespace JOTB_Restauracja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Firmas", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Firmas", new[] { "Id" });
            AddColumn("dbo.AspNetUsers", "GNL", c => c.String());
            AddColumn("dbo.AspNetUsers", "Miasto", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ulica", c => c.String());
            AddColumn("dbo.AspNetUsers", "Wojewodztwo", c => c.String());
            AddColumn("dbo.AspNetUsers", "NumerKonta", c => c.String());
            AddColumn("dbo.AspNetUsers", "KodPocztowy", c => c.String());
            AddColumn("dbo.AspNetUsers", "NazwaFirmy", c => c.String());
            DropColumn("dbo.AspNetUsers", "Nazwa");

        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Firmas",
                c => new
                    {
                        FirmaId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 128),
                        NazwaFirmy = c.String(),
                        NumerTelefonu = c.String(),
                        Ulica = c.String(),
                        Miasto = c.String(),
                        Wojewodztwo = c.String(),
                        KodPocztowy = c.String(),
                        GNL = c.String(),
                        NIP = c.String(),
                        NumerKonta = c.String(),
                    })
                .PrimaryKey(t => t.FirmaId);
            
            AddColumn("dbo.AspNetUsers", "Nazwa", c => c.String());
            DropColumn("dbo.AspNetUsers", "NazwaFirmy");
            DropColumn("dbo.AspNetUsers", "KodPocztowy");
            DropColumn("dbo.AspNetUsers", "NumerKonta");
            DropColumn("dbo.AspNetUsers", "Wojewodztwo");
            DropColumn("dbo.AspNetUsers", "Ulica");
            DropColumn("dbo.AspNetUsers", "Miasto");
            DropColumn("dbo.AspNetUsers", "GNL");
        }
    }
}
