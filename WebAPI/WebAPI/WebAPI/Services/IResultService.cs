using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Services
{
    public interface IResultService
    {
        List<Result> GetAll(ResultSearchRequest request);
        List<Result> GetResultsByConstituency(int constituencyId);

        Result Insert(ResultInsertRequest request);

        Result Update(int id, ResultUpdateRequest request);
    }
}
