using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZKWMDotNetCore.ConsoleAppRestClientExample
{
    public class RestClientExample
    {
        private readonly RestClient _client = new RestClient(new Uri("https://localhost:7269"));

        private readonly string _blogEndpoint = "api/blog";

        public async Task RunAsync()
        {
            await ReadAsync();
            //await EditAsync(1);
            //await EditAsync(3);
            //await CreateAsync("Title 1", "Sakawar Maw", "Desc1");
            //await UpdateAsync(11, "Title 11", "Sakawar Maw", "Desc11");
            //await PatchAsync(11, "Title 12");
        }

        private async Task ReadAsync()
        {
            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Title => {item.BlogTitle}");
                    Console.WriteLine($"Author => {item.BlogAuthor}");
                    Console.WriteLine($"Content => {item.BlogContent}");
                }
            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;
                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest restRequest = new RestRequest(_blogEndpoint, Method.Post);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task PatchAsync(int id, string title = "", string author = "", string content = "")
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest restRequest = new RestRequest($"{_blogEndpoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
