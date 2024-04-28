using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKWMDotNetCore.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //Read();
            //Edit(1);
            //Create("AA","BB","CC");
            //Update(5,"My Family", "Zakawar Maw", "Hello Guys ! Please,Let me introduce my family");
            //Delete(5);
        }

        private void Read()
        {
            var lst = db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine("Blog Id =>" + item.BlogId);
                Console.WriteLine("Blog Title =>" + item.BlogTitle);
                Console.WriteLine("Blog Author =>" + item.BlogAuthor);
                Console.WriteLine("Blog Content =>" + item.BlogContent);
                Console.WriteLine("------------------------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            Console.WriteLine("Blog Id =>" + item.BlogId);
            Console.WriteLine("Blog Title =>" + item.BlogTitle);
            Console.WriteLine("Blog Author =>" + item.BlogAuthor);
            Console.WriteLine("Blog Content =>" + item.BlogContent);
            Console.WriteLine("Edit Successfully");
            Console.WriteLine("------------------------------------------");
        }

        private void Create(string title, string author, string content)
        {
            var item = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            item.BlogTitle=title;
            item.BlogAuthor=author;
            item.BlogContent=content;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
