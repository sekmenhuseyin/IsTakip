namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmanAdi = c.String(nullable: false, maxLength: 40),
                        Durum = c.Boolean(nullable: false),
                        Url = c.String(nullable: false, maxLength: 40),
                        YoneticiId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Eleman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Eposta = c.String(nullable: false, maxLength: 30),
                        Sifre = c.String(nullable: false, maxLength: 25),
                        Ad = c.String(nullable: false, maxLength: 20),
                        Soyad = c.String(nullable: false, maxLength: 15),
                        Telefon = c.String(nullable: false, maxLength: 20),
                        AvatarResim = c.Binary(),
                        AvatarResimIsmi = c.String(),
                        AvatarResimTipi = c.String(),
                        Durum = c.Int(nullable: false),
                        DurumAciklamasi = c.String(maxLength: 255),
                        KayitTarihi = c.DateTime(nullable: false),
                        SonGiris = c.DateTime(nullable: false),
                        IzınGunSayisi = c.Int(nullable: false),
                        KullanilanToplamIzın = c.Int(nullable: false),
                        Url = c.String(nullable: false, maxLength: 36),
                        RolId = c.Int(nullable: false),
                        DepartmanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departman", t => t.DepartmanId, cascadeDelete: true)
                .ForeignKey("dbo.Rol", t => t.RolId, cascadeDelete: true)
                .Index(t => t.RolId)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Is",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsBasligi = c.String(nullable: false, maxLength: 75),
                        IsAciklamasi = c.String(nullable: false, maxLength: 255),
                        Durum = c.Int(nullable: false),
                        DurumAciklama = c.String(maxLength: 255),
                        Tarih = c.DateTime(nullable: false),
                        GuncellemeTarihi = c.DateTime(nullable: false),
                        BitisTarihi = c.DateTime(nullable: false),
                        Url = c.String(nullable: false, maxLength: 75),
                        DepartmanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departman", t => t.DepartmanId, cascadeDelete: true)
                .Index(t => t.DepartmanId);
            
            CreateTable(
                "dbo.IsMadde",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMaddeBasligi = c.String(nullable: false, maxLength: 50),
                        IsMaddeAciklamasi = c.String(nullable: false, maxLength: 255),
                        Durum = c.Int(nullable: false),
                        DurumAciklama = c.String(maxLength: 255),
                        IsMaddeTarih = c.DateTime(nullable: false),
                        IsMaddeGuncellemeTarih = c.DateTime(nullable: false),
                        IsMaddeBitisTarih = c.DateTime(nullable: false),
                        Url = c.String(nullable: false, maxLength: 50),
                        IsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Is", t => t.IsId, cascadeDelete: true)
                .Index(t => t.IsId);
            
            CreateTable(
                "dbo.Izin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IzinBasligi = c.String(nullable: false, maxLength: 50),
                        IzinAciklamasi = c.String(nullable: false, maxLength: 255),
                        IzinDurum = c.Int(nullable: false),
                        IzinDurumAciklamasi = c.String(maxLength: 255),
                        ElemanId = c.Int(nullable: false),
                        BaslangicTarihi = c.DateTime(nullable: false),
                        BitisTarihi = c.DateTime(nullable: false),
                        Url = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eleman", t => t.ElemanId, cascadeDelete: true)
                .Index(t => t.ElemanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Izin", "ElemanId", "dbo.Eleman");
            DropForeignKey("dbo.IsMadde", "IsId", "dbo.Is");
            DropForeignKey("dbo.Is", "DepartmanId", "dbo.Departman");
            DropForeignKey("dbo.Eleman", "RolId", "dbo.Rol");
            DropForeignKey("dbo.Eleman", "DepartmanId", "dbo.Departman");
            DropIndex("dbo.Izin", new[] { "ElemanId" });
            DropIndex("dbo.IsMadde", new[] { "IsId" });
            DropIndex("dbo.Is", new[] { "DepartmanId" });
            DropIndex("dbo.Eleman", new[] { "DepartmanId" });
            DropIndex("dbo.Eleman", new[] { "RolId" });
            DropTable("dbo.Izin");
            DropTable("dbo.IsMadde");
            DropTable("dbo.Is");
            DropTable("dbo.Rol");
            DropTable("dbo.Eleman");
            DropTable("dbo.Departman");
        }
    }
}
