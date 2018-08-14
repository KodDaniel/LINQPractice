namespace LinqStudiekollen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssds : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "UserId", "dbo.Users");
            AddForeignKey("dbo.Tests", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "UserId", "dbo.Users");
            AddForeignKey("dbo.Tests", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
