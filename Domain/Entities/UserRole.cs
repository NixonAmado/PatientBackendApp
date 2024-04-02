namespace Domain.Entities;
    public class UserRole
    {
        public int User_id { get; set; }
        public User UserNavigation { get; set;}
        public int Role_id { get; set;}
        public Role RoleNavigation { get; set;}  
    }