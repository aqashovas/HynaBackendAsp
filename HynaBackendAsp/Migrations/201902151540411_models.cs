namespace HynaBackendAsp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class models : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Abouts", "Tittle", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "Fullname", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Tittle", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Facts", "Key", c => c.String(nullable: false));
            AlterColumn("dbo.Facts", "Value", c => c.String(nullable: false));
            AlterColumn("dbo.Faqs", "Question", c => c.String(nullable: false));
            AlterColumn("dbo.Faqs", "Answer", c => c.String(nullable: false));
            AlterColumn("dbo.Partners", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Partners", "Logo", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "Icon", c => c.String(nullable: false));
            AlterColumn("dbo.Settings", "Logo", c => c.String(nullable: false));
            AlterColumn("dbo.Sliders", "Tittle", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sliders", "Tittle", c => c.String());
            AlterColumn("dbo.Settings", "Logo", c => c.String());
            AlterColumn("dbo.Services", "Icon", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            AlterColumn("dbo.Partners", "Logo", c => c.String());
            AlterColumn("dbo.Partners", "Url", c => c.String());
            AlterColumn("dbo.Faqs", "Answer", c => c.String());
            AlterColumn("dbo.Faqs", "Question", c => c.String());
            AlterColumn("dbo.Facts", "Value", c => c.String());
            AlterColumn("dbo.Facts", "Key", c => c.String());
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Blogs", "Tittle", c => c.String());
            AlterColumn("dbo.Authors", "Fullname", c => c.String());
            AlterColumn("dbo.Abouts", "Tittle", c => c.String());
        }
    }
}
