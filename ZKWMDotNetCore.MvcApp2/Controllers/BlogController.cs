﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZKWMDotNetCore.MvcApp2.Db;
using ZKWMDotNetCore.MvcApp2.Models;

namespace ZKWMDotNetCore.MvcApp2.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public async Task<IActionResult> BlogIndex()
        {
            var lst = await _db.Blogs.AsNoTracking().OrderByDescending(x => x.BlogId).ToListAsync();
            return View("BlogIndex",lst);
        }

        [ActionName("Create")]
        public async Task<IActionResult> BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            await _db.Blogs.AddAsync(blog);
            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving Successful." : "Saving Failed."
            };
            return Json(message);
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/blog");
            }

            return View("BlogEdit", item);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/blog");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Updating Successful." : "Updating Failed."
            };
            return Json(message);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(BlogModel blog)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
            if (item is null)
            {
                return Redirect("/blog");
            }
            _db.Blogs.Remove(item);
            var result = await _db.SaveChangesAsync();
            var message = new MessageModel()
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
            };
            return Json(message);
        }
    }
}
