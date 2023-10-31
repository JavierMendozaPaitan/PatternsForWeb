using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePattern.Baggage.Models
{
	public class BaggageInfo
	{
		public string? Id { get; set; }
		public int FlightNumber { get; set; }
		public required string FlightFrom { get; set; }
		public int Carousel {  get; set; }


	}
}
