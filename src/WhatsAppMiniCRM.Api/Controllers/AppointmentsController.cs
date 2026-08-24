using Microsoft.AspNetCore.Mvc;
using WhatsAppMiniCRM.Api.Data;
using WhatsAppMiniCRM.Api.Models;

namespace WhatsAppMiniCRM.Api.Controllers;

[ApiController]
[Route("api/appointments")]
public sealed class AppointmentsController(InMemoryStore store) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUpcoming()
    {
        var rows = store.Appointments
            .Where(a => a.StartsAt >= DateTime.Today.AddDays(-1))
            .OrderBy(a => a.StartsAt)
            .Take(50)
            .Select(a => new
            {
                a.Id,
                a.CustomerId,
                CustomerName = store.Customers.FirstOrDefault(c => c.Id == a.CustomerId)?.DisplayName,
                PhoneNumber = store.Customers.FirstOrDefault(c => c.Id == a.CustomerId)?.PhoneNumber,
                a.StartsAt,
                a.ServiceName,
                a.Price,
                a.Status,
                a.Notes
            });

        return Ok(rows);
    }

    [HttpPost]
    public IActionResult Create(Appointment model)
    {
        if (!store.Customers.Any(c => c.Id == model.CustomerId))
            return BadRequest(new { error = "Customer does not exist." });

        store.AddAppointment(model);
        return Created($"/api/appointments/{model.Id}", model);
    }
}
