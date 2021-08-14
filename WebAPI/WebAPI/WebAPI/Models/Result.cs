using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int Votes { get; set; }
        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int ConstituencyId { get; set; }
        public Constituency Constituency { get; set; }
    }
}
