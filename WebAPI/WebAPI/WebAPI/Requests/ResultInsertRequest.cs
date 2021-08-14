using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Requests
{
    public class ResultInsertRequest
    {
        public int ConstituencyId { get; set; }
        public int Votes { get; set; }
        public int CandidateId { get; set; }
    }
}
