# WhatsApp Business Mini CRM — Database-Free MVP

A lightweight .NET 8 starter for a WhatsApp-first CRM aimed at barbers, salons, clinics, and small service businesses.

This version intentionally uses **no database**. Sample customers, conversations, dashboard KPIs, and appointments are stored in memory so you can run and customize the product immediately.

## Included
- Responsive CRM dashboard
- Dashboard KPIs
- Sample customers
- In-memory conversations
- In-memory appointments
- Create appointment API
- WhatsApp Cloud API send endpoint
- WhatsApp webhook verification endpoint
- Swagger
- No SQL Server / Entity Framework / database setup required

## Run locally
1. Install the .NET 8 SDK.
2. Open `src/WhatsAppMiniCRM.Api`.
3. Run:
   ```bash
   dotnet restore
   dotnet run
   ```
4. Open the URL printed by ASP.NET Core.
5. Swagger is available at `/swagger`.

## Data behavior
All demo data is created in `Data/InMemoryStore.cs` when the app starts. Changes made through the API live only in memory and reset when the application restarts.

## WhatsApp setup
The UI works without WhatsApp credentials. To test the official WhatsApp Cloud API integration, set these values in `appsettings.json` or environment variables:

- `WhatsApp:PhoneNumberId`
- `WhatsApp:AccessToken`
- `WhatsApp:VerifyToken`

A production deployment should store secrets outside source control.

## Next steps
1. Parse inbound WhatsApp webhook messages.
2. Add an in-memory message store and live conversation updates.
3. Add appointment create/edit UI from a chat.
4. Add quick replies and tags.
5. Add authentication and multi-business support.
6. Add persistence only when the product flow is validated.
