using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace WhatsAppMiniCRM.Api.Services;

public sealed class WhatsAppService(HttpClient http, IConfiguration config)
{
    public async Task SendTextAsync(string to, string text, CancellationToken ct = default)
    {
        var phoneNumberId = config["WhatsApp:PhoneNumberId"];
        var token = config["WhatsApp:AccessToken"];
        if (string.IsNullOrWhiteSpace(phoneNumberId) || string.IsNullOrWhiteSpace(token))
            throw new InvalidOperationException("WhatsApp credentials are not configured.");

        using var req = new HttpRequestMessage(HttpMethod.Post, $"https://graph.facebook.com/v23.0/{phoneNumberId}/messages");
        req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        req.Content = new StringContent(JsonSerializer.Serialize(new {
            messaging_product = "whatsapp",
            to,
            type = "text",
            text = new { body = text }
        }), Encoding.UTF8, "application/json");

        var response = await http.SendAsync(req, ct);
        response.EnsureSuccessStatusCode();
    }
}
