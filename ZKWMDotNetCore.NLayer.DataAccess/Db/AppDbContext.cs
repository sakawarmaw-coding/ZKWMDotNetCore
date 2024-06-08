using Microsoft.EntityFrameworkCore;
using ZKWMDotNetCore.NLayer.DataAccess.Models;

namespace ZKWMDotNetCore.NLayer.DataAccess.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
