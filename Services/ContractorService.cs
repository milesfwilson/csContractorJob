using System;
using System.Collections.Generic;
using csContractorJob.Models;
using csContractorJob.Repositories;

namespace csContractorJob.Services
{
  public class ContractorService
  {

    private readonly ContractorRepository _repo;

    public ContractorService(ContractorRepository repo)
    {
      _repo = repo;
    }

    internal Contractor Create(Contractor newContractor)
    {
      newContractor.Id = _repo.Create(newContractor);
      return newContractor;
    }

    internal IEnumerable<Contractor> Get()
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

    internal Contractor GetOne(int id)
    {
      return _repo.GetOne(id);
    }
  }
}