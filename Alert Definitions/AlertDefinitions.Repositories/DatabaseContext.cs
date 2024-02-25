using Microsoft.EntityFrameworkCore;
using AlertDefinitions.Models;

namespace AlertDefinitions.Repositories;

public class DatabaseContext : DbContext
{
    public DbSet<LogLevels> LogLevel { get; set; }

    public DbSet<Event> Event { get; set; }

    public DbSet<LogLevelExpression> LogLevelExpressions { get; set; }

    public DbSet<UpdateLog> UpdateLog { get; set; }

    public DbSet<Webhook> Webhooks { get; set; }

    public DbSet<AlertDefinition> AlertDefinition { get; set; }

    public DbSet<Regex> Regex { get; set; }

    public DbSet<Recipient> Recipient { get; set; }

    public DbSet<Team> Team { get; set; }

    public DbSet<Employee> Employee { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { } 
}