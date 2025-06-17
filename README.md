# Weekly Email Sending System

## 📧 Overview

This project is a multi-layered .NET application designed to manage and send weekly email notifications to a list of users. It utilizes the following technologies:

- **.NET Core 8 Web API** (Presentation Layer)
- **ADO.NET with Stored Procedures** (Data Access Layer)
- **Business Logic Layer (BAL)** with Outlook integration
- **Windows Background Service** for automated weekly email sending

## 🧱 Project Structure

- **DAL**  
  Data Access Layer: Interacts with SQL Server using ADO.NET and stored procedures to manage email addresses and transaction logs.

- **BAL**  
  Business Logic Layer: Contains core logic for adding, deleting, retrieving emails, and sending emails via Microsoft Outlook.

- **API**  
  Exposes RESTful endpoints to interact with the system (e.g., add/delete emails, get logs, trigger sending).

- **Worker Service**  
  A background service that automatically sends emails every 7 days using a static method from the BAL.

## 📂 Technologies Used

- .NET Core 8 (Web API & Worker Service)
- ADO.NET for database operations
- SQL Server (with stored procedures)
- Microsoft Outlook Interop (Email sending)
- Dependency Injection (for API)
- Logging (ILogger)

## 🚀 Features

- Add, delete, and fetch email addresses
- Store and retrieve email transaction logs
- Send mass emails via Outlook
- Schedule automatic weekly sending using a Windows Background Worker
- Fully separated architecture (DAL, BAL, API)

## 🔁 How Automatic Sending Works

The `Worker` service:
- Runs continuously in the background
- Triggers the `SendEmailToAll()` static method in `EmailService` every 7 days
- Logs success/failure to the console/logger
- Retries in case of errors

## 🛠️ Prerequisites

- .NET 8 SDK
- SQL Server
- Microsoft Outlook installed (modern version)
- Visual Studio or CLI support
- Proper Outlook Interop Library reference (`Microsoft.Office.Interop.Outlook`)

## 🧪 How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/weekly-email-sender.git
