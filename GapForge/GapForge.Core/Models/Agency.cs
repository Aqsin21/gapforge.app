using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? LogoUrl { get; set; }
        public string PlanType { get; set; } 
        public DateTime CreatedAt { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}
