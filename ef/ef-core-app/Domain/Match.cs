using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Match: BaseEntity
    {
        public int HomeTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public int AwayTeamScore { get; set; }
        public Team AwayTeam { get; set; }
        
        public decimal TicketPrice { get; set; }
    }
}
