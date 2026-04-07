using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GapForge.Core.Models
{
    public class KeywordGap
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Keyword { get; set; }
        public int SearchVolume { get; set; }
        public int Difficulty { get; set; }
        public int CompetitorRanking { get; set; }
        public DateTime CreatedAt { get; set; }
        public Client Client { get; set; }
    }
}
