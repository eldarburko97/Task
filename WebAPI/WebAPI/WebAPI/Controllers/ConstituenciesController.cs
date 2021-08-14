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
    public class ConstituenciesController : ControllerBase
    {
        private readonly IConstituencyService _service;
        public ConstituenciesController(IConstituencyService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Constituency> GetAll()
        {
            return _service.GetAll();
        }
    }
}
