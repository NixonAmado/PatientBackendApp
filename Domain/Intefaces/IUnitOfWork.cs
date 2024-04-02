using Domain.Intefaces;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IRole Roles {get;}
        public IUser Users {get;}
        public IPatient Patients {get;}
        Task<int> SaveAsync();
    }
}