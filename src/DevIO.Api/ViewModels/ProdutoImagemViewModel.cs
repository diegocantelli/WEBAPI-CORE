using System;
using System.ComponentModel.DataAnnotations;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.ViewModels
{
    //Decorando a classe para permitir que seja enviado no request um json com FormFile, coisa que não é permitida por padrão no WEBAPI
    [ModelBinder(typeof(JsonWithFilesFormDataModelBinder), Name = "produto")]
    public class ProdutoImagemViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        //IFormFile -> Permite que a imagem seja enviado numa forma de stream, sem ultrapassar o limite da aplicação
        public IFormFile ImagemUpload { get; set; }

        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public string NomeFornecedor { get; set; }
    }
}