using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

    public VaultKeep CreateVaultKeep(VaultKeep data)
    {
      var sql = @"INSERT INTO vaultkeeps(
        vaultId,
        keepId,
        creatorId
      ) VALUES(
        @VaultId,
        @KeepId,
        @CreatorId
      ); SELECT LAST_INSERT_ID();";
      data.Id = _db.ExecuteScalar<int>(sql, data);
      return data;
    }
    }
}