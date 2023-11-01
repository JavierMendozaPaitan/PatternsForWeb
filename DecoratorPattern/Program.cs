using DecoratorPattern.DecoratorService;
using DecoratorPattern.DecoratorModels;
using System.Text.Json;
using DecoratorPattern.DecoratorServiceAbstractions;

namespace DecoratorPattern
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			IPostService postService = new PostService();
			var postServiceLogging = new PostServiceLoggingDecorator(postService);

			try
			{
				var post = await postServiceLogging.GetPostAsync(2) ?? new Post();
				Console.WriteLine(JsonSerializer.Serialize(post).ToString());
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}