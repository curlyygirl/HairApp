namespace HairApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizzes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idUser = c.Int(nullable: false),
                        Type = c.String(),
                        Porosity = c.String(),
                        Thickness = c.String(),
                        Density = c.String(),
                        Dyed = c.Boolean(nullable: false),
                        Destroyed = c.String(),
                        Length = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.idUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quizzes", "idUser", "dbo.Users");
            DropIndex("dbo.Quizzes", new[] { "idUser" });
            DropTable("dbo.Users");
            DropTable("dbo.Quizzes");
        }
    }
}
