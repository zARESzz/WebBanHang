namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.tb_Subscribe");
            AddColumn("dbo.tb_Subscribe", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.tb_Subscribe", "CreateDate", c => c.DateTime(nullable: false));
            AddPrimaryKey("dbo.tb_Subscribe", "Id");
            DropColumn("dbo.tb_Subscribe", "Name");
            DropColumn("dbo.tb_Subscribe", "DiaChi");
            DropColumn("dbo.tb_Subscribe", "Phone");
            DropColumn("dbo.tb_Subscribe", "Mess");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Subscribe", "Mess", c => c.String());
            AddColumn("dbo.tb_Subscribe", "Phone", c => c.String());
            AddColumn("dbo.tb_Subscribe", "DiaChi", c => c.String());
            AddColumn("dbo.tb_Subscribe", "Name", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.tb_Subscribe");
            DropColumn("dbo.tb_Subscribe", "CreateDate");
            DropColumn("dbo.tb_Subscribe", "Id");
            AddPrimaryKey("dbo.tb_Subscribe", "Name");
        }
    }
}
