using System;
using System.Data;
using csContractorJob.Models;
using Dapper;

namespace csContractorJob.Repositories
{
  public class ProfileRepository
  {

    private readonly IDbConnection _db;

    public ProfileRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Profile GetById(string id)
    {
      string sql = "SELECT * FROM profiles3 WHERE id = @id";
      return _db.QueryFirstOrDefault<Profile>(sql, new { id });
    }

    internal Profile Create(Profile userInfo)
    {
      string sql = @"INSERT INTO profiles3
                (id)
                VALUES 
                (@Id)";
      _db.Execute(sql, userInfo);
      return userInfo;
    }
  }
}