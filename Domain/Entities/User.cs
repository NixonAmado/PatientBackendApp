using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set;}
        public string User_password { get; set;}
        public virtual ICollection<Role> Roles {get;set;} = new HashSet<Role>();
        public virtual ICollection<UserRole>? UsersRoles {get;set;}
        public virtual ICollection<RefreshToken> RefreshTokens {get;set;} = new HashSet<RefreshToken>();
    }
}