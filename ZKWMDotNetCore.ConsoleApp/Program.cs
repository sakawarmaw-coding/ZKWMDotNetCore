// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using ZKWMDotNetCore.ConsoleApp.AdoDotNetExamples;
using ZKWMDotNetCore.ConsoleApp.DapperExamples;
using ZKWMDotNetCore.ConsoleApp.EFCoreExamples;
using ZKWMDotNetCore.ConsoleApp.Services;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Create("title", "author", "content");
////adoDotNetExample.Update(2, "title", "author", "content");
////adoDotNetExample.Delete(3);
//adoDotNetExample.Edit(3);

//DapperExample dp= new DapperExample();  
//dp.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();
var connectionString = ConnectionString.sqlConnectionStringBuilder.ConnectionString;
var SqlConnectionStringBuilder=new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()
    .AddScoped(n=>new AdoDotNetExample(SqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(SqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(connectionString);
        })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
dapperExample.Run();
Console.ReadKey();