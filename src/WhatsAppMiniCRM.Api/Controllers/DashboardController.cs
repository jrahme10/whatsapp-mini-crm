using Microsoft.AspNetCore.Mvc;
using WhatsAppMiniCRM.Api.Data;

namespace WhatsAppMiniCRM.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
public sealed class DashboardController(InMemoryStore store) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var today = DateTime.Today;
        var month = today.Month;
        var year = today.Year;

        return Ok(new
        {
            newMessages = store.UnreadMessages,
            appointmentsToday = store.Appointments.Count(a => a.StartsAt.Date == today),
            pendingConversations = store.Conversations.Count(c => c.Status == "Open"),
            revenueThisMonth = store.Appointments
                .Where(a => a.Status == "Completed" && a.StartsAt.Month == month && a.StartsAt.Year == year)
                .Sum(a => a.Price ?? 0)
        });
    }
}
