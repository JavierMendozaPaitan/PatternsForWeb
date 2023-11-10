using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.FactoryAbstractions
{
	public abstract class BaseDiscount
	{
		public abstract decimal GetPercentage();
	}
}
