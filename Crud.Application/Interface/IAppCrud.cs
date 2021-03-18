using Crud.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Application.Interface
{
    public interface IAppCrud
    {
        Task<List<Produto>> ListarProdutos(int idProduto, string nome);
        Task<string> AtualizarProduto(Entities.Produto produto);
        Task<string> Incluir(Entities.Produto produto);
        Task<string> ExcluirProduto(int idProduto);
        Task<List<Entities.Categorium>> ListarCategoria(int idProduto);
        Task<string> AtualizarCategoria(Entities.Categorium categoria);       
    }
}
