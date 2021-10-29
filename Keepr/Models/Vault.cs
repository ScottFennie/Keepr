using System;

namespace Keepr.Models
{
    public class Vault
    {
     public DateTime CreatedAt { get; set; }
     public DateTime UpdatedAt { get; set; }
     public int Id { get; set; }
     public string CreatorId { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public bool IsPrivate { get; set; }
     public Profile Creator {get; set;}

    }
}