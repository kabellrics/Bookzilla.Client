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
    public class SerieListViewModel : BaseViewModel
    {
        public ObservableCollection<SerieObjObs> Series;
        public ICommand GoToSerieSpecificCommand { get; }
        public SerieListViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Series";
            Series = new ObservableCollection<SerieObjObs>();
            GoToSerieSpecificCommand = new AsyncRelayCommand<SerieObjObs>(GoToSerieSpecificAsync);
        }
        public async Task LoadDataAsync()
        {
            await IsBusyFor(
            async () =>
            {
                Series.Clear();

                var dataalb = await _repository.Series.GetAll();
                foreach (var item in dataalb)
                {
                    Series.Add(new SerieObjObs(item));
                }
            });
        }
        private async Task GoToSerieSpecificAsync(SerieObjObs item)
        {
            await _navigationService.NavigateToAsync("SerieDetail",
                    new Dictionary<string, object> { { "Item", item } });
        }
    }
}
