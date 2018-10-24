namespace RealityMarble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SenderUserName", c => c.String());
            AddColumn("dbo.Messages", "ReceiverUserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "ReceiverUserName");
            DropColumn("dbo.Messages", "SenderUserName");
        }
    }
}
