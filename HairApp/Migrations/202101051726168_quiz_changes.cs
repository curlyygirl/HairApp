namespace HairApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quiz_changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quizzes", "Type", c => c.String());
            AlterColumn("dbo.Quizzes", "Porosity", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quizzes", "Porosity", c => c.String(nullable: false));
            AlterColumn("dbo.Quizzes", "Type", c => c.String(nullable: false));
        }
    }
}
