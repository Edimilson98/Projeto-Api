using ApiProject.Models;

namespace ApiProject.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        Task<List<ClienteModel>> BuscarTodosClientes();
        Task<ClienteModel> BuscarPorId(int id);
        Task<ClienteModel> Adicionar(ClienteModel cliente);
        Task<ClienteModel> Atualizar(ClienteModel cliente, int id);
        Task<bool> Apagar(int id);
    }
}
