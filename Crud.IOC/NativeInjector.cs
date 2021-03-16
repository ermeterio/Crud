using Crud.Application;
using Crud.Application.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.IOC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAppCrud, AppCrud>();
            services.AddScoped<Repository.RDBMS.Interface.IProduto, Repository.RDBMS.Produto>();
            services.AddScoped<Repository.RDBMS.Interface.ICategoria, Repository.RDBMS.Categoria>();
            services.AddScoped<Repository.RDBMS.Interface.IProdutoImagem, Repository.RDBMS.ProdutoImagem>();
        }
    }
}