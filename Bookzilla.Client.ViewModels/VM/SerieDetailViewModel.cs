using Bookzilla.Client.Models;
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
        private ReadingStatus _status;
        public ReadingStatus ReadingStatus
        {
            get => _status;
            set
            {
                SetProperty(ref _status, value);
            }
        }
        private int _nbAlbum;
        public int NBAlbum
        {
            get => _nbAlbum;
            set
            {
                SetProperty(ref _nbAlbum, value);
            }
        }
        private int _nbNonLu;
        public int NBNonLu
        {
            get => _nbNonLu;
            set
            {
                SetProperty(ref _nbNonLu, value);
            }
        }
        private int _nbLu;
        public int NBLu
        {
            get => _nbLu;
            set
            {
                SetProperty(ref _nbLu, value);
            }
        }
        private int _nbEnCours;
        public int NBEnCours
        {
            get => _nbEnCours;
            set
            {
                SetProperty(ref _nbEnCours, value);
            }
        }
        public ObservableCollection<AlbumObjObs> Albums;
        public ICommand GoToAlbumSpecificCommand { get; }
        public SerieDetailViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            NBEnCours = NBLu = NBNonLu= NBAlbum= 0;
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
            foreach(var item in data) { Albums.Add(new AlbumObjObs(item)); NBAlbum++; }
            if(Albums.All(x=> x.ReadingStatus == ReadingStatus.NonLu))
            {
                ReadingStatus= ReadingStatus.NonLu;
            }
            else if (Albums.All(x => x.ReadingStatus == ReadingStatus.Lu))
            {
                ReadingStatus= ReadingStatus.Lu;
            }
            else if (Albums.Any(x => x.ReadingStatus == ReadingStatus.EnCours))
            {
                ReadingStatus= ReadingStatus.EnCours;
            }
            NBNonLu = Albums.Count(x=>x.ReadingStatus== ReadingStatus.NonLu);
            NBLu= Albums.Count(x=>x.ReadingStatus== ReadingStatus.Lu);
            NBEnCours= Albums.Count(x=>x.ReadingStatus== ReadingStatus.EnCours);
        }
        private async Task GoToAlbumSpecificAsync(AlbumObjObs item)
        {
            await _navigationService.NavigateToAsync("AlbumDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }
    }
}
