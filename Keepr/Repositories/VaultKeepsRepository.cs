using System;
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

       public VaultKeep GetVaultKeepById(int vkId)
        {
            string sql = @"
            SELECT
            vk.*,
            a.*
            FROM vaultkeeps vk
            JOIN accounts a on vk.creatorId = a.id
            WHERE vk.id = @vkId;
            ";
            return _db.Query<VaultKeep, Account, VaultKeep>(sql, (vk, a) => {
                vk.Creator = a;
                return vk;
            }, new {vkId}).FirstOrDefault();
        }

// ANOTHER METHOD TO DO A GET BY ID


    //  public List<VaultKeep> GetVaultKeeps(int vId)
    // {
    //   string sql = @"
    //   SELECT 
    //   k.*,
    //   a.*,
    //   vt.*
    //   FROM vaultkeeps vt
    //   JOIN accounts a on a.id = vt.creatorId
    //   JOIN keeps k on k.id = vt.vaultId
    //   WHERE vt.vaultId = @vId;
    //   ";
    //   return _db.Query<VaultKeep, Profile, Keep, VaultKeep>(sql, (vt, a, k) =>
    //   {
    //     vt.Creator = a;
    //     vt.Keep = k;
    //     vt.KeepId = k.Id;
    //     return vt;
    //   }, new { vId }).ToList();
    // }

    public List<VaultKeep> GetVaultKeeps(int vaultKeepId)
    {
      var sql = @"
      SELECT vk.*, k.*, a.* 
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      JOIN accounts a ON k.creatorId = a.id
      WHERE vk.vaultId = @vaultKeepId;
      ";

      return _db.Query<VaultKeep, Keep, Profile, VaultKeep>(sql, (vk, k, a) =>
      {
        // k.Creator = a;
        vk.Keep = k;
        vk.Creator = a;
        return vk;
      }, new { vaultKeepId }).ToList();

    }

        public void DeleteVaultKeep(int vaultKeepId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @vaultKeepId LIMIT 1;";
            var rowsAffected = _db.Execute(sql, new {vaultKeepId});
            if(rowsAffected == 0)
            {
                throw new Exception("Failed to delete vault keep");
            }
        }
    }
}