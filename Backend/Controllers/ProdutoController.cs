using Backend.Models;
using Backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // POST: api/<ProdutoController>/lista/geladeira/2/2
        [HttpPost("lista/{term}/{page}/{pageSize}")]
        public async Task<IActionResult> GetLista(string term, int page, int pageSize) 
        {
            // Term será usado como parâmetro do filtro Contais no campo Nome
            try
            {
                var produtos = await _repository.GetAll(term, page, pageSize);
                if (produtos != null)
                {
                    return Ok(produtos);
                }
                else
                {
                    return BadRequest("Página não encontrada.");
                }

            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var produto = await _repository.GetProdutoById(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var produtos = await _repository.GetAllSemFiltro();
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // POST: api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult> AddOrAtt([FromBody] Produto model)
        {
            try
            {
                if (model.Id == 0) // Caso não seja informado um ID, cria um produto
                {
                    _repository.Add(model);
                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok();
                    }
                    else
                    {
                        return Ok("Não Salvou");
                    }
                }
                else // Caso seja informado um Id, atualiza um produto
                {
                    // Verifica se o produto existe
                    var produto = await _repository.GetProdutoById(model.Id);
                    if (produto != null) // Caso existe, efetua as alterações
                    {
                        _repository.Update(model);
                        await _repository.SaveChangeAsync();
                        return Ok();
                    }
                    else
                    {
                        // Retorna erro caso não encontre o registro
                        return BadRequest("Não foi possível encontrar o produto");
                    }
                }

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }
        // GET: api/<ProdutoController>/6
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var produto = await _repository.GetProdutoById(id);
                if (produto != null)
                {
                    _repository.Delete(produto);
                    if (await _repository.SaveChangeAsync())
                    {
                        return Ok();
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            return BadRequest("Não Deletado!");
        }
    }
}
