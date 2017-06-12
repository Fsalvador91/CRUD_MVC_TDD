using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_MVC_TDD.Servicos;
using CRUD_MVC_TDD.Models;

namespace CRUD_MVC_TDD.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Inserir()
        {
            var estabelecimentoServico = new EstabelecimentoServico();
            var estabelecimento = new Estabelecimento()
            {
                Nome = "Teste SA",
                NomeFantasia = "Teste",
                CNPJ = "74.661.640/0001-89",
                Email = "testegmail.com",
                CategoriaId = 1,
                Telefone = "(99) 9999-9999",
                Status = true,
            };

            var resultado = estabelecimentoServico.Inserir(estabelecimento);
            if (resultado.Count > 0)
            {
                throw new Exception("Não inseriu");
            }
        }

        [TestMethod]
        public void Excluir()
        {
            var estabelecimentoServico = new EstabelecimentoServico();
            var obj = estabelecimentoServico.ObterPorId(2);
            estabelecimentoServico.Remover(obj);

            var estabelecimentos = estabelecimentoServico.ListarGrid();

            if (estabelecimentos.Contains(obj))
            {
                throw new Exception("Não deletou");
            }
        }
    }
}
