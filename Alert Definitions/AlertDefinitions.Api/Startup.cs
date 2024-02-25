using AlertDefinitions.Common;
using AlertDefinitions.Business;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Serilog;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using AlertDefinitions.Repositories;

namespace AlertDefinitions.Api;

public class Startup
{
    private IConfiguration Configuration { get; }

    /// <summary>
    /// Startup Initinalizer 
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Setsup the Services
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
        MapperConfiguration mapperConfig = new(config =>
        {
            config.AddProfile(new MappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();

        services.AddSingleton(mapper);
        services.AddMvc();

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen( 
            c=>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = Configuration.GetValue<string>("ApiName"),
                    Version = VersionHandler.GetVersion()
                }); 
            });
        services.AddEndpointsApiExplorer();
        services.AddHealthChecks();
        services.AddSerilogConfiguration(Configuration);

        services.AddDbContext<DatabaseContext>(options =>
        {
            options.UseSqlServer(Configuration.GetConnectionString("Connection"));
        });
    }

    /// <summary>
    /// Configures the app.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app)
    {
        app.InitializeDatabase();

        app.UseSerilogRequestLogging();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapControllers();
        });
    }
}