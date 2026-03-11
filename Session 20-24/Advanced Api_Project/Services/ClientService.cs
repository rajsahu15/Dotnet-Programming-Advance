using ImprovedApiProject.DTOs;
using ImprovedApiProject.Entities;
using ImprovedApiProject.Repositories;

namespace ImprovedApiProject.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ClientDTO>> GetClientsAsync()
        {
            var clients = await _repo.GetClientsAsync();
            return clients.Select(c => new ClientDTO
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }

        public async Task<ClientDTO> AddClientAsync(ClientDTO dto)
        {
            var client = new Client
            {
                Name = dto.Name,
                Email = dto.Email
            };

            var result = await _repo.AddClientAsync(client);

            return new ClientDTO
            {
                Name = result.Name,
                Email = result.Email
            };
        }
    }
}