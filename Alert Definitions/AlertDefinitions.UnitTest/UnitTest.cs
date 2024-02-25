using AlertDefinitions.Business;
using AlertDefinitions.Common;
using AlertDefinitions.Models;
using AutoMapper;

namespace AlertDefinitions.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestGetversion()
        {
            string? version = VersionHandler.GetVersion();
            Assert.IsNotNull(version);
        }

        [TestMethod]
        public void TestAutomapper()
        {
            MapperConfiguration mapperConfig = new(config =>
            {
                config.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            LogLevels testLogLevel = new()
            {
                Name = "Test"
            };

            LogLevelExpression loglevelEx = mapper.Map<LogLevelExpression>(testLogLevel);
            Console.WriteLine("Loglevel Name: {0}, LogLevelExpression: {1}", testLogLevel.Name, loglevelEx.Name);

            Assert.AreEqual(loglevelEx.Name, testLogLevel.Name);
        }
    }
}