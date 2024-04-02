using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Patient
    {
        public int Id {get; set;}
        public string Name {get;set;}
        public string Address {get;set;}
        public string DNI {get;set;}
        public  string Email {get;set;}
        public string PostalCode {get;set;}
        public string Gender {get;set;}
        public int Phone_number {get;set;}
        public DateOnly Birth_date {get;set;}
        
    }
}