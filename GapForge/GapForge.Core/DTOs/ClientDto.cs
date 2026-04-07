using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public int AgencyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
