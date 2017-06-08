namespace _2013100788_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lul : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdministradorEquipos",
                c => new
                    {
                        AdmiEquipId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        EquipCelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmiEquipId)
                .ForeignKey("dbo.EquipoCelulars", t => t.EquipCelId, cascadeDelete: true)
                .Index(t => t.EquipCelId);
            
            CreateTable(
                "dbo.EquipoCelulars",
                c => new
                    {
                        EquipCelId = c.Int(nullable: false),
                        descrip = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.EquipCelId)
                .ForeignKey("dbo.Evaluacions", t => t.EquipCelId)
                .Index(t => t.EquipCelId);
            
            CreateTable(
                "dbo.Evaluacions",
                c => new
                    {
                        EvalId = c.Int(nullable: false),
                        desc = c.String(nullable: false, maxLength: 255),
                        EquipCelId = c.Int(nullable: false),
                        TipoPlan = c.Byte(nullable: false),
                        Plan = c.Byte(nullable: false),
                        LinTelfId = c.Int(nullable: false),
                        TrabaId = c.Int(nullable: false),
                        EstEvaId = c.Int(nullable: false),
                        TipoEvaluacion = c.Byte(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        CenAteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvalId)
                .ForeignKey("dbo.CentroAtencions", t => t.CenAteId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajadors", t => t.TrabaId, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.EvalId)
                .Index(t => t.EvalId)
                .Index(t => t.TrabaId)
                .Index(t => t.CenAteId);
            
            CreateTable(
                "dbo.CentroAtencions",
                c => new
                    {
                        CenAteId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.CenAteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Evaluacions", t => t.ClienteId)
                .ForeignKey("dbo.Ventas", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        LinTelfId = c.Int(nullable: false),
                        EvalId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        TipoPago = c.Byte(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        CenAteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.CentroAtencions", t => t.CenAteId, cascadeDelete: true)
                .ForeignKey("dbo.LineaTelefonicas", t => t.LinTelfId, cascadeDelete: true)
                .Index(t => t.LinTelfId)
                .Index(t => t.CenAteId);
            
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        ContratoId = c.Int(nullable: false),
                        desc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ContratoId)
                .ForeignKey("dbo.Ventas", t => t.ContratoId)
                .Index(t => t.ContratoId);
            
            CreateTable(
                "dbo.LineaTelefonicas",
                c => new
                    {
                        LinTelfId = c.Int(nullable: false),
                        desc = c.String(nullable: false, maxLength: 255),
                        TipoLinea = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.LinTelfId)
                .ForeignKey("dbo.Evaluacions", t => t.LinTelfId)
                .Index(t => t.LinTelfId);
            
            CreateTable(
                "dbo.AdministradorLineas",
                c => new
                    {
                        AdmiLinId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        LinTelfId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdmiLinId)
                .ForeignKey("dbo.LineaTelefonicas", t => t.LinTelfId, cascadeDelete: true)
                .Index(t => t.LinTelfId);
            
            CreateTable(
                "dbo.EstadoEvaluacions",
                c => new
                    {
                        EstEvaId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.EstEvaId)
                .ForeignKey("dbo.Evaluacions", t => t.EstEvaId)
                .Index(t => t.EstEvaId);
            
            CreateTable(
                "dbo.Trabajadors",
                c => new
                    {
                        TrabaId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        TipoTrabajador = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TrabaId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DirId = c.Int(nullable: false),
                        desc = c.String(nullable: false, maxLength: 255),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirId)
                .ForeignKey("dbo.CentroAtencions", t => t.DirId)
                .Index(t => t.DirId);
            
            CreateTable(
                "dbo.Ubigeos",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false),
                        desc = c.String(nullable: false, maxLength: 255),
                        Departamento = c.Byte(nullable: false),
                        Provincia = c.Byte(nullable: false),
                        Distrito = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId)
                .ForeignKey("dbo.Direccions", t => t.UbigeoId)
                .Index(t => t.UbigeoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ubigeos", "UbigeoId", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "DirId", "dbo.CentroAtencions");
            DropForeignKey("dbo.EquipoCelulars", "EquipCelId", "dbo.Evaluacions");
            DropForeignKey("dbo.Evaluacions", "EvalId", "dbo.Ventas");
            DropForeignKey("dbo.Evaluacions", "TrabaId", "dbo.Trabajadors");
            DropForeignKey("dbo.EstadoEvaluacions", "EstEvaId", "dbo.Evaluacions");
            DropForeignKey("dbo.Clientes", "ClienteId", "dbo.Ventas");
            DropForeignKey("dbo.Ventas", "LinTelfId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.LineaTelefonicas", "LinTelfId", "dbo.Evaluacions");
            DropForeignKey("dbo.AdministradorLineas", "LinTelfId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Contratos", "ContratoId", "dbo.Ventas");
            DropForeignKey("dbo.Ventas", "CenAteId", "dbo.CentroAtencions");
            DropForeignKey("dbo.Clientes", "ClienteId", "dbo.Evaluacions");
            DropForeignKey("dbo.Evaluacions", "CenAteId", "dbo.CentroAtencions");
            DropForeignKey("dbo.AdministradorEquipos", "EquipCelId", "dbo.EquipoCelulars");
            DropIndex("dbo.Ubigeos", new[] { "UbigeoId" });
            DropIndex("dbo.Direccions", new[] { "DirId" });
            DropIndex("dbo.EstadoEvaluacions", new[] { "EstEvaId" });
            DropIndex("dbo.AdministradorLineas", new[] { "LinTelfId" });
            DropIndex("dbo.LineaTelefonicas", new[] { "LinTelfId" });
            DropIndex("dbo.Contratos", new[] { "ContratoId" });
            DropIndex("dbo.Ventas", new[] { "CenAteId" });
            DropIndex("dbo.Ventas", new[] { "LinTelfId" });
            DropIndex("dbo.Clientes", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacions", new[] { "CenAteId" });
            DropIndex("dbo.Evaluacions", new[] { "TrabaId" });
            DropIndex("dbo.Evaluacions", new[] { "EvalId" });
            DropIndex("dbo.EquipoCelulars", new[] { "EquipCelId" });
            DropIndex("dbo.AdministradorEquipos", new[] { "EquipCelId" });
            DropTable("dbo.Ubigeos");
            DropTable("dbo.Direccions");
            DropTable("dbo.Trabajadors");
            DropTable("dbo.EstadoEvaluacions");
            DropTable("dbo.AdministradorLineas");
            DropTable("dbo.LineaTelefonicas");
            DropTable("dbo.Contratos");
            DropTable("dbo.Ventas");
            DropTable("dbo.Clientes");
            DropTable("dbo.CentroAtencions");
            DropTable("dbo.Evaluacions");
            DropTable("dbo.EquipoCelulars");
            DropTable("dbo.AdministradorEquipos");
        }
    }
}
