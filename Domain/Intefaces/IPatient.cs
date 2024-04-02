using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Intefaces
{
    public interface IPatient: IGenericRepository<Patient>
    {
        
    }
}