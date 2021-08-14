using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public interface ICandidateService
    {
        List<Candidate> GetAll();
        Candidate GetCandidate(int id);
        Candidate GetByCode(string code);
    }
}
