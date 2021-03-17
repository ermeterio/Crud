using Crud.Entities;
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
    public class Categoria : ICategoria
    {
        public async Task<string> Apagar(CrudContext context, int id)
        {
            try
            {
                var cat = await Listar(context, id);
                context.Categoria.Remove(cat.First());
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<string> Atualizar(CrudContext context, Categorium obj)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Inserir(CrudContext context, Categorium obj)
        {
            try
            {
                var result = context.Categoria.Add(obj);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return "";
        }

        public async Task<List<Categorium>> Listar(CrudContext context, int id)
        {
            try
            {
                var param = new SqlParameter("@int_idCategoria", id);
                var result = await context.Categoria.FromSqlRaw("exec sp_CategoriaSel @int_idCategoria", param).ToListAsync();
                if (result.Count() > 0)
                    return result;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return new List<Entities.Categorium>();
        }
    }
}
