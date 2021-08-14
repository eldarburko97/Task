using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Services
{
    public class ConstituencyService : IConstituencyService
    {
        private readonly AppDbContext _context;
        public ConstituencyService(AppDbContext context)
        {
            _context = context;
        }

        public List<Constituency> GetAll()
        {
            return _context.constituencies.Include(i => i.Results).ThenInclude(t => t.Candidate).ToList();
        }

        public Constituency GetByName(string name)
        {
            var entity = _context.constituencies.FirstOrDefault(f => f.Name == name);
            return entity;
        }

        public Constituency Insert(ConstituencyInsertRequest request)
        {
            Constituency newConstituency = new Constituency { Name = request.Name };
            _context.constituencies.Add(newConstituency);
            _context.SaveChanges();
            return newConstituency;
        }
    }
}
