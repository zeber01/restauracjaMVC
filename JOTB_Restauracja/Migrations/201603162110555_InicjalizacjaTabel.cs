namespace JOTB_Restauracja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicjalizacjaTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaniaModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nazwa = c.String(nullable: false),
                        Cena = c.Single(nullable: false),
                        Kategoria = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DaniaProduktyModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IdDania = c.String(maxLength: 128),
                        IdProdukt = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DaniaModels", t => t.IdDania)
                .ForeignKey("dbo.ProduktyModels", t => t.IdProdukt)
                .Index(t => t.IdDania)
                .Index(t => t.IdProdukt);
            
            CreateTable(
                "dbo.ProduktyModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nazwa = c.String(nullable: false, maxLength: 250),
                        Jednostka = c.String(nullable: false),
                        Koszt = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Nazwa, unique: true);
            
            CreateTable(
                "dbo.PracownikModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Nazwisko = c.String(nullable: false),
                        Imie = c.String(nullable: false),
                        PESEL = c.String(nullable: false),
                        Stanowisko = c.String(),
                        Wynagrodzenie = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZamowienieModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        data = c.DateTime(nullable: false),
                        Zrealizowane = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ZamowienieDanieModels",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IdZamowienia = c.String(maxLength: 128),
                        IdDania = c.String(maxLength: 128),
                        Ilosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DaniaModels", t => t.IdDania)
                .ForeignKey("dbo.ZamowienieModels", t => t.IdZamowienia)
                .Index(t => t.IdZamowienia)
                .Index(t => t.IdDania);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ZamowienieDanieModels", "IdZamowienia", "dbo.ZamowienieModels");
            DropForeignKey("dbo.ZamowienieDanieModels", "IdDania", "dbo.DaniaModels");
            DropForeignKey("dbo.DaniaProduktyModels", "IdProdukt", "dbo.ProduktyModels");
            DropForeignKey("dbo.DaniaProduktyModels", "IdDania", "dbo.DaniaModels");
            DropIndex("dbo.ZamowienieDanieModels", new[] { "IdDania" });
            DropIndex("dbo.ZamowienieDanieModels", new[] { "IdZamowienia" });
            DropIndex("dbo.ProduktyModels", new[] { "Nazwa" });
            DropIndex("dbo.DaniaProduktyModels", new[] { "IdProdukt" });
            DropIndex("dbo.DaniaProduktyModels", new[] { "IdDania" });
            DropTable("dbo.ZamowienieDanieModels");
            DropTable("dbo.ZamowienieModels");
            DropTable("dbo.PracownikModels");
            DropTable("dbo.ProduktyModels");
            DropTable("dbo.DaniaProduktyModels");
            DropTable("dbo.DaniaModels");
        }
    }
}
