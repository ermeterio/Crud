using Crud.Application.Interface;
using Crud.Repository.RDBMS;
using Crud.Repository.RDBMS.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Application
{
    public class AppCrud : IAppCrud
    {
        private readonly CrudContext _context;
        private readonly IProduto _produtoDB;
        private readonly ICategoria _categoriaDB;
        private readonly IProdutoImagem _produtoImagemDB;
        public AppCrud(CrudContext context,                              
                              IProduto produtoDB,
                              ICategoria categoriaDB,
                              IProdutoImagem produtoImagemDB)
        {
            _context = context;
            _produtoDB = produtoDB;
            _categoriaDB = categoriaDB;
            _produtoImagemDB = produtoImagemDB;
        }

        public async Task<List<Entities.Produto>> ListarProdutos(int idProduto)
        {
            return await _produtoDB.Listar(_context, idProduto);
        }

        public async Task<string> AtualizarProduto(Entities.Produto produto)
        {
            return await _produtoDB.Atualizar(_context, produto);
        }

        public async Task<string> ExcluirProduto(int idProduto)
        {
            return await _produtoDB.Apagar(_context, idProduto);
        }

        public async Task<List<Entities.Categorium>> ListarCategoria(int idProduto)
        {
            return await _categoriaDB.Listar(_context, idProduto);
        }

        public async Task<string> AtualizarCategoria(Entities.Categorium categoria)
        {
            return await _categoriaDB.Atualizar(_context, categoria);
        }

        public async Task<string> ExcluirCategoria(int idCategoria)
        {
            return await _categoriaDB.Apagar(_context, idCategoria);
        }

        public async Task<List<Entities.ProdutoImagem>> ListarProdutoImagem(int idProduto)
        {
            return await _produtoImagemDB.Listar(_context, idProduto);
        }

        public async Task<string> AtualizarProdutoImagem(List<Entities.ProdutoImagem> imagens)
        {
            foreach(var imagem in imagens)
            {
                await _produtoImagemDB.Atualizar(_context, imagem);
            }
            return "";
        }

        public async Task<string> ExcluirProdutoImagem(int idProduto)
        {
            return await _produtoImagemDB.Apagar(_context, idProduto);
        }

        public async Task<string> InserirProdutoImagem(List<Entities.ProdutoImagem> imagens)
        {
            foreach (var imagem in imagens)
            {
                await _produtoImagemDB.Inserir(_context, imagem);
            }
            return "";
        }

    }
}
