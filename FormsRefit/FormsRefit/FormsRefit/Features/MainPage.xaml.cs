
using Xamarin.Forms;

namespace FormsRefit
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }  
}
