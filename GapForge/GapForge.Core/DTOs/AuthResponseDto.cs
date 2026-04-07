using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int AgencyId { get; set; }
    }
}
