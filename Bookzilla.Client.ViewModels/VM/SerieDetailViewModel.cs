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
    public class SerieDetailViewModel : BaseViewModel
    {
        private SerieObjObs _item;
        public SerieObjObs Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
            }
        }
        public ObservableCollection<AlbumObjObs> Albums;
        public ICommand GoToAlbumSpecificCommand { get; }
        public SerieDetailViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = Item.Name;
            Albums = new ObservableCollection<AlbumObjObs>();
            GoToAlbumSpecificCommand = new AsyncRelayCommand<AlbumObjObs>(GoToAlbumSpecificAsync);
        }
        public override void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            base.ApplyQueryAttributes(query);

            if (query.ValueAsInt("ItemId") > 0)
            {
                InitializeItemAsync(query.ValueAsInt("ItemId"));
            }
        }
        private async void InitializeItemAsync(int id)
        {
            Albums.Clear();
            Item = new SerieObjObs(await _repository.Series.Get(id));
            TitlePage = Item.Name;
            var data = await _repository.Albums.GetAllBySeries(Item.Id);
            foreach(var item in data) { Albums.Add(new AlbumObjObs(item)); }
        }
        private async Task GoToAlbumSpecificAsync(AlbumObjObs item)
        {
            await _navigationService.NavigateToAsync("AlbumDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }
    }
}
