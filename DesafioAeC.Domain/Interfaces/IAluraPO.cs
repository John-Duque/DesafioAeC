using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAeC.Domain.Views;

namespace DesafioAeC.Domain.Interfaces
{
    public interface IAluraPO
    {
        void Navegar(string url);
        void InserirDadoEPequisarCurso();
        AluraView GetDadosCurso();
    }
}