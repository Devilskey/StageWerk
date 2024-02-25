using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using AlertDefinitions.Repositories;
using Microsoft.EntityFrameworkCore;
using AlertDefinitions.Common;
using Microsoft.Extensions.Configuration;

namespace AlertDefinitions.UnitTest
{
    [TestClass]
    public class ExtensionUnitTest
    {
        [TestMethod]
        public void DatabaseExtensionUnitTestError()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            IServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();
            IApplicationBuilder app = new ApplicationBuilder(serviceProvider);
            Exception? ex =  null;
            try
            {
                app.InitializeDatabase();
            }
            catch (Exception exCaught)
            {
                ex = exCaught;
            }
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DatabaseExtensionUnitTest()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer("");
            });
            IServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();
            IApplicationBuilder app = new ApplicationBuilder(serviceProvider);
            Exception? ex = null;
            try
            {
                app.InitializeDatabase();
            }
            catch (Exception exCaught)
            {
                ex = exCaught;
            }
        }

        [TestMethod]
        public void LogExtensionUnitTest()
        {
            string[] args = { };
            var builder = WebApplication.CreateBuilder(args);
            Exception? exception = null;
            IServiceCollection Services = builder.Services;
           
            try
            {
                Services.AddSerilogConfiguration(builder.Configuration);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.IsNull(exception);
        }

    }
}
