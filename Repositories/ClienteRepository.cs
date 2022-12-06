using ApiProject.Data;
using ApiProject.Models;
using ApiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiProject.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProjectApiDb _dbContext;
        public ClienteRepository(ProjectApiDb sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public async Task<ClienteModel> BuscarPorId(int id)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<ClienteModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
        public async Task<ClienteModel> Adicionar(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task<ClienteModel> Atualizar(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if(clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no banco de dados.");
            }

            clientePorId.Nome = cliente.Nome;
            clientePorId.Email = cliente.Email;
            clientePorId.DDD = cliente.DDD;
            clientePorId.Telefone = cliente.Telefone;
            clientePorId.cpf = cliente.cpf;
            clientePorId.rg = cliente.rg;
            clientePorId.cep = cliente.cep;
            clientePorId.Logradouro = cliente.Logradouro;
            clientePorId.Numero = cliente.Numero;
            clientePorId.Bairro = cliente.Bairro;
            clientePorId.Complemento = cliente.Complemento;
            clientePorId.Cidade = cliente.Cidade;
            clientePorId.Estado = cliente.Estado;
            clientePorId.Referencia = cliente.Referencia;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ClienteModel clientePorId = await BuscarPorId(id);

            if (clientePorId == null)
            {
                throw new Exception($"Cliente para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Clientes.Remove(clientePorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }
       
    }
}
