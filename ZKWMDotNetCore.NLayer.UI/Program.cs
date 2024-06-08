// See https://aka.ms/new-console-template for more information
using ZKWMDotNetCore.NLayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

BL_Blog bL_Blog = new BL_Blog();
var lst = bL_Blog.GetBlogs();
foreach (var item in lst)
{
    Console.WriteLine("Blog Id =>" + item.BlogId);
    Console.WriteLine("Blog Title =>" + item.BlogTitle);
    Console.WriteLine("Blog Author =>" + item.BlogAuthor);
    Console.WriteLine("Blog Content =>" + item.BlogContent);
    Console.WriteLine("------------------------------------------");
}


