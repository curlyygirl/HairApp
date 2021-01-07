namespace HairApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Washes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Washes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WashConditioner = c.String(),
                        Shampoo = c.String(),
                        HairMask = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Washes");
        }
    }
}
