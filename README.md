# WebPostgresqlDemo

## Stack
- C#;
- ASP.NET Core MVC;
- Bootstrap;
- Entity Framework 6.

## Requires
Docker or PostgreSQL

## Launch using Docker
- Scan in appsettings.json connection string, where **Server=db**. Comment out another connection string.
- Enter in the console
  docker-compose up -d
<!-- To completely restart the application
docker-compose down --rmi local-->

## Launch using local PostgreSQL
- Scan in appsettings.json connection string, where **Server=localhost**. Comment out another connection string.
- Enter in the console
  cd WebPostgresqlDemo
  dotnet ef database update
