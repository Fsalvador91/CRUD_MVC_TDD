using CRUD_MVC_TDD.Models;
using CRUD_MVC_TDD.Repositorios;
using System.Collections.Generic;

namespace CRUD_MVC_TDD.Servicos
{
    public class CategoriaEstabelecimentoServico
    {
        private readonly CategoriaEstabelecimentoRepositorio repositorio;

        public CategoriaEstabelecimentoServico()
        {
            repositorio = new CategoriaEstabelecimentoRepositorio();
        }

        public IEnumerable<CategoriaEstabelecimento> ListarCategorias()
        {
            return repositorio.ListarCategorias();
        }
    }
}
