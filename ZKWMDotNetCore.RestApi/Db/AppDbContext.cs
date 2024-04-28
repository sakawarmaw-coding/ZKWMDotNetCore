using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKWMDotNetCore.RestApi.Models;

namespace ZKWMDotNetCore.RestApi.Db
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
