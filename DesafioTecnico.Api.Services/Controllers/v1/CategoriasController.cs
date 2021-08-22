using System.Threading.Tasks;
using DesafioTecnico.Application.Services.Interface;
using DesafioTecnico.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Api.Services.Controllers.v1
{
    [Produces("application/json")]
    [Route("v1/categorias")]
	public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaAppService;

        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<IActionResult> GetById(int grupoEmpresaId, int id)
        {
            var categoria = await _categoriaAppService.ObterPorIdAsync(id);
            return Ok(categoria);
        }


        [HttpGet(Name = "GetCategoriaAll")]
        public async Task<IActionResult> GetCategoriaAll()
        {
            var resultado = await _categoriaAppService.ObterTodosAsync();
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriaCreateEditViewModel entidade)
        {
            if (entidade.Nome == null)
                return BadRequest("O nome deve ser informado");

            var categoria = await _categoriaAppService.InserirAsync(entidade);

            return CreatedAtAction("GetById", new { Id = categoria.Id }, categoria); ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CategoriaCreateEditViewModel categoria)
        {
            var result = await _categoriaAppService.AlterarAsync(id, categoria);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriaAppService.ExcluirAsync(id);
            return Ok();
        }
    }
}