using CRUD_MVC_TDD.Contexto;
using CRUD_MVC_TDD.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_MVC_TDD.Repositorios
{
    public class CategoriaEstabelecimentoRepositorio
    {
        protected ModeloContexto Db = new ModeloContexto();

        public IList<CategoriaEstabelecimento> ListarCategorias()
        {
            var categorias = Db.CategoriaEstabelecimento
                           .ToList();
            return categorias;
        }
    }
}