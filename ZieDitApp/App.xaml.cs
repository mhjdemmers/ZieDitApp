using ZieDitApp.Model;
using ZieDitApp.Repositories;


namespace ZieDitApp
{
    public partial class App : Application
    {
        public static BaseRepository<User>? UserRepo { get; private set; }
        public App(BaseRepository<User> studentRepo)
        {
            InitializeComponent();
            UserRepo = new UserRepository();
            MainPage = new NavigationPage(new View.LoginPage());
        }
    }
}
