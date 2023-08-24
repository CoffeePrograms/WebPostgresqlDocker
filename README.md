# WebPostgresqlDemo

## Stack
- C#;
- ASP.NET Core ;
- Bootstrap;
- Entity Framework 6.

## Requires
Docker or PostgreSQL

## Запуск с Docker
- Расскомментировать в appsettings.json строку подключения, где Server=db.
- Закоментировать другую строку подключения.
- В консоли ввести docker-compose up -d
<!-- Для полного перезапуска приложения использовать docker-compose down --rmi local -->

## Запуск с PostgreSQL
- Расскомментировать в appsettings.json строку подключения, где Server=localhost.
- Закоментировать другую строку подключения.
- В консоли ввести
  cd WebPostgresqlDemo
  dotnet ef database update
 
