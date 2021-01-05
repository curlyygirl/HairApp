namespace HairApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Quiz_update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Quizzes", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Quizzes", "Porosity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Quizzes", "Porosity", c => c.String());
            AlterColumn("dbo.Quizzes", "Type", c => c.String());
        }
    }
}
