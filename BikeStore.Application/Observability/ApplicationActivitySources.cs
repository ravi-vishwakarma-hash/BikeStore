using System.Diagnostics;

namespace BikeStore.Application.Observability
{
    public static class ApplicationActivitySources
    {
        public const string OrderService = "MyApp.OrderService";
        public const string PaymentService = "MyApp.PaymentService";

        public static readonly ActivitySource Orders = new(OrderService);
        public static readonly ActivitySource Payments = new(PaymentService);
    }
}
