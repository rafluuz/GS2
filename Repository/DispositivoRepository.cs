using Microsoft.EntityFrameworkCore;
using SustenAI.DataBase;
using SustenAI.Models;

namespace SustenAI.Repository
{
    public class DispositivoRepository : IDispositivoRepository
    {
        private readonly SustenAIDBContext _dbContext;

        public DispositivoRepository(SustenAIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Buscar todos os dispositivos
        public async Task<List<Dispositivo>> BuscarTodosDispositivos()
        {
            return await _dbContext.Dispositivos.ToListAsync();
        }

        // Buscar dispositivo por ID
        public async Task<Dispositivo> BuscarPorId(int id)
        {
            return await _dbContext.Dispositivos.FirstOrDefaultAsync(x => x.IdDispo == id);
        }

        // Adicionar um novo dispositivo
        public async Task<Dispositivo> Adicionar(Dispositivo dispositivo)
        {
            await _dbContext.Dispositivos.AddAsync(dispositivo);
            await _dbContext.SaveChangesAsync();
            return dispositivo;
        }

        // Atualizar as informações de um dispositivo
        public async Task<Dispositivo> Atualizar(Dispositivo dispositivo, int id)
        {
            Dispositivo dispositivoExistente = await BuscarPorId(id);

            if (dispositivoExistente == null)
            {
                throw new Exception($"Dispositivo com ID {id} não encontrado.");
            }

            // Atualizando os dados do dispositivo
            dispositivoExistente.NomeDispo = dispositivo.NomeDispo;
            dispositivoExistente.TipoDispo = dispositivo.TipoDispo;
            dispositivoExistente.DataInstalacao = dispositivo.DataInstalacao;

            _dbContext.Dispositivos.Update(dispositivoExistente);
            await _dbContext.SaveChangesAsync();

            return dispositivoExistente;
        }

        // Apagar um dispositivo
        public async Task<bool> Apagar(int id)
        {
            Dispositivo dispositivoExistente = await BuscarPorId(id);

            if (dispositivoExistente == null)
            {
                throw new Exception($"Dispositivo com ID {id} não encontrado.");
            }

            _dbContext.Dispositivos.Remove(dispositivoExistente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}