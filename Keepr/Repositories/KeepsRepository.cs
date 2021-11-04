using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        public List<Keep> GetKeeps()
        {
           string sql = @"
           SELECT
           k.*,
           a.*
           FROM keeps k
           JOIN accounts a on k.creatorId = a.id;";
           return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>{
               k.Creator = a;
               return k;
           }).ToList();
        }

        public Keep CreateKeep(Keep data)
        {
            var sql = @"
            INSERT INTO keeps(name, description, img, creatorId, views, shares, keeps)
            VALUES(@Name, @Description, @Img, @CreatorId, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID();
            ";
            var id = _db.ExecuteScalar<int>(sql, data);
            data.Id = id;
            return data;
        }

        public Keep GetById(int keepId)
        {
            string sql = @"
            SELECT
            k.*,
            a.*
            FROM keeps k
            JOIN accounts a on k.creatorId = a.id
            WHERE k.id = @keepId;
            ";
            return _db.Query<Keep, Account, Keep>(sql, (k, a) => {
                k.Creator = a;
                return k;
            }, new {keepId}).FirstOrDefault();
        }

        public Keep Edit(Keep newData)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            keeps = @Keeps
            WHERE id = @Id LIMIT 1;
            ";
            var rowsAffected = _db.Execute(sql, newData);
            if (rowsAffected == 0)
            {
                throw new Exception("Failed to update keep");
            }
            return newData;
        }
        public Keep IncreaseViews(Keep newData)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views
            WHERE id = @Id LIMIT 1;
            ";
            var rowsAffected = _db.Execute(sql, newData);
            if (rowsAffected == 0)
            {
                throw new Exception("Failed to update keep");
            }
            return newData;
        }
        public Keep IncreaseSaves(Keep newData)
        {
            string sql = @"
            UPDATE keeps
            SET
            name = @Name,
            description = @Description,
            img = @Img,
            views = @Views,
            keeps = @Keeps
            WHERE id = @Id LIMIT 1;
            ";
            var rowsAffected = _db.Execute(sql, newData);
            if (rowsAffected == 0)
            {
                throw new Exception("Failed to update keep");
            }
            return newData;
        }

        public void Delete(int keepId)
        {
            string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
            var rowsAffected = _db.Execute(sql, new {keepId});
            if(rowsAffected == 0)
            {
                throw new Exception("Failed to delete keep");
            }
        }
    }
}