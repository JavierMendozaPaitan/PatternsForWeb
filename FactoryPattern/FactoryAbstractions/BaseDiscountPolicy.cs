using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryAbstractions
{
	public abstract class BaseDiscountPolicy
	{
		public abstract BaseDiscount CreateDiscount();

		public decimal ApplyPolicy(Decimal price)
		{
			var discount = CreateDiscount();

			return price*(1 - discount.GetPercentage());
		}
	}
}
