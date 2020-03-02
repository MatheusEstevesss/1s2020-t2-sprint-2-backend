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
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository usuariosRepository { get; set; }

        public UsuariosController()
        {
            usuariosRepository = new UsuariosRepository();
        }

        [HttpGet]
        public IEnumerable<UsuarioDomain> Listar()
        {
            return usuariosRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post (UsuarioDomain usuarios)
        {
            if (usuarios.Email != null)
            {
                if(usuarios.Senha != null)
                {
                    if(usuarios.IdTipoUsuario.ToString() != null)
                    {
                        usuariosRepository.Cadastrar(usuarios);
                        return StatusCode(201);
                    }
                }
            }
            return BadRequest("Digite todos os dados necessários");
        }

        [HttpGet("{id}")]
        public IActionResult GetById (int id)
        {
            UsuarioDomain usuarioBuscado = usuariosRepository.GetById(id);

            if(usuarioBuscado == null)
            {
                return NotFound("Usuario não encontrado");
            }
            return Ok(usuarioBuscado);
        }
    }
}