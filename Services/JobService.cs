using System;
using System.Collections.Generic;
using csContractorJob.Models;
using csContractorJob.Repositories;

namespace csContractorJob.Services
{
  public class JobService
  {

    private readonly JobRepository _repo;

    public JobService(JobRepository repo)
    {
      _repo = repo;
    }

    internal Job Create(Job newJob)
    {
      newJob.Id = _repo.Create(newJob);
      return newJob;
    }

    internal IEnumerable<Job> Get()
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
  }
}