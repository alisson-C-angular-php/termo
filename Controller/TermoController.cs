using entity.Model;
using entity.Repository;
using Microsoft.AspNetCore.Mvc;

namespace entity.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TermoController : ControllerBase
    {
        private readonly TermoRepository termoRepository;

        public TermoController(TermoRepository termo)
        {
            termoRepository = termo;
        }

        [HttpPost("inserirTermo")]
        public IActionResult InsertTermo([FromBody] Termo termo)
        {
            try
            {
                termoRepository.insertTermo(termo);
                return Ok(new
                {
                    status = 200,
                    message = "Termo criado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }

        [HttpPost("inserirTermoItem")]
        public IActionResult InsertTermoItem([FromBody] CadTermoItem item)
        {
            try
            {
                termoRepository.insertTermoItem(item);
                return Ok(new
                {
                    status = 200,
                    message = "Item do termo inserido com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }

       
        [HttpPost("inserirHistorico")]
        public IActionResult InsertHistorico([FromBody] CadTermoItemAceiteUsuarioHistorico historico)
        {
            try
            {
                termoRepository.insertHistorico(historico);
                return Ok(new
                {
                    status = 200,
                    message = "Histórico de aceite inserido com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }

        [HttpPost("inserirAceite")]
        public IActionResult InsertAceite([FromBody] CadTermoItemAceite aceite)
        {
            try
            {
                termoRepository.insertAceite(aceite);
                return Ok(new
                {
                    status = 200,
                    message = "Aceite registrado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }

        [HttpGet("listaTermos")]
        public IActionResult GetTermo()
        {
            try
            {
                var termos = termoRepository.getTermo();
                return Ok(new
                {
                    status = 200,
                    data = termos,
                    message = "Termos registrados"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }





        [HttpPut("atualizarTermo")]
        public IActionResult UpdateTermo([FromBody] Termo termo)
        {
            try
            {
                termoRepository.updateTermo(termo);
                return Ok(new
                {
                    status = 200,
                    message = "Termo atualizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }

        [HttpPut("atualizarTermoItem")]
        public IActionResult UpdateTermoItem([FromBody] CadTermoItem item)
        {
            try
            {
                termoRepository.updateTermoItem(item);
                return Ok(new
                {
                    status = 200,
                    message = "Item do termo atualizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }


        [HttpGet("termoStatusUsuario/{usuario_codigo}")]
        public IActionResult GetTermoStatusByUser(int usuario_codigo)
        {
            try
            {
                var status = termoRepository.getTermoStatusByUser(usuario_codigo);
                return Ok(new
                {
                    status = 200,
                    data = status,
                    message = "Status de aceite do usuário recuperado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = 500,
                    error = ex.Message
                });
            }
        }
    }
}
