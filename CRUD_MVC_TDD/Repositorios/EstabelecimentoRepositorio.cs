using CRUD_MVC_TDD.Contexto;
using CRUD_MVC_TDD.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CRUD_MVC_TDD.Repositories
{
    public class EstabelecimentoRepositorio
    {
        protected ModeloContexto Db = new ModeloContexto();

        public IList<Estabelecimento> ListarEstabelecimentoGrid()
        {
            var estabelecimento = Db.Estabelecimento
                           .Include("CategoriaEstabelecimento")
                           .ToList();
            return estabelecimento;
        }

        public Estabelecimento ObterPorId(int id)
        {
            var estabelecimento = Db.Estabelecimento
                           .FirstOrDefault(c => c.Id == id);
            return estabelecimento;
        }

        public void Inserir(Estabelecimento obj)
        {
            Db.Set<Estabelecimento>().Add(obj);
            Db.SaveChanges();
        }

        public IEnumerable<Estabelecimento> ListarTodos()
        {
            return Db.Set<Estabelecimento>().ToList();
        }

        public void Alterar(Estabelecimento obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Remover(Estabelecimento obj)
        {
            Db.Set<Estabelecimento>().Remove(obj);
            Db.SaveChanges();
        }
    }
}
