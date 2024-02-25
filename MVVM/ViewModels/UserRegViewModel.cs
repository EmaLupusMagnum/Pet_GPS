using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PetGPS.MVVM.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetGPS.MVVM.ViewModels
{
    public class UserRegViewModel
    {
        public ObservableCollection<User> List { get; set; }

        public UserRegViewModel()
        {
            List = new ObservableCollection<User>()
            {
                new User () {Name = "Hola"},
                new User() {Name = "Poko"},
            };
        }
    }
}
