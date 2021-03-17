using System;
using System.Collections.Generic;

#nullable disable

namespace Crud.Entities
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? PrecoVenda { get; set; }
        public string Descricao { get; set; }        

        public List<ProdutoImagem> Imagens { get; set; }
    }
}
