namespace WhatsAppMiniCRM.Api.Models;

public sealed class Conversation
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public string Status { get; set; } = "Open";
    public DateTime? LastMessageAtUtc { get; set; }
}
