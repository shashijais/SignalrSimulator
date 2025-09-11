# SignalrSimulator

## Overview

`SignalrSimulator` is a simple C# console application designed to simulate a high volume of HTTP GET requests to a specified API endpoint. It is useful for load testing and performance evaluation of services, particularly those handling RFID lookups.

## How It Works

- The application sends 36,000 HTTP GET requests to `http://localhost:5153/api/lookup`, each with a unique `rfId` parameter (e.g., `RFID1`, `RFID2`, ...).
- Requests are dispatched at approximately 300 requests per second (RPS) by introducing a 3ms delay between each request.
- All requests are executed asynchronously and awaited collectively.
- Upon completion, the total time taken to process all requests is displayed.

## Usage

1. **Prerequisites:**
   - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later installed.

2. **Build and Run:**