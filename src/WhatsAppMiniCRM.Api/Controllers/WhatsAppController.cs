using Microsoft.AspNetCore.Mvc;
using WhatsAppMiniCRM.Api.Services;

namespace WhatsAppMiniCRM.Api.Controllers;

[ApiController]
[Route("api/whatsapp")]
public sealed class WhatsAppController(IConfiguration config, WhatsAppService whatsapp) : ControllerBase
{
    [HttpGet("webhook")]
    public IActionResult Verify([FromQuery(Name="hub.mode")] string? mode,
                                [FromQuery(Name="hub.verify_token")] string? verifyToken,
                                [FromQuery(Name="hub.challenge")] string? challenge)
    {
        if (mode == "subscribe" && verifyToken == config["WhatsApp:VerifyToken"])
            return Content(challenge ?? string.Empty);
        return Forbid();
    }

    [HttpPost("webhook")]
    public IActionResult Receive([FromBody] object payload)
    {
        // TODO: parse inbound messages, upsert customer/conversation/message, and mark unread.
        Console.WriteLine(payload.ToString());
        return Ok();
    }

    public sealed record SendTextRequest(string To, string Text);

    [HttpPost("send")]
    public async Task<IActionResult> Send(SendTextRequest request, CancellationToken ct)
    {
        await whatsapp.SendTextAsync(request.To, request.Text, ct);
        return Ok(new { sent = true });
    }
}
