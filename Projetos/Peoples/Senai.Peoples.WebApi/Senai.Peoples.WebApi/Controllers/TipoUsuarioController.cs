using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            tipoUsuarioRepository = new TipoUsuarioRepository();
        }
        
        [HttpGet]
        public IEnumerable<TipoUsuarioDomain> Get()
        {
            return tipoUsuarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            TipoUsuarioDomain idBuscado = tipoUsuarioRepository.GetById(id);

            if (idBuscado == null)
            {
                return NotFound("Tipo não encontrado");
            }
            return Ok(idBuscado);                
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,TipoUsuarioDomain tipoUsuario)
        {
            TipoUsuarioDomain tipoAtualizado = tipoUsuarioRepository.GetById(id);

            try
            {
                tipoUsuarioRepository.Atualizar(id, tipoUsuario);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            tipoUsuarioRepository.Deletar(id);

            return Ok();
        }
    }
}