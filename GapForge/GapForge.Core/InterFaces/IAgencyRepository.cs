using GapForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface IAgencyRepository
    {
        Task<Agency?> GetByIdAsync(int id);
        Task<Agency?> GetByUserIdAsync(string userId);
        Task<Agency> CreateAsync(Agency agency);
        Task<Agency> UpdateAsync(Agency agency);
        Task DeleteAsync(int id);
    }
}
