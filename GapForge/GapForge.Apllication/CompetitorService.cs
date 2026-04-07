using GapForge.Core.DTOs;
using GapForge.Core.InterFaces;
using GapForge.Core.Models;
namespace GapForge.Apllication
{
    public class CompetitorService : ICompetitorService
    {
        private readonly ICompetitorRepository _competitorRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IAgencyRepository _agencyRepository;

        public CompetitorService(
            ICompetitorRepository competitorRepository,
            IClientRepository clientRepository,
            IAgencyRepository agencyRepository)
        {
            _competitorRepository = competitorRepository;
            _clientRepository = clientRepository;
            _agencyRepository = agencyRepository;
        }

        public async Task<List<CompetitorDto>> GetAllAsync(int clientId, string userId)
        {
            var client = await ValidateClientOwnership(clientId, userId);
            var competitors = await _competitorRepository
                .GetAllByClientIdAsync(clientId);
            return competitors.Select(MapToDto).ToList();
        }

        public async Task<CompetitorDto> CreateAsync(
            int clientId, string userId, CreateCompetitorDto dto)
        {
            await ValidateClientOwnership(clientId, userId);

            var competitor = new Competitor
            {
                Domain = dto.Domain,
                ClientId = clientId
            };

            var created = await _competitorRepository.CreateAsync(competitor);
            return MapToDto(created);
        }

        public async Task DeleteAsync(int competitorId, string userId)
        {
            var competitor = await _competitorRepository.GetByIdAsync(competitorId);
            if (competitor == null) throw new Exception("Competitor not found");

            await ValidateClientOwnership(competitor.ClientId, userId);
            await _competitorRepository.DeleteAsync(competitorId);
        }

        // 👇 makes sure client belongs to the logged in agency
        private async Task<Client> ValidateClientOwnership(int clientId, string userId)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) throw new Exception("Agency not found");

            var client = await _clientRepository.GetByIdAsync(clientId);
            if (client == null) throw new Exception("Client not found");

            if (client.AgencyId != agency.Id)
                throw new UnauthorizedAccessException("Access denied");

            return client;
        }

        private CompetitorDto MapToDto(Competitor c) => new CompetitorDto
        {
            Id = c.Id,
            Domain = c.Domain,
            ClientId = c.ClientId
        };
    }
}
