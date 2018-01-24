using Refit;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace FormsRefit
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IApiRestfull _api;
        protected IApiRestfull Api => _api ?? (_api = RestService.For<IApiRestfull>(ConstantsHelper.BaseApiUrl));

        IAlertService _alertService;
        protected IAlertService AlertService => _alertService ?? (_alertService = DependencyService.Get<IAlertService>());

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] String propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
