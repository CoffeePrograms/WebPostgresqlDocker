using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebPostgresqlDemo.Models;

/*  �������� / ���������� ��
 *  ������� ����� �������� � �� �� �������, ����� � cmd
 *  cd WebPostgresqlDemo
 *  dotnet ef migrations add Init
 *  ��� IIS: 
 *      dotnet ef database update
 *  ��� Docker: 
 *      dotnet ef migrations script
 *      ������� �������� � ����� sql
 */

/*  ������ ������ �������
 *  ������������������ ������� � db � appsettings.json, ���������������� � localhost
 *  ������� cmd
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