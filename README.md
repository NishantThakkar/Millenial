# Millenial
The project is divided in two Parts.
1. Server Side: Which Contains 3 Projects- Millenial.API, Millenial.DB, Millenial.Core
2. Client Side: Folder named **Web** is front end application
## Server Side:
**Tools and Technology:** Visual Studio 2019, .Net Core 3.1\
**Run:**: 
1. Open the solution in Visual Studio 2019 
2. Set Millenial.API as start up project 
3. Hit F5
### Configurations
#### Millenial.API
**appsettings.json**\
File Path: The log directory path\
MillennialConnectionString: Connestion string of the database\
**StartUp.cs**
CORS setup: URL of client side application
#### Millenial.DB
If Entity Framework related error occurs, latest version of .Net Core can be downloaded from below url 
https://aka.ms/dotnet-core-applaunch?framework=Microsoft.NETCore.App&framework_version=3.1.2&arch=x64&rid=win10-x64
### Features
1. Error Logging 
2. Swagger
3. List with server side Search, Sort, Filter and Paging 
### Development Pattern
1. Repository 
2. Entity framework core with Code First
## Client Side:
**Tools and Technology:** Visual Studion Code, Angular 9, Angular CLI, Material Design\
**System Requirement:** angular cli: >= 9.0.7 node >= V12.16.0 npm: >= 6.14.3\
**Run:** Go to **Web** directory and fire **ng serve** in command prompt
### Features
1. Error handler
2. Material List 
3. Material Progress Bar
### Configurations
1. src\environments\environment.ts: set **serverUrl** to the URL on which **Millenial.API** project runs
