using GapForge.Core.DTOs;
using GapForge.Core.InterFaces;
using GapForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Apllication
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IAgencyRepository _agencyRepository;

        public ClientService(
            IClientRepository clientRepository,
            IAgencyRepository agencyRepository)
        {
            _clientRepository = clientRepository;
            _agencyRepository = agencyRepository;
        }

        public async Task<List<ClientDto>> GetAllClientsAsync(string userId)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) return new List<ClientDto>();

            var clients = await _clientRepository.GetAllByAgencyIdAsync(agency.Id);
            return clients.Select(MapToDto).ToList();
        }

        public async Task<ClientDto?> GetClientByIdAsync(int clientId, string userId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null) return null;

            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null || client.AgencyId != agency.Id) return null;

            return MapToDto(client);
        }

        public async Task<ClientDto> CreateClientAsync(string userId, CreateClientDto dto)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) throw new Exception("Agency not found");

            var client = new Client
            {
                Name = dto.Name,
                Domain = dto.Domain,
                AgencyId = agency.Id,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _clientRepository.CreateAsync(client);
            return MapToDto(created);
        }

        public async Task<ClientDto> UpdateClientAsync(int clientId, string userId, CreateClientDto dto)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null) throw new Exception("Client not found");

            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null || client.AgencyId != agency.Id)
                throw new Exception("Unauthorized");

            client.Name = dto.Name;
            client.Domain = dto.Domain;

            var updated = await _clientRepository.UpdateAsync(client);
            return MapToDto(updated);
        }

        public async Task DeleteClientAsync(int clientId, string userId)
        {
            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null) throw new Exception("Client not found");

            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null || client.AgencyId != agency.Id)
                throw new Exception("Unauthorized");

            await _clientRepository.DeleteAsync(clientId);
        }

        private ClientDto MapToDto(Client client) => new ClientDto
        {
            Id = client.Id,
            Name = client.Name,
            Domain = client.Domain,
            AgencyId = client.AgencyId,
            CreatedAt = client.CreatedAt
        };
    }
}
