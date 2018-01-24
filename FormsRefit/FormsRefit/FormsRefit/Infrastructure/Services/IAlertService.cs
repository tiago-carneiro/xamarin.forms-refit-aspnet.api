using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsRefit
{    
    public interface IAlertService
    {
        Task<bool> Display(string title, string message, string ok, string cancel);
        Task Display(string title, string message, string cancel);
    }

    public class AlertService : IAlertService
    {
        public async Task<bool> Display(string title, string message, string ok, string cancel) =>
            await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);

        public async Task Display(string title, string message, string cancel) =>
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
    }
}
