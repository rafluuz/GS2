using SustenAI.Models;

namespace SustenAI.API.Repository
{
    public interface IAlertaRepository
    {
        Task<List<Alerta>> BuscarTodosAlertas();
        Task<Alerta> BuscarPorId(int id);
        Task<Alerta> Adicionar(Alerta alerta);
        Task<Alerta> Atualizar(Alerta alerta, int id);
        Task<bool> Apagar(int id);
    }
}