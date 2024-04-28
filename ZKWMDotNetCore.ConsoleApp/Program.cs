// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using System.Data;
using ZKWMDotNetCore.ConsoleApp.EFCoreExamples;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Create("title", "author", "content");
////adoDotNetExample.Update(2, "title", "author", "content");
////adoDotNetExample.Delete(3);
//adoDotNetExample.Edit(3);

//DapperExample dp= new DapperExample();  
//dp.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();
Console.ReadKey();