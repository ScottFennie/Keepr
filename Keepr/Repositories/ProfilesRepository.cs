using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }


    public Profile GetProfileById(string profileId)
    {
      var sql = @"
      SELECT 
      *
      FROM
      accounts a
      WHERE a.id = @profileId;
      ";
      return _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
    }

    public List<Keep> GetKeepsByProfileId(string profileId)
        {
           string sql = @"
           SELECT
           k.*,
           a.*
           FROM keeps k
           JOIN accounts a on k.creatorId = a.id
           WHERE k.creatorId = @profileId;";
           return _db.Query<Keep, Profile, Keep>(sql, (k, a) =>{
               k.Creator = a;
               return k;
           }, new {profileId}).ToList();
        }

  
    }
}