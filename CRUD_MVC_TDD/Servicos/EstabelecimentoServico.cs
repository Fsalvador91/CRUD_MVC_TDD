using CRUD_MVC_TDD.Models;
using CRUD_MVC_TDD.Repositories;
using System;
using System.Collections.Generic;
using CRUD_MVC_TDD.Utilitarios;

namespace CRUD_MVC_TDD.Servicos
{
    public class EstabelecimentoServico
    {
        private readonly EstabelecimentoRepositorio repositorio;

        public EstabelecimentoServico()
        {
            repositorio = new EstabelecimentoRepositorio();
        }

        public List<string> Inserir(Estabelecimento obj)
        {
            var validacoes = Validacoes(obj);
            try
            {
                if (validacoes.Count == 0)
                {
                    repositorio.Inserir(obj);
                    return new List<string>();
                }

                return validacoes;
            }
            catch (Exception ex)
            {
                List<string> erros = new List<string>();
                if (ex.InnerException != null)
                    erros.Add("Ocorreu erro ao tentar inserir: " + ex.InnerException.Message);
                else
                    erros.Add("Ocorreu erro ao tentar inserir: " + ex.Message);
                return erros;
            }
        }

        public Estabelecimento ObterPorId(int id)
        {
            return repositorio.ObterPorId(id);
        }

        public IList<Estabelecimento> ListarGrid()
        {
            return repositorio.ListarEstabelecimentoGrid();
        }

        public IEnumerable<Estabelecimento> ListarTodos()
        {
            return repositorio.ListarTodos();
        }

        public List<string> Alterar(Estabelecimento obj)
        {
            var validacoes = Validacoes(obj);
            try
            {
                if (validacoes.Count == 0)
                {
                    repositorio.Alterar(obj);
                    return new List<string>();
                }

                return validacoes;
            }
            catch (Exception ex)
            {
                List<string> erros = new List<string>();
                if (ex.InnerException != null)
                    erros.Add("Ocorreu erro ao tentar alterar: " + ex.InnerException.InnerException);
                else
                    erros.Add("Ocorreu erro ao tentar alterar: " + ex.Message);
                return erros;
            }
        }

        public void Remover(Estabelecimento obj)
        {
            repositorio.Remover(obj);
        }

        public List<string> Validacoes(Estabelecimento obj)
        {
            List<string> Erros = new List<string>();

            if (string.IsNullOrEmpty(obj.Nome))
                Erros.Add("Nome / Razão Social é obrigatório");

            if (string.IsNullOrEmpty(obj.CNPJ))
                Erros.Add("CNPJ é obrigatório");

            if (!string.IsNullOrEmpty(obj.Email))
            {
                try
                {
                    new System.Net.Mail.MailAddress(obj.Email);
                }
                catch
                {
                    Erros.Add("E-mail inválido");
                }
            }

            if (obj.CategoriaId == (int)Enumerados.Categorias.SuperMercado)
            {
                if (string.IsNullOrEmpty(obj.Telefone))
                {
                    Erros.Add("Telefone é obrigatório para categoria Super Mercado");
                }
            }

            return Erros;
        }
    }
}

