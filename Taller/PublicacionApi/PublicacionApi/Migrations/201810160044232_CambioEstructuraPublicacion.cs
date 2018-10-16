namespace PublicacionApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioEstructuraPublicacion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Publicacions", newName: "Publicacion");
            AddColumn("dbo.Publicacion", "FechaPublicacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Publicacion", "Usuario", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Publicacion", "Descripcion", c => c.String(maxLength: 200));
            DropColumn("dbo.Publicacion", "FechaPulicacion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publicacion", "FechaPulicacion", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Publicacion", "Descripcion", c => c.String());
            AlterColumn("dbo.Publicacion", "Usuario", c => c.String());
            DropColumn("dbo.Publicacion", "FechaPublicacion");
            RenameTable(name: "dbo.Publicacion", newName: "Publicacions");
        }
    }
}
