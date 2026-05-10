using System.Diagnostics.Metrics;

namespace BikeStore.Application.Observability
{
    public static class ApplicationMeters
    {
        public const string OrderMeter = "MyApp.Orders";
        private static readonly Meter _meter = new(OrderMeter);

        public static readonly Counter<int> OrdersProcessed =
            _meter.CreateCounter<int>("orders.processed");

        public static readonly Histogram<double> OrderDuration =
            _meter.CreateHistogram<double>("orders.duration_ms");
    }
}
