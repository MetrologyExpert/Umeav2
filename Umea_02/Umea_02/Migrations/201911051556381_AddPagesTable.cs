namespace Umea_02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPagesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        pageNumber = c.Int(nullable: false, identity: true),
                        ubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pageNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pages");
        }
    }
}
