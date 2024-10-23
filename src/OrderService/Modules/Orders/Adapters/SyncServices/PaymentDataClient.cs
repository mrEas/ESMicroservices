using Microsoft.Extensions.Options;
using OrderService.Modules.Orders.Dto.Payments;
using OrderService.Modules.Orders.Ports.SyncServices;
using System.Text;
using System.Text.Json;

namespace OrderService.Modules.Orders.Adapters.SyncServices
{
    public class PaymentDataClient : IPaymentDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly PaymentOptions _paymentOptions;

        public PaymentDataClient(HttpClient httpClient, IOptions<PaymentOptions> paymentOptions)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _paymentOptions = paymentOptions?.Value ?? throw new ArgumentNullException(nameof(paymentOptions));
        }

        public async Task CreatePaymentFromOrderAsync(PaymentCreateDto paymentCreateDto)
        {
            var httpcontent = new StringContent(
                JsonSerializer.Serialize(paymentCreateDto),
                Encoding.UTF8, 
                "application/json");

            var response = await _httpClient.PostAsync(_paymentOptions.Url,httpcontent);

            await Console.Out.WriteLineAsync(response.IsSuccessStatusCode
                ? "==> Sync post query to Payment service was ok"
                : "==> Sync post query to Payment service was NOT ok"); 
        }
    }
}
