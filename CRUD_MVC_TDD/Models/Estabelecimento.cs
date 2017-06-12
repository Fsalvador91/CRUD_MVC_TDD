using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC_TDD.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:(99) 9999-9999}")]
        public string Telefone { get; set; }
        public int CategoriaId { get; set; }
        public bool Status { get; set; }

        public CategoriaEstabelecimento CategoriaEstabelecimento { get; set; }
    }
}
