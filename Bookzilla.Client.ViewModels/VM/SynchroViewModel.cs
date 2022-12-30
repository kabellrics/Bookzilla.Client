using Bookzilla.Client.Services.Interface;
using Bookzilla.Client.ViewModels.ObsObj;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.ViewModels.VM
{
    public class SynchroViewModel : BaseViewModel
    {
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
        private string _CollecLabel;
        public string CollecLabel
        {
            get => _CollecLabel;
            set
            {
                SetProperty(ref _CollecLabel, value);
            }
        }
        private string _NewLabel;
        public string NewLabel
        {
            get => _NewLabel;
            set
            {
                SetProperty(ref _NewLabel, value);
            }
        }
        private string _ModifiedLabel;
        public string ModifiedLabel
        {
            get => _ModifiedLabel;
            set
            {
                SetProperty(ref _ModifiedLabel, value);
            }
        }
        private string _DeletedLabel;
        public string DeletedLabel
        {
            get => _DeletedLabel;
            set
            {
                SetProperty(ref _DeletedLabel, value);
            }
        }


        public ObservableCollection<AlbumObjObs> CreatedAlbum;
        public ObservableCollection<SerieObjObs> CreatedSerie;
        public ObservableCollection<CollectionObjObs> CreatedCollec;
        public ObservableCollection<AlbumObjObs> UpdatedAlbum;
        public ObservableCollection<SerieObjObs> UpdatedSerie;
        public ObservableCollection<CollectionObjObs> UpdatedCollec;
        public ObservableCollection<AlbumObjObs> DeletedAlbum;
        public ObservableCollection<SerieObjObs> DeletedSerie;
        public ObservableCollection<CollectionObjObs> DeletedCollec;
        public SynchroViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Statut de Synchronisation";
            AlbLabel = "Albums";
            SerieLabel = "Serie";
            CollecLabel = "Collection";
            NewLabel = "Ajouts";
            ModifiedLabel = "Modifications";
            DeletedLabel = "Supprimés";
            CreatedAlbum = new ObservableCollection<AlbumObjObs>();
            CreatedSerie = new ObservableCollection<SerieObjObs>();
            CreatedCollec = new ObservableCollection<CollectionObjObs>();
            UpdatedAlbum = new ObservableCollection<AlbumObjObs>();
            UpdatedSerie = new ObservableCollection<SerieObjObs>();
            UpdatedCollec = new ObservableCollection<CollectionObjObs>();
            DeletedAlbum = new ObservableCollection<AlbumObjObs>();
            DeletedSerie = new ObservableCollection<SerieObjObs>();
            DeletedCollec = new ObservableCollection<CollectionObjObs>();
        }
        public async Task LoadDataAsync()
        {
            await IsBusyFor(
            async () =>
            {
                CreatedAlbum.Clear();
                CreatedSerie.Clear();
                CreatedCollec.Clear();
                UpdatedAlbum.Clear();
                UpdatedSerie.Clear();
                UpdatedCollec.Clear();
                DeletedAlbum.Clear();
                DeletedSerie.Clear();
                DeletedCollec.Clear();
                await LoadCreatedItemAsync();
                await LoadUpdatedItemAsync();
                await LoadDeletedItemAsync();
            });
        }

        private async Task LoadCreatedItemAsync()
        {
            var dataalb = await _repository.Albums.GetCurrentReading();
            foreach (var item in dataalb.Where(x=>x.SynchroStatus == Models.SynchroStatus.New))
            {
                CreatedAlbum.Add(new AlbumObjObs(item));
            }
            var dataserie = await _repository.Series.GetCurrentReading();
            foreach (var item in dataserie.Where(x => x.SynchroStatus == Models.SynchroStatus.New))
            {
                CreatedSerie.Add(new SerieObjObs(item));
            }
            var datacollec = await _repository.Collections.GetCurrentReading();
            foreach (var item in datacollec.Where(x => x.SynchroStatus == Models.SynchroStatus.New))
            {
                CreatedCollec.Add(new CollectionObjObs(item));
            }
        }

        private async Task LoadUpdatedItemAsync()
        {
            var dataalb = await _repository.Albums.GetCurrentReading();
            foreach (var item in dataalb.Where(x => x.SynchroStatus == Models.SynchroStatus.Changed))
            {
                UpdatedAlbum.Add(new AlbumObjObs(item));
            }
            var dataserie = await _repository.Series.GetCurrentReading();
            foreach (var item in dataserie.Where(x => x.SynchroStatus == Models.SynchroStatus.Changed))
            {
                UpdatedSerie.Add(new SerieObjObs(item));
            }
            var datacollec = await _repository.Collections.GetCurrentReading();
            foreach (var item in datacollec.Where(x => x.SynchroStatus == Models.SynchroStatus.Changed))
            {
                UpdatedCollec.Add(new CollectionObjObs(item));
            }
        }

        private async Task LoadDeletedItemAsync()
        {
            var dataalb = await _repository.Albums.GetCurrentReading();
            foreach (var item in dataalb.Where(x => x.SynchroStatus == Models.SynchroStatus.Deleted))
            {
                DeletedAlbum.Add(new AlbumObjObs(item));
            }
            var dataserie = await _repository.Series.GetCurrentReading();
            foreach (var item in dataserie.Where(x => x.SynchroStatus == Models.SynchroStatus.Deleted))
            {
                DeletedSerie.Add(new SerieObjObs(item));
            }
            var datacollec = await _repository.Collections.GetCurrentReading();
            foreach (var item in datacollec.Where(x => x.SynchroStatus == Models.SynchroStatus.Deleted))
            {
                DeletedCollec.Add(new CollectionObjObs(item));
            }
        }
    }
}
