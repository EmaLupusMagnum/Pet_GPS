using PetGPS.MVVM.Models;
using PetGPS.Repositories;

namespace PetGPS
{
    public partial class App : Application
    {
        public static BaseRepository<User> UserRepo { get; private set; }
        public App(BaseRepository<User> _userRepo)
        {
            InitializeComponent();

            UserRepo = _userRepo;

            MainPage = new AppShell();
        }
    }
}
