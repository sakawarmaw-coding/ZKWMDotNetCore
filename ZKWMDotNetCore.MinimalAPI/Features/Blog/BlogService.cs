using Microsoft.EntityFrameworkCore;
using ZKWMDotNetCore.MinimalAPI.Db;
using ZKWMDotNetCore.MinimalAPI.Models;

namespace ZKWMDotNetCore.MinimalAPI.Features.Blog
{
    public static class BlogService
    {
        public static void AddBlogFeatures(this IEndpointRouteBuilder app)
        {

            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/CreateBlog", async (AppDbContext db, BlogModel model) =>
            {
                await db.Blogs.AddAsync(model);
                int result = await db.SaveChangesAsync();
                string message = result > 0 ? "Saving Successful" : "Saving Failed";
                return Results.Ok(message);
            });

            app.MapPut("api/UpdateBlog/{id}", async (AppDbContext db, int id, BlogModel model) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found");
                }
                item.BlogTitle = model.BlogTitle;
                item.BlogAuthor = model.BlogAuthor;
                item.BlogContent = model.BlogContent;
                int result = await db.SaveChangesAsync();
                string message = result > 0 ? "Updating Successful" : "Updating Failed";
                return Results.Ok(message);
            });

            app.MapDelete("api/DeleteBlog/{id}", async (AppDbContext db, int id) =>
            {
                var item = await db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.NotFound("No data found");
                }
                db.Blogs.Remove(item);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting Successful" : "Deleting Failed";
                return Results.Ok(message);
            });

        }
    }
}
