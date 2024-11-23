using Microsoft.AspNetCore.Mvc;
using SustenAI.API.Repository;
using SustenAI.Models;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaRepository _alertaRepository;

        public AlertaController(IAlertaRepository alertaRepository)
        {
            _alertaRepository = alertaRepository;
        }

        // Endpoint para buscar todos os alertas
        [HttpGet]
        public async Task<ActionResult<List<Alerta>>> BuscarTodosAlertas()
        {
            List<Alerta> alertas = await _alertaRepository.BuscarTodosAlertas();
            return Ok(alertas);
        }

        // Endpoint para buscar um alerta por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> BuscarPorId(int id)
        {
            Alerta alerta = await _alertaRepository.BuscarPorId(id);
            if (alerta == null)
            {
                return NotFound($"Alerta com ID {id} não foi encontrado.");
            }
            return Ok(alerta);
        }

        // Endpoint para cadastrar um novo alerta
        [HttpPost]
        public async Task<ActionResult<Alerta>> Cadastrar([FromBody] Alerta alertaModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Alerta alerta = await _alertaRepository.Adicionar(alertaModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = alerta.IdAlerta }, alerta);
        }

        // Endpoint para atualizar um alerta existente
        [HttpPut("{id}")]
        public async Task<ActionResult<Alerta>> Atualizar([FromBody] Alerta alertaModel, int id)
        {
            try
            {
                Alerta alertaAtualizado = await _alertaRepository.Atualizar(alertaModel, id);
                return Ok(alertaAtualizado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Endpoint para apagar um alerta
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _alertaRepository.Apagar(id);
                return Ok(new { sucesso = apagado, mensagem = "Alerta apagado com sucesso!" });
            }
            catch (Exception ex)
            {
                return NotFound(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}