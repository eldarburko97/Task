using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext _context;
        public CandidateService(AppDbContext context)
        {
            _context = context;
        }
        public List<Candidate> GetAll()
        {
            return _context.candidates.ToList();
        }

        public Candidate GetByCode(string code)
        {
            var entity = _context.candidates.FirstOrDefault(f => f.Code == code);
            return entity;
        }

        public Candidate GetCandidate(int id)
        {
            var entity = _context.candidates.Find(id);
            if (entity == null)
            {
                return null;
            }
            return entity;
        }       
    }
}
