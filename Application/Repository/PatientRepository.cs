using Domain.Entities;
using Domain.Intefaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Application.Repository;

    public class PatientRepository : GenericRepository<Patient>, IPatient
    {
        private readonly DbAppContext _context;

        public PatientRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
    public override async Task<(int totalRegistros, IEnumerable<Patient> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
            {
                var query = _context.Patients as IQueryable<Patient>;
    
                if(!string.IsNullOrEmpty(search))
                {
                    query = query.Where(p => p.Id.ToString() == search);

                }
    
                query = query.OrderBy(p => p.Id);
                var totalRegistros = await query.CountAsync();
                var registros = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    
                return (totalRegistros, registros);
            }        

    }