using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.InLock.WebApi.DataBaseFirst.Domains;
using senai.InLock.WebApi.DataBaseFirst.Interfaces;
using senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository  estudioRepository;

        public EstudiosController()
        {
            estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(estudioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Retora a resposta da requisição fazendo a chamada para o método
            return Ok(estudioRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            // Faz a chamada para o método
            estudioRepository.Cadastrar(novoEstudio);

            // Retorna um status code
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            Estudio filmeBuscado = estudioRepository.BuscarPorId(id);

            // Verifica se o filme foi encontrado
            if (filmeBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                estudioRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O estudio {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum estudio encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            // Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
            Estudio filmeBuscado = estudioRepository.BuscarPorId(id);

            // Verifica se algum filme foi encontrado
            if (filmeBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    estudioRepository.Atualizar(id, estudioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Estudio não encontrado",
                        erro = true
                    }
                );
        }
    }
}