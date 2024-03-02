using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS.MVVM.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Colors { get; set; }
        public string Race { get; set; }
        public string Sex { get; set; }
        public int OwnerId { get; set; }
    }
}
