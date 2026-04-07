using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapForge.Core.Models
{
    public class Client
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public DateTime CreatedAt { get; set; }
        public Agency Agency { get; set; }
        public ICollection<Competitor> Competitors { get; set; }
        public ICollection<KeywordGap> KeywordGaps { get; set; }
    }
}
