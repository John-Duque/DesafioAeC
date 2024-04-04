using System.Collections.ObjectModel;
using DesafioAeC.Application.DI;
using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Domain.Interfaces.Services;
using DesafioAeC.Domain.Views;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

namespace DesafioAeC.Robo;

public class UnitTest1 : IClassFixture<TestFixture>
{
    private IWebDriver _driver;
    private IAluraService _aluraService;
    private IAluraPO _aluraPO;
    public UnitTest1(TestFixture testFixture)
    {
        _driver = testFixture.Driver;
        _aluraService = testFixture.ServiceProvider.GetService<IAluraService>();
        _aluraPO = testFixture.ServiceProvider.GetService<IAluraPO>();
    }

    [Fact]
    public async Task Test1()
    {
        _aluraPO.Navegar("https://www.alura.com.br/");
        _aluraPO.InserirDadoEPequisarCurso();
        AluraView alura = _aluraPO.GetDadosCurso();
        await _aluraService.Post(alura);
    }
}
