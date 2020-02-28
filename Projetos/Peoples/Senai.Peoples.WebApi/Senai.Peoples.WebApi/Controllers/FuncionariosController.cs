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
{ [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
   
    public class FuncionariosController : ControllerBase
    {
        private IFuncionariosRepository funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            funcionarioRepository = new FuncionariosRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionariosDomain> Get()
        {
            return funcionarioRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(FuncionariosDomain funcionariosRecebido)
        {
            if (funcionariosRecebido.Nome != null)
            {
                funcionarioRepository.Cadastrar(funcionariosRecebido);
                return StatusCode(201);
            }
            return BadRequest("Por Favor digite seu nome");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionariosDomain funcionarioBuscado = funcionarioRepository.GetById(id);

            if(funcionarioBuscado == null)
            {
                return NotFound("Funcionário não Encontrado");
            }
            return Ok(funcionarioBuscado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            funcionarioRepository.Deletar(id);

            return Ok("Genero Deletado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, FuncionariosDomain funcionarioAtualizado)
        {
            FuncionariosDomain funcionarioBuscado = funcionarioRepository.GetById(id);

            try
            {
                funcionarioRepository.Atualizar(id, funcionarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception e) 
            {
                return BadRequest(e);
            }
        }
    }
}