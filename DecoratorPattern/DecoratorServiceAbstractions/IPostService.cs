using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecoratorPattern.DecoratorModels;

namespace DecoratorPattern.DecoratorServiceAbstractions
{
	public interface IPostService
	{
		Task<Post?> GetPostAsync(int postId);
	}
}
