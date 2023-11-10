using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.FactoryAbstractions;

namespace FactoryPattern.FactoryService
{
	public class OrderWithDiscount
	{
		private readonly BaseDiscountPolicy _discountPolicy;
		private readonly decimal _initialAmount;
		public OrderWithDiscount(decimal initialAmount, BaseDiscountPolicy discountPolicy)
		{
			_initialAmount = initialAmount;
			_discountPolicy = discountPolicy;
		}

		public decimal NetAmount => _discountPolicy.ApplyPolicy(_initialAmount);
	}
}
