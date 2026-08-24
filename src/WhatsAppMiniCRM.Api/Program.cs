using WhatsAppMiniCRM.Api.Data;
using WhatsAppMiniCRM.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<InMemoryStore>();
builder.Services.AddHttpClient<WhatsAppService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
