using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AlertDefinitions.Repositories;

public static class EntityFrameworkExtension
{
    /// <summary>
    /// Used to ensure that the database exists
    /// </summary>
    /// <param name="app"></param>
    public static void InitializeDatabase(this IApplicationBuilder app)
    {
        Console.WriteLine("Console Log for Initializing database");
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

            if (!context.Database.CanConnect() || !context.Database.EnsureCreated())
            {
                Console.WriteLine("could not connect or ensure create database");
            }
        }
    }
}
