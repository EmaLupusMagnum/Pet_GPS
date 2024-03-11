using PetGPS.Abstractions;
using SQLite;

namespace PetGPS.MVVM.Models
{
    public class User: TableData
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
