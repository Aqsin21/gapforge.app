using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.Models
{
    public class Competitor
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Domain { get; set; }
        public Client Client { get; set; }
    }
}
