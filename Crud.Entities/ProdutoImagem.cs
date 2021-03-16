using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Crud.Entities
{
    public partial class ProdutoImagem
    {
        [Key]
        public int Id { get; set; }
        public int Idproduto { get; set; }
        public string Imagem { get; set; }

        public virtual Produto IdprodutoNavigation { get; set; }
    }
}
