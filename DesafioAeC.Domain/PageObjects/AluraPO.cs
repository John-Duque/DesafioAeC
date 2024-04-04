using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DesafioAeC.Domain.Interfaces;
using DesafioAeC.Domain.Views;
using OpenQA.Selenium;

namespace DesafioAeC.Domain.PageObjects
{
    public class AluraPO : IAluraPO
    {
        private IWebDriver _driver;
        private By _textBox;
        private By _submitButton;
        private By _submitButtonCurso;
        private By _tituloCurso;
        private By _professor;
        private By _descricaoProfessor;
        private By _cargaHoraria;
        private By _descricaoCursoTitulos;
        private By _descricaoCursoTextos;
        private By _descricaoCursoPublicoAlvo;

        public AluraPO(IWebDriver webDriver)
        {
            _driver = webDriver;
            _textBox = By.Id("header-barraBusca-form-campoBusca");
            _submitButton = By.TagName("button");
            _submitButtonCurso = By.XPath("//h4[contains(.,\'Curso RPA: automatize processos com ferramentas No/Low Code\')]");
            _tituloCurso = By.ClassName("course--banner-text-category");
            _professor = By.ClassName("instructor-title--name");
            _descricaoProfessor = By.ClassName("instructor-description--text");
            _cargaHoraria = By.ClassName("courseInfo-card-wrapper-infos");
            _descricaoCursoTitulos = By.ClassName("course-title--learn");
            _descricaoCursoTextos = By.ClassName("course-list--learn");
            _descricaoCursoPublicoAlvo = By.ClassName("couse-text--target-audience");
        }

        public void Navegar(string url)
        {
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        public void InserirDadoEPequisarCurso()
        {
            _driver.FindElement(_textBox).SendKeys("RPA");
            _driver.FindElement(_submitButton).Click();
            _driver.FindElement(_submitButtonCurso).Click();
        }

        public AluraView GetDadosCurso()
        {
            var cargaHoraria = double.Parse(_driver.FindElements(_cargaHoraria)[0].Text.Replace("h","").Replace("H",""));
            var alura = new AluraView()
            {
                Titulo = _driver.FindElement(_tituloCurso).Text,
                Professor = _driver.FindElement(_professor).Text,
                DescricaoProfessor = _driver.FindElement(_descricaoProfessor).Text,
                CargaHoraria = DateTime.Now.AddHours(cargaHoraria),
                Descricao = this.DescricaoCurso()

            };
            return alura;
        }

        public string DescricaoCurso()
        {
            string descricaoCurso = string.Empty;
            string primeiroTitulo = _driver.FindElements(_descricaoCursoTitulos)[0].Text;
            string segundoTitulo = _driver.FindElements(_descricaoCursoTitulos)[1].Text;
            string descricaoCursoPublicoAlvo = _driver.FindElement(_descricaoCursoPublicoAlvo).Text;
            ReadOnlyCollection<IWebElement> descricaoCursoTextos = _driver.FindElements(_descricaoCursoTextos);

            descricaoCurso = primeiroTitulo + Environment.NewLine;
            foreach (var item in descricaoCursoTextos)
            {
                descricaoCurso += item.Text + Environment.NewLine;
            }

            descricaoCurso += segundoTitulo + Environment.NewLine + descricaoCursoPublicoAlvo;

            return descricaoCurso;
        }
    }
}