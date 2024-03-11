using PetGPS.MVVM.Models;
using PetGPS.MVVM.Views;
using PetGPS.Repositories;

namespace PetGPS
{
    public partial class App : Application
    {
        public static BaseRepository<User> UserRepo { get; private set; }
        public static BaseRepository<Pet> PetRepo { get; private set; }
        public App(BaseRepository<User> _userRepo, BaseRepository<Pet> _petRepo)
        {
            InitializeComponent();

            UserRepo = _userRepo;
            PetRepo = _petRepo;

            RegisterRoutes();

            MainPage = new AppShell();

        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("UserRegPage", typeof(UserRegPage));
            Routing.RegisterRoute("ReportPage", typeof(ReportPage));
            Routing.RegisterRoute("LoggedPage", typeof(LoggedPage));
            Routing.RegisterRoute("PetRegPage", typeof(PetRegPage));
        }

    }
}
