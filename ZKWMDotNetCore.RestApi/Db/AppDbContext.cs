using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZKWMDotNetCore.RestApi.Models;

namespace ZKWMDotNetCore.RestApi.Db
{
    public class AppDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
        //}

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
