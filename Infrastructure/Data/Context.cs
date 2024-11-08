using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

internal class Context(DbContextOptions<Context> options) :DbContext(options)
{
    DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = Guid.NewGuid(), Name = "Яблоко"},
            new Product { Id = Guid.NewGuid(), Name = "Яблочный пирог" },
            new Product { Id = Guid.NewGuid(), Name = "Яблочное варенье" },
            new Product { Id = Guid.NewGuid(), Name = "Яблочный суп" },
            new Product { Id = Guid.NewGuid(), Name = "что-то с яблоком" },
            new Product { Id = Guid.NewGuid(), Name = "Пирожок с яблоком" },
            new Product { Id = Guid.NewGuid(), Name = "Груша" },
            new Product { Id = Guid.NewGuid(), Name = "Грушевый торт" },
            new Product { Id = Guid.NewGuid(), Name = "Варенье с грушей" },
            new Product { Id = Guid.NewGuid(), Name = "Ароматизатор - Груша" },
            new Product { Id = Guid.NewGuid(), Name = "Игрушка - груша" },
            new Product { Id = Guid.NewGuid(), Name = "Книга рецептов - Груши, Яблоки" },
            new Product { Id = Guid.NewGuid(), Name = "бебра" }
        );
    }
}
