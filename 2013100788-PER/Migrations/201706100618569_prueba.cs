namespace _2013100788_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
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
                        EquipCelId = c.Int(nullable: false, identity: true),
                        descrip = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.EquipCelId);
            
            CreateTable(
                "dbo.Evaluacions",
                c => new
                    {
                        EvalId = c.Int(nullable: false, identity: true),
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
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.EquipoCelulars", t => t.EquipCelId, cascadeDelete: true)
                .ForeignKey("dbo.EstadoEvaluacions", t => t.EstEvaId, cascadeDelete: true)
                .ForeignKey("dbo.LineaTelefonicas", t => t.LinTelfId, cascadeDelete: true)
                .ForeignKey("dbo.Trabajadors", t => t.TrabaId, cascadeDelete: true)
                .Index(t => t.EquipCelId)
                .Index(t => t.LinTelfId)
                .Index(t => t.TrabaId)
                .Index(t => t.EstEvaId)
                .Index(t => t.ClienteId)
                .Index(t => t.CenAteId);
            
            CreateTable(
                "dbo.CentroAtencions",
                c => new
                    {
                        CenAteId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        DirId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CenAteId)
                .ForeignKey("dbo.Direccions", t => t.DirId, cascadeDelete: true)
                .Index(t => t.DirId);
            
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        DirId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DirId)
                .ForeignKey("dbo.Ubigeos", t => t.UbigeoId, cascadeDelete: true)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Ubigeos",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        Departamento = c.Byte(nullable: false),
                        Provincia = c.Byte(nullable: false),
                        Distrito = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        LinTelfId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        TipoPago = c.Byte(nullable: false),
                        ContratoId = c.Int(nullable: false),
                        CenAteId = c.Int(nullable: false),
                        EvalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.CentroAtencions", t => t.CenAteId, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Contratos", t => t.ContratoId, cascadeDelete: true)
                .ForeignKey("dbo.Evaluacions", t => t.EvalId, cascadeDelete: false)
                .ForeignKey("dbo.LineaTelefonicas", t => t.LinTelfId, cascadeDelete: true)
                .Index(t => t.LinTelfId)
                .Index(t => t.ClienteId)
                .Index(t => t.ContratoId)
                .Index(t => t.CenAteId)
                .Index(t => t.EvalId);
            
            CreateTable(
                "dbo.Contratos",
                c => new
                    {
                        ContratoId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ContratoId);
            
            CreateTable(
                "dbo.LineaTelefonicas",
                c => new
                    {
                        LinTelfId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        TipoLinea = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.LinTelfId);
            
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
                .PrimaryKey(t => t.EstEvaId);
            
            CreateTable(
                "dbo.Trabajadors",
                c => new
                    {
                        TrabaId = c.Int(nullable: false, identity: true),
                        desc = c.String(nullable: false, maxLength: 255),
                        TipoTrabajador = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TrabaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "TrabaId", "dbo.Trabajadors");
            DropForeignKey("dbo.Evaluacions", "LinTelfId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Evaluacions", "EstEvaId", "dbo.EstadoEvaluacions");
            DropForeignKey("dbo.Evaluacions", "EquipCelId", "dbo.EquipoCelulars");
            DropForeignKey("dbo.Evaluacions", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "LinTelfId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.AdministradorLineas", "LinTelfId", "dbo.LineaTelefonicas");
            DropForeignKey("dbo.Ventas", "EvalId", "dbo.Evaluacions");
            DropForeignKey("dbo.Ventas", "ContratoId", "dbo.Contratos");
            DropForeignKey("dbo.Ventas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Ventas", "CenAteId", "dbo.CentroAtencions");
            DropForeignKey("dbo.Evaluacions", "CenAteId", "dbo.CentroAtencions");
            DropForeignKey("dbo.CentroAtencions", "DirId", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "UbigeoId", "dbo.Ubigeos");
            DropForeignKey("dbo.AdministradorEquipos", "EquipCelId", "dbo.EquipoCelulars");
            DropIndex("dbo.AdministradorLineas", new[] { "LinTelfId" });
            DropIndex("dbo.Ventas", new[] { "EvalId" });
            DropIndex("dbo.Ventas", new[] { "CenAteId" });
            DropIndex("dbo.Ventas", new[] { "ContratoId" });
            DropIndex("dbo.Ventas", new[] { "ClienteId" });
            DropIndex("dbo.Ventas", new[] { "LinTelfId" });
            DropIndex("dbo.Direccions", new[] { "UbigeoId" });
            DropIndex("dbo.CentroAtencions", new[] { "DirId" });
            DropIndex("dbo.Evaluacions", new[] { "CenAteId" });
            DropIndex("dbo.Evaluacions", new[] { "ClienteId" });
            DropIndex("dbo.Evaluacions", new[] { "EstEvaId" });
            DropIndex("dbo.Evaluacions", new[] { "TrabaId" });
            DropIndex("dbo.Evaluacions", new[] { "LinTelfId" });
            DropIndex("dbo.Evaluacions", new[] { "EquipCelId" });
            DropIndex("dbo.AdministradorEquipos", new[] { "EquipCelId" });
            DropTable("dbo.Trabajadors");
            DropTable("dbo.EstadoEvaluacions");
            DropTable("dbo.AdministradorLineas");
            DropTable("dbo.LineaTelefonicas");
            DropTable("dbo.Contratos");
            DropTable("dbo.Ventas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Ubigeos");
            DropTable("dbo.Direccions");
            DropTable("dbo.CentroAtencions");
            DropTable("dbo.Evaluacions");
            DropTable("dbo.EquipoCelulars");
            DropTable("dbo.AdministradorEquipos");
        }
    }
}
