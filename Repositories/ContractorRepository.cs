using System;
using System.Collections.Generic;
using System.Data;
using csContractorJob.Models;
using Dapper;

namespace csContractorJob.Repositories
{
  public class ContractorRepository
  {
    private readonly IDbConnection _db;

    public ContractorRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(Contractor newContractor)
    {
      string sql = @"INSERT INTO contractors
            (name, rate, creatorId)
            VALUES
            (@Name, @Rate, @CreatorId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }

    internal IEnumerable<Contractor> Get()
    {
      string sql = @"SELECT * FROM contractors";
      return _db.Query<Contractor>(sql);
    }

    internal bool Delete(int id)
    {
      string sql = @"DELETE FROM contractors WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows > 0;
    }

    internal Contractor GetOne(int id)
    {
      string sql = "SELECT * FROM CONTRACTORS WHERE id = @ID LIMIT 1";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }
  }
}