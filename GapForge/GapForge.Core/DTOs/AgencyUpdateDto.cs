using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.DTOs
{
    public class UpdateAgencyDto
    {
        public required string Name { get; set; }
        public string? LogoUrl { get; set; }
    }
}
