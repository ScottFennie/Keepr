using System;

namespace Keepr.Models
{
    public class Account : Profile
    {
        // public string Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}