using System;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;

        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }


        public Vault CreateVault(Vault data)
        {
            var sql = @"
            INSERT INTO vaults(name, description, isPrivate, creatorId, img)
            VALUES(@Name, @Description, @IsPrivate, @CreatorId, @Img);
            SELECT LAST_INSERT_ID();
            ";
            var id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }

        public Vault GetById(int vaultId)
        {
            string sql = @"
            SELECT
            v.*,
            a.*
            FROM vaults v
            JOIN accounts a on v.creatorId = a.id
            WHERE v.id = @vaultId;
            ";
            return _db.Query<Vault, Account, Vault>(sql, (v, a) => {
                v.Creator = a;
                return v;
            }, new {vaultId}).FirstOrDefault();
        }

        public Vault Edit(Vault newData)
        {
            string sql = @"
            UPDATE vaults
            SET
            name = @Name,
            description = @Description,
            isPrivate = @IsPrivate
            WHERE id = @Id LIMIT 1;
            ";
            var rowsAffected = _db.Execute(sql, newData);
            if (rowsAffected == 0)
            {
                throw new Exception("Failed to update vault");
            }
            return newData;
        }

        public void Delete(int vaultId)
        {
            string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
            var rowsAffected = _db.Execute(sql, new {vaultId});
            if(rowsAffected == 0)
            {
                throw new Exception("Failed to delete vault");
            }
        }

    }
}