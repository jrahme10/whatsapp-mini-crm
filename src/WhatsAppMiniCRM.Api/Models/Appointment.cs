namespace WhatsAppMiniCRM.Api.Models;

public sealed class Appointment
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public DateTime StartsAt { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public decimal? Price { get; set; }
    public string Status { get; set; } = "Pending";
    public string? Notes { get; set; }
}
