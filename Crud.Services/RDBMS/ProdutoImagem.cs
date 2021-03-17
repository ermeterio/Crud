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
                var prod = await Listar(context, id);
                context.ProdutoImagems.Remove(prod.First());
                context.SaveChanges();
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
                context.ProdutoImagems.Add(obj);
                context.SaveChanges();
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
