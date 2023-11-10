using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.FactoryAbstractions;

namespace FactoryPattern.FactoryConcreteProducts
{
	public class SpecialDiscount : BaseDiscount
	{
		public override decimal GetPercentage() => 0.15m;
	}
}
