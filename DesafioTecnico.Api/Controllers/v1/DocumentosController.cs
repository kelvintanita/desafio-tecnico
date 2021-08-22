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
    [Route("v1/documentos")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly IDocumentoAppService _documentoAppService;

        public DocumentosController(IDocumentoAppService documentoAppService)
        {
            _documentoAppService = documentoAppService;
        }

        [HttpGet("{id:int}", Name = "GetDocumentoById")]
        public async Task<IActionResult> GetById(int id)
        {
            var documento = await _documentoAppService.ObterPorIdAsync(id);
            return Ok(documento);
        }


        [HttpGet(Name = "GetDocumentoAll")]
        public async Task<IActionResult> GetDocumentoAll()
        {
            var resultado = await _documentoAppService.ObterListaOrdenadaAsync();
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DocumentoCreateViewModel entidade)
        {
            var documento = await _documentoAppService.InserirAsync(entidade);

            return CreatedAtAction("GetById", new { Id = documento.Id }, documento); ;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DocumentoEditViewModel documento)
        {
            var result = await _documentoAppService.AlterarAsync(id, documento);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _documentoAppService.ExcluirAsync(id);
            return Ok();
        }
    }
}