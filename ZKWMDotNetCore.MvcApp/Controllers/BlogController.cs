using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZKWMDotNetCore.MvcApp.Db;
using ZKWMDotNetCore.MvcApp.Models;

namespace ZKWMDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs.AsNoTracking().OrderByDescending(x=>x.BlogId).ToListAsync();
            return View(lst);
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
            return Redirect("/blog");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> BlogEdit(int id)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x=> x.BlogId == id);
            if (item is null)
            {
                return Redirect("/blog");
            }
            
            return View("BlogEdit",item);
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
            await _db.SaveChangesAsync();
            return Redirect("/blog");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> BlogDelete(int id)
        {
            var item = await _db.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Redirect("/blog");
            }
            _db.Blogs.Remove(item);
            await _db.SaveChangesAsync();
            return Redirect("/blog");
        }
    }
}
