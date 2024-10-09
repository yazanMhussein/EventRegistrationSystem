# Event Registration System

## Setup Instructions
1. Clone the repository.
2. Run `dotnet restore` to install dependencies.
3. Update the `appsettings.json` with your SQL Server connection string and Mailjet API credentials.
4. Run `Update-Database` to apply the migrations and set up the database.
5. Start the application with `dotnet run`.

## Event Management
- Organizers can create, edit, delete, and view events.
- Participants can register for events, and receive confirmation emails.

## Mailjet Integration
- Add your Mailjet API Key and Secret to the `appsettings.json`.
- Confirmation emails are sent after successful registration.
