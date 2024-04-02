using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

    public class RoleRepository : GenericRepository<Role>, IRole
    {
        private readonly DbAppContext _context;

        public RoleRepository(DbAppContext context): base(context)
        {
            _context = context;
        }


    }
