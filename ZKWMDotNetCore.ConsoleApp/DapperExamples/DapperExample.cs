using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ZKWMDotNetCore.ConsoleApp.Dtos;
using ZKWMDotNetCore.ConsoleApp.Services;

namespace ZKWMDotNetCore.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        public void Run()
        {
            //Read();
            //Edit(1);
            //Edit(3);
            //Create("My Family", "Zakawar Maw", "Hello Guys ! Let me introduce my family");
            //Update(4,"My Family", "Zakawar Maw", "Hello Guys ! Please,Let me introduce my family");
            //Delete(4);
        }

        private void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("SELECT * FROM Tbl_Blog").ToList();
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
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("SELECT * FROM Tbl_Blog WHERE BlogId=@BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
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
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                               ([BlogTitle]
                               ,[BlogAuthor]
                               ,[BlogContent])
                                VALUES
                               (@BlogTitle
                               ,@BlogAuthor
                               ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, item);
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            Console.WriteLine(message);
        }

        private void Update(int id, string title, string author, string content)
        {
            var item = new BlogDto()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string query = @"UPDATE [dbo].[Tbl_Blog]
                             SET [BlogTitle] = @BlogTitle
                                  ,[BlogAuthor] = @BlogAuthor
                                  ,[BlogContent] = @BlogContent
                             WHERE BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, item);
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {
            var item = new BlogDto()
            {
                BlogId = id
            };
            string query = @"DELETE FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.sqlConnectionStringBuilder.ConnectionString);
            var result = db.Execute(query, item);
            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            Console.WriteLine(message);
        }
    }
}
