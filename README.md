# Dungeon

A tool for managing your Dungeon World sessions, wherever you are.

### Development

#### You need
* SQL Express / SQL Server
* npm
* dotnet core 2.1

#### Setting up the project

* Migrate the database with `dotnet ef database update` 
* You might or might not need to create the database `Dungeon` beforehand
* If you're using SQL Server, remove `\\SQLEXPRESS` from `appsettings.Development.json`
* Startem up using `dotnet run` or `dotnet watch run`
