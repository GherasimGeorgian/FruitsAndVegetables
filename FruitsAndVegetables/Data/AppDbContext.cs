using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //Install-Package Microsoft.EntityFrameworkCore.SqlServer
using FruitsAndVegetables.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FruitsAndVegetables.Data
{
    //Install-Package Microsoft.EntityFrameworkCore.Tools
    //Update-Package Microsoft.EntityFrameworkCore.Tools
    //install-Package Microsoft.EntityFrameworkCore
    //Enable-Migrations -StartUpProjectName FruitsAndVegetables -ContextTypeName FruitsAndVegetables.Data.AppDbContext
    //add-migration Initial // in caz de eroare use [Key] pt field
    // Update-database // No type was specified for the decimal column 'Price' on entity type 'Product' Solve:[Column(TypeName = "decimal(18,2)")]
    // The type 'AppDbContext' does not inherit from DbContext. The DbMigrationsConfiguration.ContextType property must be set to a type that inherits from DbContext. Solve:EntityFrameworkCore\Add-Migration
    //EntityFrameworkCore\Update-Database
    public class AppDbContext : IdentityDbContext<IdentityUser>// DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
