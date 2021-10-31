using System;

namespace Keepr.Models
{
    public class Keep
    {
     public DateTime CreatedAt { get; set; }
     public DateTime UpdatedAt { get; set; }
     public int Id { get; set; }
     public string CreatorId { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public string Img { get; set; }
     public int Views { get; set; } = 0;
     public int Shares { get; set; } = 0;
     public int Keeps { get; set; } = 0;

     public Profile Creator {get; set;}

    }

    public class VaultKeep : Keep
  {
    public int VaultId {get; set;}
    public int KeepId {get; set;}

    public Keep Keep {get; set;}
  }
}