namespace E_Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.IssuedBooks", "StudentId");
            CreateIndex("dbo.IssuedBooks", "BookId");
            AddForeignKey("dbo.IssuedBooks", "BookId", "dbo.Books", "BookId", cascadeDelete: true);
            AddForeignKey("dbo.IssuedBooks", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuedBooks", "StudentId", "dbo.Students");
            DropForeignKey("dbo.IssuedBooks", "BookId", "dbo.Books");
            DropIndex("dbo.IssuedBooks", new[] { "BookId" });
            DropIndex("dbo.IssuedBooks", new[] { "StudentId" });
        }
    }
}
