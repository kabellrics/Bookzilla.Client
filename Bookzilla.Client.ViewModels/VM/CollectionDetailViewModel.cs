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
    public class CollectionDetailViewModel : BaseViewModel
    {
        private CollectionObjObs _item;
        public CollectionObjObs Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
            }
        }
        private int _nbSerie;
        public int NBSerie
        {
            get => _nbSerie;
            set
            {
                SetProperty(ref _nbSerie, value);
            }
        }
        public ICommand GoToSerieSpecificCommand { get; }
        public ObservableCollection<SerieObjObs> Series;
        public CollectionDetailViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            NBSerie = 0;
            Series = new ObservableCollection<SerieObjObs>();
            GoToSerieSpecificCommand = new AsyncRelayCommand<SerieObjObs>(GoToSerieSpecificAsync);
        }
        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);

            if (query.ValueAsInt("ItemId") > 0)
            {
                InitializeItemAsync(query.ValueAsInt("ItemId"));
            }
        }
        private async Task GoToSerieSpecificAsync(SerieObjObs item)
        {
            await _navigationService.NavigateToAsync("SerieDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }

        private async void InitializeItemAsync(int id)
        {
            Series.Clear();
            Item = new CollectionObjObs(await _repository.Collections.Get(id));
            TitlePage = Item.Name;
            var data = await _repository.Series.GetAllByCollec(Item.Id);
            foreach (var item in data) { Series.Add(new SerieObjObs(item)); NBSerie++; }
        }
    }
}
