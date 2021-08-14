using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _service;
        public CandidatesController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Candidate> GetAll()
        {
            return _service.GetAll();

            //var list = new List<Candidate>();
            //list.Add(new Candidate { Id = 1, Code = "DT", FirstName = "Donald", LastName = "Trump", });
            //return list;
        }

        [HttpGet("{id}")]
        public Candidate GetCandidate(int id)
        {
            return _service.GetCandidate(id);
        }
    }
}
