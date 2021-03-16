using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Crud.Entities
{
    public partial class Categorium
    {
        public Categorium()
        {
            Produtos = new HashSet<Produto>();
        }
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
