using GapForge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface ICompetitorService
    {
        Task<List<CompetitorDto>> GetAllAsync(int clientId, string userId);
        Task<CompetitorDto> CreateAsync(int clientId, string userId, CreateCompetitorDto dto);
        Task DeleteAsync(int competitorId, string userId);
    }
}
