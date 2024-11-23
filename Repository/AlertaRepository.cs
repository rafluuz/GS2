using Microsoft.EntityFrameworkCore;
using SustenAI.API.Repository;
using SustenAI.DataBase;
using SustenAI.Models;

namespace SustenAI.Repository
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly SustenAIDBContext _dbContext;

        public AlertaRepository(SustenAIDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Buscar todos os alertas
        public async Task<List<Alerta>> BuscarTodosAlertas()
        {
            return await _dbContext.Alertas.ToListAsync();
        }

        // Buscar alerta por ID
        public async Task<Alerta> BuscarPorId(int id)
        {
            return await _dbContext.Alertas.FirstOrDefaultAsync(x => x.IdAlerta == id);
        }

        // Adicionar um novo alerta
        public async Task<Alerta> Adicionar(Alerta alerta)
        {
            await _dbContext.Alertas.AddAsync(alerta);
            await _dbContext.SaveChangesAsync();
            return alerta;
        }

        // Atualizar as informações de um alerta
        public async Task<Alerta> Atualizar(Alerta alerta, int id)
        {
            Alerta alertaExistente = await BuscarPorId(id);

            if (alertaExistente == null)
            {
                throw new Exception($"Alerta com ID {id} não encontrado.");
            }

            // Atualizando os dados do alerta
            alertaExistente.TipoAlerta = alerta.TipoAlerta;
            alertaExistente.Mensagem = alerta.Mensagem;
            alertaExistente.StatusAlerta = alerta.StatusAlerta;
            alertaExistente.DataCriacao = alerta.DataCriacao;

            _dbContext.Alertas.Update(alertaExistente);
            await _dbContext.SaveChangesAsync();

            return alertaExistente;
        }

        // Apagar um alerta
        public async Task<bool> Apagar(int id)
        {
            Alerta alertaExistente = await BuscarPorId(id);

            if (alertaExistente == null)
            {
                throw new Exception($"Alerta com ID {id} não encontrado.");
            }

            _dbContext.Alertas.Remove(alertaExistente);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}