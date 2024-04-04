using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Domain.Interfaces.Services;
using DesafioAeC.Domain.PageObjects;
using DesafioAeC.Infra.Context;
using DesafioAeC.Infra.Repository;
using DesafioAeC.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DesafioAeC.Application.DI
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public TestFixture()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();


            Driver = new ChromeDriver();
            string? connectionString = "server=localhost;DataBase=dbAPI;Uid=root;Pwd=03200109";
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IWebDriver>(Driver);
            serviceCollection.AddAutoMapper(typeof(MappingProfile).Assembly);
            serviceCollection.AddScoped<IAluraPO, AluraPO>();
            serviceCollection.AddScoped<IAluraService, AluraService>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            serviceCollection.AddDbContext<MyContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            ServiceProvider = serviceCollection.BuildServiceProvider();

        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}