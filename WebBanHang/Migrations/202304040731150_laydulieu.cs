namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laydulieu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "CustomerId", c => c.String());
            AddColumn("dbo.tb_Order", "TypePayment", c => c.Int(nullable: false));
            DropColumn("dbo.tb_Order", "CustomerName");
            DropColumn("dbo.tb_Order", "Phone");
            DropColumn("dbo.tb_Order", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_Order", "Address", c => c.String(nullable: false));
            AddColumn("dbo.tb_Order", "Phone", c => c.String(nullable: false));
            AddColumn("dbo.tb_Order", "CustomerName", c => c.String(nullable: false));
            DropColumn("dbo.tb_Order", "TypePayment");
            DropColumn("dbo.tb_Order", "CustomerId");
        }
    }
}
