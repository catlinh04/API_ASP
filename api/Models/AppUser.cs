using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    
    public class AppUser : IdentityUser
    {
        public string Address { get; set; } 
        public List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    }
}