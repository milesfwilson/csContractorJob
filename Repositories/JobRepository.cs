using System;
using System.Collections.Generic;
using System.Data;
using csContractorJob.Models;
using Dapper;

namespace csContractorJob.Repositories
{
  public class JobRepository
  {
    private readonly IDbConnection _db;

    public JobRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Job newJob)
    {
      string sql = @"INSERT INTO jobs
            (title, location, creatorId, budget)
            VALUES
            (@Title, @Location, @CreatorId, @Budget);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newJob);
    }

    internal IEnumerable<Job> Get()
    {
      string sql = @"SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM jobs WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }
  }
}