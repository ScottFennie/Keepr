using System.Collections.Generic;
using System.Data;
using System.Linq;
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

       public List<VaultKeep> GetVaultKeeps(int vaultId)
        {
        var sql = @"
        SELECT 
        vk.*, 
        a.*, 
        v.* 
        FROM vaultkeeps vk
        JOIN accounts a on a.id = v.creatorId; 
        JOIN vaults v ON v.id = vk.vaultId;
        WHERE vk.vaultId = @vaultId;
        ";
        return _db.Query<VaultKeep, Account, Vault, VaultKeep>(sql, (vk, a, v) =>
        {
            vk.Creator = a;
            vk.Vault = v;
            return vk;
        }, new { vaultId }).ToList();

        }
    }
}