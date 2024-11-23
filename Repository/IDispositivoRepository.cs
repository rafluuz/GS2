using SustenAI.Models;

namespace SustenAI.Repository
{
    public interface IDispositivoRepository
    {
        Task<List<Dispositivo>> BuscarTodosDispositivos();
        Task<Dispositivo> BuscarPorId(int id);
        Task<Dispositivo> Adicionar(Dispositivo dispositivo);
        Task<Dispositivo> Atualizar(Dispositivo dispositivo, int id);
        Task<bool> Apagar(int id);
    }
}
