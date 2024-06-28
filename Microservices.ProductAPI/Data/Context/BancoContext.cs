using Microsoft.EntityFrameworkCore;

namespace Microservices.ProductAPI.Data.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> opt) : base(opt)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Chamando o método para popular os dados
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Inserção de dados exemplo
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Camisa", Price = 10.99m },
                new Product { Id = 2, Name = "Calça", Price = 19.99m },
                new Product { Id = 3, Name = "Bermuda", Price = 29.50m },
                new Product { Id = 4, Name = "Moletom", Price = 109.99m },
                new Product { Id = 5, Name = "Boné", Price = 17.90m },
                new Product { Id = 6, Name = "Camiseta", Price = 14.99m },
                new Product { Id = 7, Name = "Chapéu", Price = 39.99m },
                new Product { Id = 8, Name = "Meia", Price = 9.99m }
            );
        }
    }
}
