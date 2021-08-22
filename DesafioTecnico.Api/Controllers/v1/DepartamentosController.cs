using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioTecnico.Application.Services.Interface;
using DesafioTecnico.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Api.Controllers.v1
{
    [Produces("application/json")]
    [Route("v1/departamentos")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentoAppService _departamentoAppService;

        public DepartamentosController(IDepartamentoAppService departamentoAppService)
        {
            _departamentoAppService = departamentoAppService;
        }

        [HttpGet(Name = "GetDepartamentoAll")]
        public async Task<IActionResult> GetCategoriaAll()
        {
            var resultado = await _departamentoAppService.ObterTodosAsync();
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartamentoCreateEditViewModel entidade)
        {
            var categoria = await _departamentoAppService.InserirAsync(entidade);

            return CreatedAtAction("GetById", new { Id = categoria.Id }, categoria); ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DepartamentoCreateEditViewModel departamento)
        {
            var result = await _departamentoAppService.AlterarAsync(id, departamento);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _departamentoAppService.ExcluirAsync(id);
            return Ok();
        }
    }
}