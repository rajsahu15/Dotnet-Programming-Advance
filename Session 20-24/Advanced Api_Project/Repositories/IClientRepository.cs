using ImprovedApiProject.Entities;

namespace ImprovedApiProject.Repositories
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClientsAsync();
        Task<Client> AddClientAsync(Client client);
    }
}