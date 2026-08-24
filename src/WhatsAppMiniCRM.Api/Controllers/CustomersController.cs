using Microsoft.AspNetCore.Mvc;
using WhatsAppMiniCRM.Api.Data;
using WhatsAppMiniCRM.Api.Models;

namespace WhatsAppMiniCRM.Api.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController(InMemoryStore store) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Customer>> GetAll() => Ok(store.Customers.OrderByDescending(x => x.Id));
}
