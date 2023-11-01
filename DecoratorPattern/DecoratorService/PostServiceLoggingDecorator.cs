using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.DecoratorAbstractions;
using DecoratorPattern.DecoratorModels;
using DecoratorPattern.DecoratorServiceAbstractions;

namespace DecoratorPattern.DecoratorService
{
	public class PostServiceLoggingDecorator : BasePostServiceDecorator
	{
		public PostServiceLoggingDecorator(IPostService postService)
			: base(postService)
		{
		}

		public async override Task<Post?> GetPostAsync(int postId)
		{
			Console.WriteLine($"Calling the API to get the post with ID: {postId}");
			var stopwatch = Stopwatch.StartNew();
			try
			{
				var post = await _postService.GetPostAsync(postId);
				Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to call the API");

				return post;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"GetPostAsync threw exception: {ex.Message}");
				throw;
			}
			finally { stopwatch.Stop(); }
		}
	}
}
