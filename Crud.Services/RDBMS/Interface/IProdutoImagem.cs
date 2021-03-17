using Crud.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repository.RDBMS.Interface
{
    public interface IProdutoImagem
    {
        Task<List<Entities.ProdutoImagem>> Listar(CrudContext context, int id);
        Task<string> Atualizar(CrudContext context, Entities.ProdutoImagem obj);
        Task<string> Apagar(CrudContext context, int id);
        Task<string> Inserir(CrudContext context, Entities.ProdutoImagem obj);
    }
}
