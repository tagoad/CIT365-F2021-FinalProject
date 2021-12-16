using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SacramentPlanner.Models;

namespace SacramentPlanner.Models
{
    public class PopulatedMembers
    {
        public Member Conductor { get; set; }
        public Member OpeningPrayer { get; set; }
        public Member ClosingPrayer { get; set; }
        public List<Tuple<Member, string>> Speakers { get; set; }
    }
}
