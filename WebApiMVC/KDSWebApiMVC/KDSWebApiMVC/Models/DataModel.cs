namespace KDSWebApiMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
        // Your context has been configured to use a 'DataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KDSWebApiMVC.Models.DataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DataModel' 
        // connection string in the application configuration file.
        public DataModel()
            : base("name=SqlServer")
        {
        }

        public System.Data.Entity.DbSet<KDSWebApiMVC.Models.Comanda> Comanda { get; set; }

        public System.Data.Entity.DbSet<KDSWebApiMVC.Models.Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemAdicional> ItemAdicional { get; set; }
        public DbSet<ItemInsumo> ItemInsumo { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}