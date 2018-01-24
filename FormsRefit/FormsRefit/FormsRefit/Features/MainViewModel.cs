using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormsRefit
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand SaveCommand { get => new Command(ExecuteSaveCommand); }
        public ICommand DeleteCommand { get => new Command(ExecuteDeleteCommand); }
        public ICommand ItemClickCommand { get => new Command<ContactModel>(ExecuteItemClickCommand); }

        ObservableCollection<ContactModel> _items = new ObservableCollection<ContactModel>();
        public ObservableCollection<ContactModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private ContactModel _currentItem;
        public ContactModel CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get => _canDelete;
            set => SetProperty(ref _canDelete, value);
        }

        public async void Init() => await LoadItemsAsync();

        private async Task LoadItemsAsync()
        {
            CurrentItem = new ContactModel();
            CanDelete = false;
            Items.Clear();
            var result = await Api.GetContacts().WithBusyIndicator(this);

            if (!result.Success)
            {
                await AlertService.Display("Problema", result.Message ?? "Não foi possível carregar os contatos", "Tentar novamente");
                await LoadItemsAsync();
                return;
            }

            Items.AddRange(result.Data);
        }

        async void ExecuteSaveCommand()
        {
            var task = CanDelete ? Api.PutContact(CurrentItem) : Api.PostContact(CurrentItem);
            var result = await task.WithBusyIndicator(this);

            if (!result.Success)
                await AlertService.Display("Problema", result.Message ?? "Não foi possível efetuar a ação", "Ok");

            await LoadItemsAsync();
        }

        async void ExecuteDeleteCommand()
        {
            var alertOk = await AlertService.Display("Atenção", "Deseja realmente excluir", "Sim", "Não");

            if (alertOk)
            {
                var result = await Api.DeleteContact(CurrentItem.Id).WithBusyIndicator(this);

                if (!result.Success)
                    await AlertService.Display("Problema", result.Message ?? "Não foi possível efetuar a ação", "Ok");

                await LoadItemsAsync();
            }
        }

        void ExecuteItemClickCommand(ContactModel item)
        {
            //CurrentItem = await Api.GetContact(item.Id);
            CurrentItem = item;
            CanDelete = true;
        }
    }
}
