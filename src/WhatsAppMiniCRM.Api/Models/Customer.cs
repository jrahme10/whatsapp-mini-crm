namespace WhatsAppMiniCRM.Api.Models;

public sealed class Customer
{
    public long Id { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}
