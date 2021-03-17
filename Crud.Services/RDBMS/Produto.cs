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
    public class Produto : IProduto
    {
        public async Task<string> Apagar(CrudContext context, int id)
        {
            try
            {
                var parameters = new[] {new SqlParameter("@int_idProduto", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = id },
                                    new SqlParameter("@str_erro", System.Data.SqlDbType.VarChar, 200){ Direction = ParameterDirection.Output} };
                var result = context.Produtos.FromSqlRaw("exec sp_produtoDel @int_idProduto, @str_erro OUTPUT", parameters);

                Console.Write(result);
                return "ok";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return "Erro ao apagar registro";
            }
        }

        public async Task<string> Atualizar(CrudContext context, Entities.Produto obj)
        {
            try
            {
                string resultado = "";
                var parameters = new[] {new SqlParameter("@int_idProduto", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = obj.Id },
                                        new SqlParameter("@str_nomeProduto", System.Data.SqlDbType.VarChar, 100){ Direction = ParameterDirection.Input, Value = obj.Nome },
                                        new SqlParameter("@dec_precoVenda", System.Data.SqlDbType.Decimal){ Direction = ParameterDirection.Input, Value = obj.PrecoVenda },
                                        new SqlParameter("@str_descricao", System.Data.SqlDbType.VarChar, 300){ Direction = ParameterDirection.Input, Value = obj.Descricao },
                                        new SqlParameter("@str_erro", System.Data.SqlDbType.VarChar, 200){ Direction = ParameterDirection.Output} };

                var result = context.Produtos.FromSqlRaw($"exec sp_produtoUpd @int_idProduto, " +
                                                                             $"@int_idCategoria, " +
                                                                             $"@str_nomeProduto," +
                                                                             $"@dec_precoVenda," +
                                                                             $"@str_descricao," +
                                                                             $"@str_erro OUTPUT", parameters);
                Console.Write(result);
                return "";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<string> Inserir(CrudContext context, Entities.Produto obj)
        {
            try
            {
                string resultado = "";
                var parameters = new[] {new SqlParameter("@int_idProduto", System.Data.SqlDbType.Int){ Direction = ParameterDirection.Input, Value = obj.Id },
                                        new SqlParameter("@str_nomeProduto", System.Data.SqlDbType.VarChar, 100){ Direction = ParameterDirection.Input, Value = obj.Nome },
                                        new SqlParameter("@dec_precoVenda", System.Data.SqlDbType.Decimal){ Direction = ParameterDirection.Input, Value = obj.PrecoVenda },
                                        new SqlParameter("@str_descricao", System.Data.SqlDbType.VarChar, 300){ Direction = ParameterDirection.Input, Value = obj.Descricao },
                                        new SqlParameter("@str_erro", System.Data.SqlDbType.VarChar, 200){ Direction = ParameterDirection.InputOutput, Value = "" } };

                var result = context.Produtos.FromSqlRaw($"exec sp_produtoIns @int_idProduto, " +
                                                                             $"@int_idCategoria, " +
                                                                             $"@str_nomeProduto," +
                                                                             $"@dec_precoVenda," +
                                                                             $"@str_descricao," +
                                                                             $"@str_erro OUTPUT", parameters);
                Console.Write(result);
                return "";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<List<Entities.Produto>> Listar(CrudContext context, int id)
        {
            try
            {
                var param = new SqlParameter("@int_idProduto", System.Data.SqlDbType.Int) { Direction = ParameterDirection.Input, Value = id };
                var result = context.Produtos.FromSqlRaw("exec sp_produtoSel @int_idProduto", param).ToList();
                if (result.Count() > 0)
                    return result;

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return new List<Entities.Produto>();
        }
    }
}
