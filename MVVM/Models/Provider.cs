using PetGPS.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS.MVVM.Models
{
    public class Provider : TableData
    {
         public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ServiceType { get; set; }
        public float Calification {  get; set; }
        public int NumbOfCalifications { get; set; }
    }
}
