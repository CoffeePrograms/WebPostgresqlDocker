using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebPostgresqlDemo.Models;

/*  Создание / обновление БД
 *  удалить папку миграций и бд на сервере, затем в cmd
 *  cd WebPostgresqlDemo
 *  dotnet ef migrations add Init
 *  Для IIS: 
 *      dotnet ef database update
 *  Для Docker: 
 *      dotnet ef migrations script
 *      скрипты положить в папку sql
 */

/*  Запуск докера композа
 *  Расскомментировать строчку с db в appsettings.json, закомментировать с localhost
 *  Открыть cmd
 *  docker-compose up -d
 *  docker-compose down --rmi local
 */


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }

    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasData(
                new UserModel
                {
                    Id = 1,
                    Name = "John Smith",
                    Email = "smit@google.com"
                },
                new UserModel
                {
                    Id = 2,
                    Name = "Anna Silver",
                    Email = "silver@google.com"
                },
                new UserModel
                {
                    Id = 3,
                    Name = "John Mitchell",
                    Email = "mitchell@google.com"
                },
                new UserModel
                {
                    Id = 4,
                    Name = "Justin Haynes",
                    Email = "haynes@google.com"
                },
                new UserModel
                {
                    Id = 5,
                    Name = "Charles Lopez",
                    Email = "lopez@google.com"
                }
            );
    }
}