using PetGPS.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS.MVVM.Models
{
    public class Report : TableData
    {
        public int UserId { get; set; }
        public int PetId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
