using Crud.Application.Interface;
using Crud.Models;
using Crud.Repository.RDBMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crud.Repository;
using Crud.Repository.RDBMS.Interface;
using Crud.Entities;

namespace Crud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppCrud _appCrud;
        

        public HomeController(ILogger<HomeController> logger, IAppCrud appCrud)
        {
            _logger = logger;
            _appCrud = appCrud;
            
        }

        public async Task<IActionResult> Index()
        {
            var prods = await _appCrud.ListarProdutos(0);
            foreach(var prod in prods)
            {
                prod.ProdutoImagems = await _appCrud.ListarProdutoImagem(prod.Id);
            }
            ViewBag.Categorias = await _appCrud.ListarCategoria(0);            
            return View(prods);
        }   
        
        [HttpDelete("apagar/{id}")]
        public async Task<string> DeletarProduto(int id)
        {
            try
            {
                await _appCrud.ExcluirProduto(id);
                return "OK";
            }
            catch(Exception ex)
            {
                return "Houve um erro ao processar a requisição, tente novamente";
            }            
        }
           
        [HttpPost("DeletarProdutosSelecionados")]
        public async Task<string> DeletarProdutosSelecionados([FromBody]ExclusaoItens searchIDs)
        {            
            try
            {
                foreach (string id in searchIDs.ids)
                    await _appCrud.ExcluirProduto(Convert.ToInt32(id));
                return "OK";
            }
            catch (Exception ex)
            {
                return "Houve um erro ao processar a requisição, tente novamente";
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<string> Cadastrar([FromBody] Entities.Produto produto)
        {
            try
            {
                await _appCrud.Incluir(produto);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Houve um erro ao processar a requisição, tente novamente";
            }
        }
    }
}
