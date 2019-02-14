namespace CustomersHub.DataAccess.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate_Customer_Status : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CustomerStatus (Id, Status, CreatedAt) VALUES ('c4407c7c-7064-47bf-bd91-ca9edfea67b1', 'prospective', '2019-02-12 13:00:00' )");
            Sql("INSERT INTO CustomerStatus (Id,  Status, CreatedAt) VALUES ('ea587264-35a6-4616-b9d7-0eda68f9adf9', 'current', '2019-02-12 13:00:00')");
            Sql("INSERT INTO CustomerStatus (Id,  Status, CreatedAt) VALUES ('6a1b59e6-096b-48e6-a34b-039205e409d5', 'non-active', '2019-02-12 13:00:00')");
        }
        
        public override void Down()
        {
            Sql("DELETE * from CustomerStatus");
        }
    }
}
