using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObservablePattern.Baggage.Models;
using ObservablePattern.Baggage.Provider;

namespace ObservablePattern.Baggage.Observer
{
	public class ArrivalsMonitor : IObserver<BaggageInfo>
	{
		private readonly string _observerName;
		private readonly List<BaggageInfo> _flights = new();
		private readonly string _format = "{0,-20} {1,5}  {2, 3}";
		private IDisposable? _cancellation;

		public ArrivalsMonitor(string observerName)
		{
			ArgumentException.ThrowIfNullOrEmpty(observerName);
			_observerName = observerName;
		}
		public virtual void Subscribe(BaggageHandler provider) =>
		_cancellation = provider.Subscribe(this);

		public virtual void Unsubscribe()
		{
			_cancellation?.Dispose();
			_flights.Clear();
		}

		public virtual void OnCompleted() => _flights.Clear();

		// No implementation needed: Method is not called by the BaggageHandler class.
		public virtual void OnError(Exception e)
		{
			// No implementation.
		}

		// Update information.
		public virtual void OnNext(BaggageInfo info)
		{
			bool updated = false;

			// Flight has unloaded its baggage; remove from the monitor.
			if (info.Carousel is 0)
			{
				//string flightNumber = string.Format("{0,5}", info.FlightNumber);
				for (int index = _flights.Count - 1; index >= 0; index--)
				{
					BaggageInfo flightInfo = _flights[index];
					if (flightInfo.FlightNumber.Equals(info.FlightNumber))
					{
						updated = true;
						_flights.RemoveAt(index);
					}
				}
			}
			else
			{
				// Add flight if it doesn't exist in the collection.
				//string flightInfo = string.Format(_format, info.FlightFrom, info.FlightNumber, info.Carousel);
				
				if (_flights.Contains(info) is false)
				{
					_flights.Add(info);
					updated = true;
				}
			}

			if (updated)
			{
				_flights.OrderByDescending( x => x.FlightFrom);
				Console.WriteLine($"Arrivals information from {_observerName}");
				foreach (BaggageInfo flightInfo in _flights)
				{
					Console.WriteLine(string.Format(_format, flightInfo.FlightFrom, flightInfo.FlightNumber, flightInfo.Carousel));
				}

				Console.WriteLine();
			}
		}
	}
}
