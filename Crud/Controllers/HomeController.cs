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
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http;

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
        [HttpGet("")]
        [HttpGet("listar/{nome}")]
        public async Task<IActionResult> Index(string nome)
        {
            ViewBag.Nome = nome;
            var prods = await _appCrud.ListarProdutos(0, nome);
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
        public async Task<string> Cadastrar([FromForm] Entities.Produto produto)
        {
            try
            {
                if(produto.FormFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        produto.FormFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        produto.Imagem = Convert.ToBase64String(fileBytes);
                    }
                }
                await _appCrud.Incluir(produto);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Houve um erro ao processar a requisição, tente novamente";
            }
        }

        [HttpPost("Atualizar")]
        public async Task<string> Atualizar([FromForm] Entities.Produto produto)
        {
            try
            {
                if (produto.FormFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        produto.FormFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        produto.Imagem = Convert.ToBase64String(fileBytes);
                    }
                }
                await _appCrud.AtualizarProduto(produto);
                return "OK";
            }
            catch (Exception ex)
            {
                return "Houve um erro ao processar a requisição, tente novamente";
            }
        }

        [HttpGet("obterProduto/{id}")]
        public async Task<Entities.Produto> ObterProduto(int id)
        {
            try
            {                
                var prods = await _appCrud.ListarProdutos(id, null);                
                var Produto = prods.FirstOrDefault();
                //if(!string.IsNullOrEmpty(Produto.Imagem))
                //{
                //    var bytes = Convert.FromBase64String(Produto.Imagem);
                //    Stream stream = new MemoryStream(bytes);
                //    Produto.FormFile = ReturnFormFile(new FileStreamResult(stream, contentType: ));
                //}                
                return Produto;
            }
            catch (Exception ex)
            {
                return new Entities.Produto();
            }            
        }

        public IFormFile ReturnFormFile(FileStreamResult result)
        {
            var ms = new MemoryStream();
            try
            {
                result.FileStream.CopyTo(ms);
                return new FormFile(ms, 0, ms.Length, result.FileDownloadName, result.ContentType); ;
            }
            catch (Exception e)
            {
                ms.Dispose();
                throw;
            }
            finally
            {
                ms.Dispose();
            }
        }
    }
}
