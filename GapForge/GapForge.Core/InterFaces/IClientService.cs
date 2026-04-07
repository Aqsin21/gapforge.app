using GapForge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllClientsAsync(string userId);
        Task<ClientDto?> GetClientByIdAsync(int clientId, string userId);
        Task<ClientDto> CreateClientAsync(string userId, CreateClientDto dto);
        Task<ClientDto> UpdateClientAsync(int clientId, string userId, CreateClientDto dto);
        Task DeleteClientAsync(int clientId, string userId);
    }
}
