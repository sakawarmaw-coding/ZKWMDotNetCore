using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ZKWMDotNetCore.RestApiWithNLayer.Features.ArtGallery
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtGalleryController : ControllerBase
    {
        private async Task<ArtGallery> GetDataAsync()
        {
            var jsonStr = await System.IO.File.ReadAllTextAsync("artGallery.json");
            var model = JsonConvert.DeserializeObject<ArtGallery>(jsonStr);
            return model;
        }

        [HttpGet("ArtList")]
        public async Task<IActionResult> Art()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Art);
        }

        [HttpGet("ArtistList")]
        public async Task<IActionResult> Artist()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_Artist);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> Gallery(int artistId)
        {
            var model = await GetDataAsync();
            var lst = from gallery in model.Tbl_Gallery
                      join art in model.Tbl_Art on gallery.ArtId equals art.ArtId
                      join artist in model.Tbl_Artist on gallery.ArtistId equals artist.ArtistId
                      where gallery.ArtistId == artistId
                      select new { gallery.GalleryId, artist.ArtistName, art.ArtName, art.ArtDescription };
            return Ok(lst);
        }

        public class ArtGallery
        {
            public Tbl_Gallery[] Tbl_Gallery { get; set; }
            public Tbl_Art[] Tbl_Art { get; set; }
            public Tbl_Artist[] Tbl_Artist { get; set; }
        }

        public class Tbl_Gallery
        {
            public int GalleryId { get; set; }
            public int ArtistId { get; set; }
            public int ArtId { get; set; }
        }

        public class Tbl_Art
        {
            public int ArtId { get; set; }
            public string ArtName { get; set; }
            public string ArtDescription { get; set; }
        }

        public class Tbl_Artist
        {
            public int ArtistId { get; set; }
            public string ArtistName { get; set; }
            public Social[] Social { get; set; }
        }

        public class Social
        {
            public string Name { get; set; }
            public string Link { get; set; }
        }
    }
}
