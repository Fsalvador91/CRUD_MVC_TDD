using CRUD_MVC_TDD.Models;
using CRUD_MVC_TDD.Servicos;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System;

namespace CRUD_MVC_TDD.Controllers
{
    public class EstabelecimentoController : Controller
    {
        private readonly EstabelecimentoServico estabelecimentoServico;
        private readonly CategoriaEstabelecimentoServico categoriasServico;

        public EstabelecimentoController()
        {
            estabelecimentoServico = new EstabelecimentoServico();
            categoriasServico = new CategoriaEstabelecimentoServico();
        }

        public void CarregarCategorias()
        {
            ViewBag.Categorias = categoriasServico.ListarCategorias().Select(n => new SelectListItem()
            {
                Value = n.Id.ToString(),
                Text = n.Nome
            });
        }

        public ActionResult Index()
        {
            IEnumerable<Estabelecimento> estabelecimentos = estabelecimentoServico.ListarGrid();
            return View(estabelecimentos);
        }

        public ActionResult Inserir()
        {
            CarregarCategorias();
            return View();
        }

        public ActionResult Alterar(int id)
        {
            Estabelecimento estabelecimento = estabelecimentoServico.ObterPorId(id);
            CarregarCategorias();
            return View("~/Views/Estabelecimento/Inserir.cshtml", estabelecimento);
        }

        [HttpPost]
        public ActionResult Salvar(Estabelecimento estabelecimento)
        {
            List<string> resultado = new List<string>();

            if (estabelecimento.Id == 0)
            {
                resultado = estabelecimentoServico.Inserir(estabelecimento);
            }
            else
            {
                resultado = estabelecimentoServico.Alterar(estabelecimento);
            }

            if (!resultado.Any())
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errosValidacoes"] = string.Join("<br>", resultado);
            }

            CarregarCategorias();
            return View("~/Views/Estabelecimento/Inserir.cshtml", estabelecimento);
        }

        public ActionResult Remover(int id)
        {
            estabelecimentoServico.Remover(estabelecimentoServico.ObterPorId(id));
            return RedirectToAction("Index");
        }
    }
}