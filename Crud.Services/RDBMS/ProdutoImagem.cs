using Crud.Repository.Models;
using Crud.Repository.RDBMS.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repository.RDBMS
{
    public class ProdutoImagem : IProdutoImagem
    {
        public async Task<string> Apagar(CrudContext context, int id)
        {
            try
            {
                var parameters = new[] {new SqlParameter("@int_idImagem", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = id },
                                        new SqlParameter("@str_erro", System.Data.SqlDbType.VarChar){ Direction = ParameterDirection.InputOutput, Value = "" } };
                var result = context.Produtos.FromSqlRaw("exec sp_produtoImagemDel @int_idProdutoImagem, @str_erro OUTPUT", parameters);
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<string> Atualizar(CrudContext context, Entities.ProdutoImagem obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Inserir(CrudContext context, Entities.ProdutoImagem obj)
        {
            try
            {
                var parameters = new[] {new SqlParameter("@int_idProduto", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = obj.Idproduto },
                                        new SqlParameter("@str_imagem", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = obj.Imagem },
                                        new SqlParameter("@str_erro", System.Data.SqlDbType.Int){ Direction = ParameterDirection.InputOutput, Value = "" }};
                var result = context.ProdutoImagems.FromSqlRaw("exec sp_produtoImagemIns @int_idProduto, @str_imagem, @str_erro OUTPUT", parameters);
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<List<Entities.ProdutoImagem>> Listar(CrudContext context, int id)
        {
            try
            {
                var param = new SqlParameter("@int_idProduto", id);
                var result = context.ProdutoImagems.FromSqlRaw("exec sp_produtoImagemSel @int_idProduto", param).ToList();
                if (result.Count() > 0)
                    return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return new List<Entities.ProdutoImagem>();
        }
    }
}
