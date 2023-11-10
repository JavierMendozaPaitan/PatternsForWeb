using FactoryPattern.FactoryConcreteCreator;
using FactoryPattern.FactoryService;

namespace FactoryPattern
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			var order = new OrderWithDiscount(1000, new SpecialDiscountPolicy());
			Console.WriteLine(order.NetAmount); 

		}
	}
}