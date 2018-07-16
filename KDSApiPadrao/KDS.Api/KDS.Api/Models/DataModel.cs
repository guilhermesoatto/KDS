using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace KDS.Api.Models
{
    public partial class DataModel : DbContext
    {

        public DataModel(DbContextOptions<DataModel> options) : base(options)
        {
        }

        public DbSet<Comanda> Comanda { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemAdicional> ItemAdicional { get; set; }
        public DbSet<ItemInsumo> ItemInsumo { get; set; }
        public DbSet<Status> Status { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "KDS.db" };
        //var connectionString = connectionStringBuilder.ToString();
        //var connection = new SqliteConnection(connectionString);

        //optionsBuilder.UseSqlite(connection);
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Comanda>().HasKey(m => m.idComanda);
            base.OnModelCreating(builder);

            builder.Entity<Pedido>().HasKey(m => m.idPedido);
            base.OnModelCreating(builder);

            builder.Entity<Item>().HasKey(m => m.idItem);
            base.OnModelCreating(builder);

            builder.Entity<ItemAdicional>().HasKey(m => m.idAdicional);
            base.OnModelCreating(builder);

            builder.Entity<ItemInsumo>().HasKey(m => m.idInsumo);
            base.OnModelCreating(builder);

            builder.Entity<Status>().HasKey(m => m.idStatus);
            base.OnModelCreating(builder);
        }

    }
}
