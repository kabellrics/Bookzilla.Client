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
    public class HomeViewModel : BaseViewModel
    {
        private string _readAlbLabel;
        public string ReadAlbLabel
        {
            get => _readAlbLabel;
            set
            {
                SetProperty(ref _readAlbLabel, value);
            }
        }
        private string _readCollecLabel;
        public string ReadCollecLabel
        {
            get => _readCollecLabel;
            set
            {
                SetProperty(ref _readCollecLabel, value);
            }
        }
        private string _readSerieLabel;
        public string ReadSerieLabel
        {
            get => _readSerieLabel;
            set
            {
                SetProperty(ref _readSerieLabel, value);
            }
        }

        private string _CollectionLabel;
        public string CollectionLabel
        {
            get => _CollectionLabel;
            set
            {
                SetProperty(ref _CollectionLabel, value);
            }
        }
        private string _SynchroLabel;
        public string SynchroLabel
        {
            get => _SynchroLabel;
            set
            {
                SetProperty(ref _SynchroLabel, value);
            }
        }
        private string _SettingsLabel;
        public string SettingsLabel
        {
            get => _SettingsLabel;
            set
            {
                SetProperty(ref _SettingsLabel, value);
            }
        }
        private string _AlbLabel;
        public string AlbLabel
        {
            get => _AlbLabel;
            set
            {
                SetProperty(ref _AlbLabel, value);
            }
        }
        private string _SerieLabel;
        public string SerieLabel
        {
            get => _SerieLabel;
            set
            {
                SetProperty(ref _SerieLabel, value);
            }
        }
        public ObservableCollection<AlbumObjObs> CurrentReadingAlbum;
        public ObservableCollection<SerieObjObs> CurrentReadingSerie;
        public ObservableCollection<CollectionObjObs> CurrentReadingCollec;

        public ICommand GoToAlbumsCommand { get; }
        public ICommand GoToSeriesCommand { get; }
        public ICommand GoToCollectionsCommand { get; }
        public ICommand GoToAlbumSpecificCommand { get; }
        public ICommand GoToSerieSpecificCommand { get; }
        public ICommand GoToCollectionSpecificCommand { get; }
        public ICommand GotoSynchroCommand { get; }
        public ICommand GotoSettingsCommand { get; }
        public HomeViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Bookzilla";
            ReadAlbLabel = "Album en cours de lecture";
            ReadCollecLabel = "Collection en cours de lecture";
            ReadSerieLabel = "Série en cours de lecture";
            CollectionLabel = "Voir les Collections";
            SerieLabel = "Voir les Series";
            AlbLabel = "Voir les Albums";
            SynchroLabel = "Synchonisation";
            SettingsLabel = "Réglages";
            CurrentReadingAlbum = new ObservableCollection<AlbumObjObs>();
            CurrentReadingSerie = new ObservableCollection<SerieObjObs>();
            CurrentReadingCollec = new ObservableCollection<CollectionObjObs>();
            GoToAlbumsCommand = new AsyncRelayCommand(GoToAlbumsAsync);
            GoToSeriesCommand = new AsyncRelayCommand(GoToSeriesAsync);
            GoToCollectionsCommand = new AsyncRelayCommand(GoToCollectionsAsync);
            GoToAlbumSpecificCommand = new AsyncRelayCommand<AlbumObjObs>(GoToAlbumSpecificAsync);
            GoToSerieSpecificCommand = new AsyncRelayCommand<SerieObjObs>(GoToSerieSpecificAsync);
            GoToCollectionSpecificCommand = new AsyncRelayCommand<CollectionObjObs>(GoToCollectionSpecificAsync);
            GotoSynchroCommand = new AsyncRelayCommand(GotoSynchroAsync);
            GotoSettingsCommand = new AsyncRelayCommand(GotoSettingsAsync);
        }
        private async Task GoToAlbumsAsync()
        {
            await _navigationService.NavigateToAsync("Albums");
        }
        private async Task GoToSeriesAsync()
        {
            await _navigationService.NavigateToAsync("Series");
        }
        private async Task GoToCollectionsAsync()
        {
            await _navigationService.NavigateToAsync("Collections");
        }
        private async Task GoToAlbumSpecificAsync(AlbumObjObs item)
        {
            await _navigationService.NavigateToAsync("AlbumDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }
        private async Task GoToSerieSpecificAsync(SerieObjObs item)
        {
            await _navigationService.NavigateToAsync("SerieDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }
        private async Task GoToCollectionSpecificAsync(CollectionObjObs item)
        {
            await _navigationService.NavigateToAsync("CollectionDetail",
                    new Dictionary<string, object> { { "ItemId", item.Id } });
        }
        private async Task GotoSynchroAsync()
        {
            await _navigationService.NavigateToAsync("Synchro");
        }
        private async Task GotoSettingsAsync()
        {
            await _navigationService.NavigateToAsync("Settings");
        }
        public async Task LoadDataAsync()
        {
            await IsBusyFor(
            async () =>
            {
                CurrentReadingAlbum.Clear();
                CurrentReadingSerie.Clear();
                CurrentReadingCollec.Clear();

                var dataalb = await _repository.Albums.GetCurrentReading();
                foreach (var item in dataalb)
                {
                    CurrentReadingAlbum.Add(new AlbumObjObs(item));
                }
                var dataserie = await _repository.Series.GetCurrentReading();
                foreach (var item in dataserie)
                {
                    CurrentReadingSerie.Add(new SerieObjObs(item));
                }
                var datacollec = await _repository.Collections.GetCurrentReading();
                foreach (var item in datacollec)
                {
                    CurrentReadingCollec.Add(new CollectionObjObs(item));
                }
            });
        }
    }
}
