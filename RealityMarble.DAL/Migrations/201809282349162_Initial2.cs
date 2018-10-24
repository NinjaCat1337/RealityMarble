namespace RealityMarble.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "SenderUserName");
            DropColumn("dbo.Messages", "ReceiverUserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReceiverUserName", c => c.String());
            AddColumn("dbo.Messages", "SenderUserName", c => c.String());
        }
    }
}
