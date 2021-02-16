namespace PruebaTecnica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class my_models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        EmpleadoId = c.Int(nullable: false, identity: true),
                        NombreEmpleado = c.String(nullable: false, maxLength: 50),
                        Direccion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuariosId = c.Int(nullable: false, identity: true),
                        NombreUsuario = c.String(nullable: false, maxLength: 50),
                        ContraseniaUsuario = c.String(nullable: false, maxLength: 225),
                        Estado = c.String(nullable: false, maxLength: 50),
                        EmpleadoId = c.Int(nullable: false),
                        TipoUsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UsuariosId)
                .ForeignKey("dbo.Empleado", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoUsuario", t => t.TipoUsuarioId, cascadeDelete: true)
                .Index(t => t.EmpleadoId)
                .Index(t => t.TipoUsuarioId);
            
            CreateTable(
                "dbo.TipoUsuario",
                c => new
                    {
                        TipoUsuarioId = c.Int(nullable: false, identity: true),
                        NombreTipo = c.String(),
                    })
                .PrimaryKey(t => t.TipoUsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "TipoUsuarioId", "dbo.TipoUsuario");
            DropForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Empleado");
            DropIndex("dbo.Usuarios", new[] { "TipoUsuarioId" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoId" });
            DropTable("dbo.TipoUsuario");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Empleado");
        }
    }
}
