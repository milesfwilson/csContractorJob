using System;
using System.Collections.Generic;
using System.Data;
using csContractorJob.Models;
using Dapper;

namespace csContractorJob.Repositories
{
  public class ContractorJobRepository
  {
    private readonly IDbConnection _db;

    public ContractorJobRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(ContractorJob newContractorJob)
    {
      string sql = @"INSERT INTO contractorjob
            (jobId, contractorId, creatorId)
            VALUES
            (@JobId, @ContractorId, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractorJob);
    }

    internal IEnumerable<ContractorJob> Get()
    {
      string sql = @"SELECT * FROM contractorjob";
      return _db.Query<ContractorJob>(sql);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM contractorjob WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal IEnumerable<Contractor> GetContractorsByJobId(int jobId)
    {
      string sql = @"
      SELECT c.*,
      cj.id as ContractorJobId
      FROM contractorjob cj
      JOIN contractors c ON c.id = cj.contractorId
      WHERE jobId = @JobId;";
      return _db.Query<ContractorJobViewModel>(sql, new { jobId });

    }
  }
}