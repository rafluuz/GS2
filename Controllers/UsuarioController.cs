using Microsoft.AspNetCore.Mvc;
using SustenAI.Models;
using SustenAI.Repository;

namespace SustenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        // Injeta o repositório através da interface
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Endpoint para buscar todos os usuários
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        // Endpoint para buscar um usuário pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepository.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(usuario);
        }

        // Endpoint para cadastrar um novo usuário
        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = await _usuarioRepository.Adicionar(usuarioModel);
            return CreatedAtAction(nameof(BuscarPorId), new { id = usuario.IdUser }, usuario);
        }

        // Endpoint para atualizar um usuário existente
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar([FromBody] Usuario usuarioModel, int id)
        {
            try
            {
                Usuario usuario = await _usuarioRepository.Atualizar(usuarioModel, id);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Endpoint para apagar um usuário
        [HttpDelete("{id}")]
        public async Task<ActionResult> Apagar(int id)
        {
            try
            {
                bool apagado = await _usuarioRepository.Apagar(id);
                return Ok(new { sucesso = apagado, mensagem = "Usuário apagado com sucesso!" });
            }
            catch (Exception ex)
            {
                return NotFound(new { sucesso = false, mensagem = ex.Message });
            }
        }
    }
}