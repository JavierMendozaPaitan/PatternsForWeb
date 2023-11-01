using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.DecoratorModels;
using DecoratorPattern.DecoratorServiceAbstractions;

namespace DecoratorPattern.DecoratorAbstractions
{
	public abstract class BasePostServiceDecorator : IPostService
	{
		protected readonly IPostService _postService;

		public BasePostServiceDecorator(IPostService postService)
		{
			_postService = postService;
		}

		public abstract Task<Post?> GetPostAsync(int postId);
	}
}
