# CanvasSync
## A real-time collaborative whiteboard built with ASP.NET Core and SignalR
CanvasSync allows multiple clients to join the same shared canvas using a board code and draw together in real time. Canvas state is persisted automatically to Azure SQL, while SignalR handles real-time synchronisation between connected clients.
The site is currently hosted live and can be accessed at (samuelbatey.au)
NOTE: The site may take up to 60 seconds to load. This is due to the database being hosted on the serverless tier, meaning that after a period of time being idle the database will need to start up again. If you encounter any issues send me an email.
[![Build and deploy ASP.Net Core app to Azure Web App - CanvasSync](https://github.com/SamuelBatey/CanvasSync/actions/workflows/master_canvassync.yml/badge.svg?branch=master)](https://github.com/SamuelBatey/CanvasSync/actions/workflows/master_canvassync.yml)

## Why I built this
I wanted to build a project that went beyond a traditional CRUD application and required me to solve novel problems I had never tackled before. The main challenge was figuring out how to structure the data from the canvas drawings into something I could actually store in a database and send in real time to other clients.

## Features
* Real-time collaborative drawing
* Join shared canvases using unique board code
* Real-time synchronisation using SignalR
* Persistent canvas data using Entity Framework Core
* Azure SQL database
* Hosted on Azure App Service
* Automated CI/CD with GitHub Actions
* Canvas state restored from persistent storage

## Tech Stack
* **Backend**: C#, ASP.NET Core MVC
* **Real-time**: SignalR
* **ORM**: Entity Framework Core
* **Database**: Azure SQL
* **Cloud**: Azure App Service, Azure SignalR Service
* **CI/CD**: GitHub Actions
* **Frontend**: HTML, CSS, Javascript
* **Version Control**: Git/GitHub