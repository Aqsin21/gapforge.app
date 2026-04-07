using GapForge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface IAgencyService
    {
        Task<AgencyDto?> GetProfileAsync(string userId);
        Task<AgencyDto> UpdateAgencyAsync(string userId, UpdateAgencyDto dto);
        Task<AgencyDto> UpgradePlanAsync(string userId, string planType);
    }
}
