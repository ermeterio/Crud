using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Crud.Entities
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? PrecoVenda { get; set; }
        public string Descricao { get; set; }
        [NotMapped]
        public string Imagem { get; set; }
        [NotMapped]
        public int IdCategoria { get; set; }
        [NotMapped]
        public IFormFile ImagemFile { get; set; }
    }
}
