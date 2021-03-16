using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Crud.Entities
{
    public partial class Produto
    {
        public Produto()
        {
            ProdutoImagems = new HashSet<ProdutoImagem>();
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Descricao { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual ICollection<ProdutoImagem> ProdutoImagems { get; set; }
    }
}
