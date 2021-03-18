using Crud.Application.Interface;
using Crud.Repository;
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
        public AppCrud(CrudContext context,                              
                              IProduto produtoDB,
                              ICategoria categoriaDB)
        {
            _context = context;
            _produtoDB = produtoDB;
            _categoriaDB = categoriaDB;
        }

        public async Task<List<Entities.Produto>> ListarProdutos(int idProduto, string nome)
        {
            return await _produtoDB.Listar(_context, idProduto, nome);
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
        

        public async Task<string> Incluir(Entities.Produto produto)
        {
            return await _produtoDB.Inserir(_context, produto);
        }
    }
}
