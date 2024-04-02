using Application.Repository;
    using Domain;
using Domain.Intefaces;
using Domain.Interfaces;
    using Persistence.Data;

    namespace Application.UnitOfWork
    {
        public class UnitOfWork : IUnitOfWork, IDisposable
        {
            private readonly DbAppContext _context;  
            public UnitOfWork(DbAppContext context)
            {
                _context = context;
            }
            private  UserRepository _Users;
            private RoleRepository _Roles;
            private PatientRepository _Patients;


        public IRole Roles {
            get{
                _Roles ??= new RoleRepository(_context);
                return _Roles;
            }
        }

        public IUser Users {
            get{
                _Users ??= new UserRepository(_context);
                return _Users;
            }
        }

        public IPatient Patients {
            get{
                _Patients ??= new PatientRepository(_context);
                return _Patients;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}