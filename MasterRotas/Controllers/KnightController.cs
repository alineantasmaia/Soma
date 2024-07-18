using Master.Rotas.Dominio.Dto;
using Master.Rotas.Dominio.Interface.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace MasterRotas.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class knightController : Controller
    {
        private readonly IServicoKnight _servicoKnight;

        public knightController(IServicoKnight ServicoKnight)
        {
            _servicoKnight = ServicoKnight;
        }

        [HttpGet("/Knights")]
        public IActionResult Knights()
        {
            try
            {
                return Ok(_servicoKnight.Obter(""));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/Knights/filter=heroes")]
        public IActionResult KnightsHeroes()
        {
            try
            {
                return Ok(_servicoKnight.Obter(""));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("/Knights")]
        public IActionResult Knights(KnightDto knight)
        {
            try
            {
                _servicoKnight.Incluir(knight);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("/Knights/:id")]
        public IActionResult Knights(string id)
        {
            try
            {
                return Ok(_servicoKnight.Obter(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/Knights/:id")]
        public IActionResult ExcluirCadastroRota(string id)
        {
            try
            {
                _servicoKnight.Excluir(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("/Knights/:id")]
        public IActionResult Atualizar(KnightDto knight)
        {
            try
            {
                _servicoKnight.Atualizar(knight);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}