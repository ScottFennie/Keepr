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
     public bool? IsPrivate { get; set; }

     public string Img {get; set;} = "https://www.rd.com/wp-content/uploads/2017/12/01_astronaut_Yes-Outer-Space-Has-a-Smell%E2%80%94Here%E2%80%99s-What-It-Smells-Like_241509286_Andrey-Armyagov.jpg";
     public Profile Creator {get; set;}

    }
}