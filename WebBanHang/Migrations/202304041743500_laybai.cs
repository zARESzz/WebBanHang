namespace WebBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laybai : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Product", "OriginalPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.tb_Contact", "Website", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Contact", "Website", c => c.String());
            DropColumn("dbo.tb_Product", "OriginalPrice");
        }
    }
}
