using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Services
{
    public class ResultService : IResultService
    {
        private readonly AppDbContext _context;
        public ResultService(AppDbContext context)
        {
            _context = context;
        }
        public List<Result> GetAll(ResultSearchRequest request)
        {
            var query = _context.results.Include(i => i.Constituency).Include(i => i.Candidate).AsQueryable();

            if (request != null && request.ConstituencyId != 0)
            {
                query = query.Where(w => w.ConstituencyId == request.ConstituencyId);
            }

            if (request != null && request.CandidateId != 0)
            {
                query = query.Where(w => w.CandidateId == request.CandidateId);
            }

            var list = query.ToList();
            return list;
        }

        public List<Result> GetResultsByConstituency(int constituencyId)
        {
            return _context.results.Where(w => w.ConstituencyId == constituencyId).ToList();
        }

        public Result Insert(ResultInsertRequest request)
        {
            Result result = new Result
            {
                ConstituencyId = request.ConstituencyId,
                Votes = request.Votes,
                CandidateId = request.CandidateId
            };

            _context.results.Add(result);
            _context.SaveChanges();

            return result;
        }

        public Result Update(int id, ResultUpdateRequest request)
        {
            var entity = _context.results.Find(id);

            entity.Votes = request.Votes;
            entity.ConstituencyId = request.ConstituencyId;
            entity.CandidateId = request.CandidateId;

            _context.results.Attach(entity);
            _context.results.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
