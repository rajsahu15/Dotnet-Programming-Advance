using ImprovedApiProject.DTOs;

namespace ImprovedApiProject.Services
{
    public interface IClientService
    {
        Task<List<ClientDTO>> GetClientsAsync();
        Task<ClientDTO> AddClientAsync(ClientDTO dto);
    }
}