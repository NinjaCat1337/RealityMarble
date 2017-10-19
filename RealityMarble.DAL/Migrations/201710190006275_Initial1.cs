namespace RealityMarble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Images", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "File", c => c.Binary());
        }
    }
}
