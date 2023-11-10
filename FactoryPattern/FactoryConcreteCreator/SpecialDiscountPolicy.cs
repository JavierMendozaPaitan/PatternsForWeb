using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.FactoryAbstractions;
using FactoryPattern.FactoryConcreteProducts;

namespace FactoryPattern.FactoryConcreteCreator
{
	public class SpecialDiscountPolicy : BaseDiscountPolicy
	{
		public override BaseDiscount CreateDiscount()
		{
			return new SpecialDiscount();
		}
	}
}
