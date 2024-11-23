using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;


namespace SustenAI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SustenAIDBContext _dbContext;

        public UsuarioRepository(SustenAIDBContext sustenAIContext)  
        {
            _dbContext = sustenAIContext;
        }

        // Buscar usuário por ID
        public async Task<Usuario> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.IdUser == id);
        }

        public async Task<List<Usuario>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;  
            usuarioPorId.Email = usuario.Email;
            usuarioPorId.Senha = usuario.Senha;
            usuarioPorId.Telefone = usuario.Telefone;
            usuarioPorId.DataCriacao = usuario.DataCriacao; 

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Usuario usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
