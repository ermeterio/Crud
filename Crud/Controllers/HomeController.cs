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
            var cts = await _appCrud.ListarCategoria(prods.FirstOrDefault().IdCategoria);
            var imgs = await _appCrud.ListarProdutoImagem(prods.FirstOrDefault().Id);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
