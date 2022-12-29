using Bookzilla.Client.Services.Interface;
using Bookzilla.Client.ViewModels.ObsObj;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookzilla.Client.ViewModels.VM
{
    public class CollectionListViewModel : BaseViewModel
    {
        public ObservableCollection<CollectionObjObs> Collections;
        public ICommand GoToCollectionSpecificCommand { get; }
        public CollectionListViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Collections";
            Collections = new ObservableCollection<CollectionObjObs>();
            GoToCollectionSpecificCommand = new AsyncRelayCommand<CollectionObjObs>(GoToCollectionSpecificAsync);
        }
        public async Task LoadDataAsync()
        {
            await IsBusyFor(
            async () =>
            {
                Collections.Clear();

                var dataalb = await _repository.Collections.GetAll();
                foreach (var item in dataalb)
                {
                    Collections.Add(new CollectionObjObs(item));
                }
            });
        }
        private async Task GoToCollectionSpecificAsync(CollectionObjObs item)
        {
            await _navigationService.NavigateToAsync("CollectionDetail",
                    new Dictionary<string, object> { { "Item", item } });
        }
    }
}
