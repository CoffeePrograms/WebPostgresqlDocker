# WebPostgresqlDemo

## Stack
- C#;
- ASP.NET Core MVC;
- Bootstrap;
- PostgreSQL;
- Docker.

## Requires
Docker or PostgreSQL

## Launch using Docker
- Uncomment in appsettings.json connection string, where **Server=db**. Comment out another connection string.
- Enter in the console
  docker-compose up -d
<!-- To completely restart the application
docker-compose down --rmi local-->

## Launch using local PostgreSQL
- Uncomment in appsettings.json connection string, where **Server=localhost**. Comment out another connection string.
- Enter in the console
  cd WebPostgresqlDemo
  dotnet ef database update
