namespace FileUploadTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileUploads", "FileName", c => c.String());
            AddColumn("dbo.FileUploads", "Path", c => c.String());
            DropColumn("dbo.FileUploads", "length");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileUploads", "length", c => c.String());
            DropColumn("dbo.FileUploads", "Path");
            DropColumn("dbo.FileUploads", "FileName");
        }
    }
}
