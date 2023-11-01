using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DecoratorPattern.DecoratorModels;
using DecoratorPattern.DecoratorServiceAbstractions;

namespace DecoratorPattern.DecoratorService
{
	public class PostService : IPostService
	{
		private readonly HttpClient _httpClient; 
		
		public PostService()
		{
			_httpClient = new HttpClient();
		}

		public async Task<Post?> GetPostAsync(int postId)
		{
			var url = $"https://jsonplaceholder.typicode.com/posts/{postId}";
			var response = await _httpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var responseBody = await response.Content.ReadAsStringAsync();

				var post = JsonSerializer.Deserialize<Post>(
					responseBody,
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
				);
				return post;
			}
			else
			{
				throw new Exception($"Error: {response.StatusCode}");
			}
		}
	}
}
