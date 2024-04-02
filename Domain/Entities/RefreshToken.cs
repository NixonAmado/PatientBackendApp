using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RefreshToken
    {
        public int Id  {get;set;}
        public int User_id { get; set; }
        public  User UserNavigation { get; set; } = null!;
        public  string Token { get; set;} = null!;
        public DateTime Expires {get;set;}
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created {get;set;}
        public DateTime? Revoked {get;set;}
        public bool IsActive => Revoked ==null && !IsExpired;

    }
}