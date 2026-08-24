using WhatsAppMiniCRM.Api.Models;

namespace WhatsAppMiniCRM.Api.Data;

public sealed class InMemoryStore
{
    private long _appointmentId = 3;

    public List<Customer> Customers { get; } =
    [
        new() { Id = 1, DisplayName = "Sarah Khalil", PhoneNumber = "+961 70 123 456", Notes = "Regular customer. Prefers layered haircut.", CreatedAtUtc = DateTime.UtcNow.AddMonths(-3) },
        new() { Id = 2, DisplayName = "Charbel M.", PhoneNumber = "+961 71 222 333", CreatedAtUtc = DateTime.UtcNow.AddMonths(-2) },
        new() { Id = 3, DisplayName = "Fadi Barakat", PhoneNumber = "+961 76 444 555", CreatedAtUtc = DateTime.UtcNow.AddMonths(-1) },
        new() { Id = 4, DisplayName = "May Ziadeh", PhoneNumber = "+961 03 555 777", CreatedAtUtc = DateTime.UtcNow.AddDays(-18) }
    ];

    public List<Conversation> Conversations { get; } =
    [
        new() { Id = 1, CustomerId = 1, Status = "Open", LastMessageAtUtc = DateTime.UtcNow.AddMinutes(-4) },
        new() { Id = 2, CustomerId = 2, Status = "Open", LastMessageAtUtc = DateTime.UtcNow.AddMinutes(-12) },
        new() { Id = 3, CustomerId = 3, Status = "Closed", LastMessageAtUtc = DateTime.UtcNow.AddHours(-1) },
        new() { Id = 4, CustomerId = 4, Status = "Open", LastMessageAtUtc = DateTime.UtcNow.AddHours(-2) }
    ];

    public List<Appointment> Appointments { get; } =
    [
        new() { Id = 1, CustomerId = 1, StartsAt = DateTime.Today.AddDays(1).AddHours(17), ServiceName = "Haircut", Price = 15, Status = "Confirmed" },
        new() { Id = 2, CustomerId = 2, StartsAt = DateTime.Today.AddHours(16), ServiceName = "Hair + Beard", Price = 22, Status = "Pending" },
        new() { Id = 3, CustomerId = 3, StartsAt = DateTime.Today.AddDays(-2).AddHours(13), ServiceName = "Haircut", Price = 15, Status = "Completed" }
    ];

    public int UnreadMessages { get; set; } = 12;

    public Appointment AddAppointment(Appointment model)
    {
        lock (Appointments)
        {
            model.Id = ++_appointmentId;
            Appointments.Add(model);
            return model;
        }
    }
}
