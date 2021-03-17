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
                var prod = await Listar(context, id, null);
                context.Produtos.Remove(prod.First());
                context.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return "Erro ao apagar registro";
            }
        }

        public async Task<string> Atualizar(CrudContext context, Entities.Produto obj)
        {
            try
            {
                var result = context.Produtos.Update(obj);
                context.SaveChanges();
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
                var result = context.Produtos.Add(obj);
                context.SaveChanges();
                return "";
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<List<Entities.Produto>> Listar(CrudContext context, int id, string nome)
        {
            try
            {                
                var result = context.Produtos.FromSqlInterpolated($"exec sp_produtoSel @int_idProduto = {id}, @str_nome = {nome}").ToList();
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
