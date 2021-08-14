using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Requests;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<FilesController> _logger;
        private readonly IConstituencyService _constituencyService;
        private readonly ICandidateService _candidateService;
        private readonly IResultService _resultService;

        public FilesController(AppDbContext context, ILogger<FilesController> logger, IConstituencyService constituencyService, ICandidateService candidateService, IResultService resultService)
        {
            _context = context;
            _logger = logger;
            _constituencyService = constituencyService;
            _candidateService = candidateService;
            _resultService = resultService;
        }

        [HttpPost]
        public void Upload(IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);
            if (System.IO.File.Exists(path))
            {
                string baseName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                path = Path.Combine(Directory.GetCurrentDirectory(), "Files", baseName + "_override" + extension);
            }
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            List<Result> results = new List<Result>();
            List<string> lines = System.IO.File.ReadAllLines(path).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                var candidates = _candidateService.GetAll();  // Svi kandidati

                if (entries.Length < 3 || entries[2] == "")
                {
                    _logger.LogWarning("Format mora biti u nizu: izborna jedinica, udio, kandidat");
                    continue;
                }
                else
                {
                    if (Int32.TryParse(entries[0], out int j))     // Ukoliko se na prvom mjestu nalazi broj odnosno glasovi onda grešku evidentiramo u log
                    {
                        _logger.LogWarning("Format mora biti u nizu: izborna jedinica, udio, kandidat");
                        continue;
                    }

                    bool found = false;
                    foreach (var candidate in candidates)
                    {
                        if (candidate.Code == entries[0])
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)            // Ukoliko se na prvom mjestu nalazi kandidat onda grešku evidentiramo u log
                    {
                        _logger.LogWarning("Format mora biti u nizu: izborna jedinica, udio, kandidat");  
                        continue;
                    }
                }

                int constituencyId = 0;
                var constituency = _constituencyService.GetByName(entries[0]);
                if (constituency == null)
                {
                    ConstituencyInsertRequest request = new ConstituencyInsertRequest
                    {
                        Name = entries[0]
                    };
                    var newConstituency = _constituencyService.Insert(request);
                    constituencyId = newConstituency.Id;
                }
                else
                {
                    constituencyId = constituency.Id;
                }


                ResultSearchRequest requst = new ResultSearchRequest();
                int temp = 0;
                int candidateId = 0;
                int votes = 0;
                for (int i = 1; i < entries.Length; i++)
                {
                    if (entries[i] == "")
                        break;

                    if (i % 2 == 0)
                    {
                        if (Int32.TryParse(entries[i], out int j))
                        {
                            _logger.LogWarning("Format mora biti u nizu: izborna jedinica, udio, kandidat");
                            break;
                        }
                        var candidate = _candidateService.GetByCode(entries[i]);
                        if (candidate != null)               // ovdje osiguravamo da se glasovi dodaju za kandidata iz predefinisane liste
                            candidateId = candidate.Id;       // ,a ne za nekog novog kandidata ili neku drugu vrijednost
                        else
                        {
                            // log sa informacijama o greski
                            _logger.LogWarning("Unos za nepostojećeg kandidata");
                            break;
                        }

                    }
                    else
                    {
                        if (Int32.TryParse(entries[i], out int j))
                        {
                            votes = j;
                        }
                        else                                        // Ukoliko se na drugom mjestu ne nalazi broj odnosno glasovi grešku evidentiramo u log
                        {
                            // log sa informacijama o greski
                            _logger.LogWarning("Format mora biti u nizu: izborna jedinica, udio, kandidat");
                            break;
                        }

                    }
                    temp++;
                    if (temp % 2 == 0)
                    {
                        requst.ConstituencyId = constituencyId;
                        requst.CandidateId = candidateId;
                        var result = _resultService.GetAll(requst);              // Svi rezultati

                        if (result.Count > 0)
                        {
                            // uraditi update
                            ResultUpdateRequest updateRequest = new ResultUpdateRequest
                            {                                                          
                                Votes = votes,                
                                ConstituencyId = constituencyId,             // Ukoliko rezultati za određenu izbornu jedinicu i kandidata već postoje
                                CandidateId = candidateId                   // onda uradimo update tih postojećih rezultata
                            };

                            var updatedResult = _resultService.Update(result[0].Id, updateRequest);
                        }
                        else
                        {
                            // uraditi insert 
                            ResultInsertRequest insertRequest = new ResultInsertRequest
                            {
                                ConstituencyId = constituencyId,
                                Votes = votes,                                          // Dodavanje rezultata
                                CandidateId = candidateId
                            };
                            var newResult = _resultService.Insert(insertRequest);
                        }
                    }
                }
            }
            return;
        }
    }
}
