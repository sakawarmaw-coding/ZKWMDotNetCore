// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using ZKWMDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

// See https://aka.ms/new-console-template for more information
//ConsoleApp Client ( Frontend )
// Asp.Net Core Web API ( Backend )


HttpClientExample httpClientExample = new HttpClientExample();
await httpClientExample.RunAsync();

Console.ReadLine();