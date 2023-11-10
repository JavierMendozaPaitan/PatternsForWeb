using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryPattern.FactoryAbstractions;

namespace FactoryPattern.FactoryConcreteProducts
{
	public class RegularDiscount : BaseDiscount
	{
		public override decimal GetPercentage() => 0.1m;
	}
}
