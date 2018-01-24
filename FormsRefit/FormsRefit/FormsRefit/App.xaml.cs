using Xamarin.Forms;

namespace FormsRefit
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            RegisterImplementation();

            MainPage = new MainPage();
            (MainPage.BindingContext as MainViewModel).Init();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        void RegisterImplementation()
        {
            DependencyService.Register<IAlertService, AlertService>();
        }
    }    
}
