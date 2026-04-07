using Microsoft.AspNetCore.Identity;

namespace GapForge.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public int? AgencyId { get; set; }
        public Agency Agency { get; set; }
    }

}
