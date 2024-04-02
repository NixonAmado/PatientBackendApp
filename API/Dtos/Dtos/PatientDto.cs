using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Dtos
{
    public class PatientDto
    {
        public string Address {get;set;}
        public DateOnly Birth_date {get;set;}
        public string Dni {get;set;}
        public string Email {get;set;}
        public string Gender {get;set;}
        public string Name {get;set;}
        public int Phone_number {get;set;}
        public string PostalCode {get;set;}
    }
}