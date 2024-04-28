using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using ZKWMDotNetCore.RestApi.Db;
using ZKWMDotNetCore.RestApi.Models;

namespace ZKWMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if(item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel model)
        {
            _db.Blogs.Add(model);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(message);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel model)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            item.BlogTitle = model.BlogTitle;
            item.BlogAuthor=model.BlogAuthor;
            item.BlogContent=model.BlogContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel model)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                item.BlogTitle = model.BlogTitle;
            }
            if (!string.IsNullOrEmpty(model.BlogAuthor))
            {
                item.BlogAuthor = model.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(model.BlogContent))
            {
                item.BlogContent = model.BlogContent;
            }
            int result = _db.SaveChanges();
            string message = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                return NotFound("No data found");
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(message);
        }
    }
}
