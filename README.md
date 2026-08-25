# WhatsApp Business Mini CRM — Presentable MVP

A lightweight .NET 8 WhatsApp-first CRM demo for barbers, salons, clinics, and small service businesses.

This version intentionally uses **no database**. The backend exposes sample in-memory APIs, while the frontend includes a fully navigable interactive demo so the product flow can be validated before adding production persistence.

## Current demo
- Responsive modern CRM dashboard
- Dashboard KPIs and business overview
- Interactive conversations inbox
- Switch between customers and local demo chats
- Send demo replies in the browser
- Customer list with search and tag filtering
- Add sample customers
- Appointment list and status summary
- Add sample appointments
- Quick replies that can be loaded into the chat composer
- Sample analytics
- Business settings screen
- Mobile responsive navigation
- In-memory .NET APIs
- WhatsApp Cloud API send endpoint and webhook verification endpoint
- Swagger
- No SQL Server / Entity Framework / database setup required

## Run locally
1. Install the .NET 8 SDK.
2. Clone this repository.
3. Open `src/WhatsAppMiniCRM.Api`.
4. Run:
   ```bash
   dotnet restore
   dotnet run
   ```
5. Open the URL printed by ASP.NET Core in your browser.
6. Swagger is available at `/swagger`.

## Demo behavior
The UI uses browser-side mock data so it remains useful even before the backend is connected to real WhatsApp traffic. Changes made in the demo reset when the page/application restarts.

Backend sample data is stored in `Data/InMemoryStore.cs` and also resets when the application restarts.

## WhatsApp setup
The UI works without WhatsApp credentials. To test the official WhatsApp Cloud API integration, set these values outside source control or in local configuration:

- `WhatsApp:PhoneNumberId`
- `WhatsApp:AccessToken`
- `WhatsApp:VerifyToken`

## Production roadmap
1. Parse inbound WhatsApp webhook messages.
2. Persist customers, conversations, messages and appointments.
3. Add SignalR live inbox updates.
4. Connect appointment actions directly to conversations.
5. Add authentication, roles and multi-business tenancy.
6. Add Meta Embedded Signup for customer WhatsApp onboarding.
7. Track billable WhatsApp template usage per business.
8. Add subscription plans and billing.
9. Deploy the API and web application with HTTPS.
