using GapForge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.InterFaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetAllByAgencyIdAsync(int agencyId);
        Task<Client?> GetByIdAsync(int id);
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }
}
