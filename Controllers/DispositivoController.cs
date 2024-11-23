using Microsoft.AspNetCore.Mvc;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        private readonly IDispositivoRepository _dispositivoRepository;

        public DispositivoController(IDispositivoRepository dispositivoRepository)
        {
            _dispositivoRepository = dispositivoRepository;
        }

        // Endpoint para buscar todos os dispositivos
        [HttpGet]
        public async Task<ActionResult<List<Dispositivo>>> BuscarTodosDispositivos()
        {
            List<Dispositivo> dispositivos = await _dispositivoRepository.BuscarTodosDispositivos();
            return Ok(dispositivos);
        }

        // Endpoint para buscar um dispositivo por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispositivo>> BuscarPorId(int id)
        {
            Dispositivo dispositivo = await _dispositivoRepository.BuscarPorId(id);
            if (dispositivo == null)
            {
                return NotFound($"Dispositivo com ID {id} não encontrado.");
            }
            return Ok(dispositivo);
        }

        // Endpoint para cadastrar um novo dispositivo
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> Cadastrar([FromBody] Dispositivo dispositivoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dispositivo dispositivo = await _dispositivoRepository.Adicionar(dispositivoModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = dispositivo.IdDispo }, dispositivo);
        }

        // Endpoint para atualizar um dispositivo existente
        [HttpPut("{id}")]
        public async Task<ActionResult<Dispositivo>> Atualizar([FromBody] Dispositivo dispositivoModel, int id)
        {
            try
            {
                Dispositivo dispositivoAtualizado = await _dispositivoRepository.Atualizar(dispositivoModel, id);
                return Ok(dispositivoAtualizado);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Endpoint para apagar um dispositivo
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _dispositivoRepository.Apagar(id);
                return Ok(new { sucesso = apagado, mensagem = "Dispositivo apagado com sucesso!" });
            }
            catch (Exception ex)
            {
                return NotFound(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}