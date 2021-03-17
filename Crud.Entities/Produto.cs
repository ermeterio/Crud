using System;
using System.Collections.Generic;

#nullable disable

namespace Crud.Entities
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoImagems = new HashSet<ProdutoImagem>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ProdutoImagem> ProdutoImagems { get; set; }
    }
}
