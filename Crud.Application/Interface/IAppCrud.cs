using Crud.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Application.Interface
{
    public interface IAppCrud
    {
        Task<List<Produto>> ListarProdutos(int idProduto);
        Task<string> AtualizarProduto(Entities.Produto produto);
        Task<string> ExcluirProduto(int idProduto);
        Task<List<Entities.Categorium>> ListarCategoria(int idProduto);
        Task<string> AtualizarCategoria(Entities.Categorium categoria);
        Task<List<Entities.ProdutoImagem>> ListarProdutoImagem(int idProduto);
        Task<string> AtualizarProdutoImagem(List<Entities.ProdutoImagem> imagens);
        Task<string> ExcluirProdutoImagem(int idProduto);
    }
}
