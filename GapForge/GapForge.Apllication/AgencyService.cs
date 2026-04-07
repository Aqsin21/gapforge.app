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
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;

        public AgencyService(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }

        public async Task<AgencyDto?> GetProfileAsync(string userId)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) return null;

            return MapToDto(agency);
        }

        public async Task<AgencyDto> UpdateAgencyAsync(string userId, UpdateAgencyDto dto)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) throw new Exception("Agency not found");

            agency.Name = dto.Name;
            agency.LogoUrl = dto.LogoUrl;

            var updated = await _agencyRepository.UpdateAsync(agency);
            return MapToDto(updated);
        }

        public async Task<AgencyDto> UpgradePlanAsync(string userId, string planType)
        {
            var agency = await _agencyRepository.GetByUserIdAsync(userId);
            if (agency == null) throw new Exception("Agency not found");

            agency.PlanType = planType;

            var updated = await _agencyRepository.UpdateAsync(agency);
            return MapToDto(updated);
        }

        private AgencyDto MapToDto(Agency agency) => new AgencyDto
        {
            Id = agency.Id,
            Name = agency.Name,
            LogoUrl = agency.LogoUrl,
            PlanType = agency.PlanType,
            CreatedAt = agency.CreatedAt
        };
    }
}
