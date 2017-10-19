namespace RealityMarble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Author");
        }
    }
}
