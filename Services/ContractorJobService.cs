using System;
using System.Collections.Generic;
using csContractorJob.Models;
using csContractorJob.Repositories;

namespace csContractorJob.Services
{
  public class ContractorJobService
  {

    private readonly ContractorJobRepository _repo;

    public ContractorJobService(ContractorJobRepository repo)
    {
      _repo = repo;
    }

    internal ContractorJob Create(ContractorJob newContractorJob)
    {
      newContractorJob.Id = _repo.Create(newContractorJob);
      return newContractorJob;
    }

    internal IEnumerable<ContractorJob> Get()
    {
      return _repo.Get();
    }

    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      return "Unable to be deleted";
    }

    internal IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
      return _repo.GetContractorsByJobId(jobId);
    }
  }
}