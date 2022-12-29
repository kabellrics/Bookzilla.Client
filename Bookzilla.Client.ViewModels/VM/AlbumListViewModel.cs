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
    public class AlbumListViewModel : BaseViewModel
    {
        public ObservableCollection<AlbumObjObs> Albums;
        public ICommand GoToAlbumSpecificCommand { get; }
        public AlbumListViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Albums";
            Albums = new ObservableCollection<AlbumObjObs>();
            GoToAlbumSpecificCommand = new AsyncRelayCommand<AlbumObjObs>(GoToAlbumSpecificAsync);
        }
        public async Task LoadDataAsync()
        {
            await IsBusyFor(
            async () =>
            {
                Albums.Clear();

                var dataalb = await _repository.Albums.GetAll();
                foreach (var item in dataalb)
                {
                    Albums.Add(new AlbumObjObs(item));
                }
            });
        }
        private async Task GoToAlbumSpecificAsync(AlbumObjObs item)
        {
            await _navigationService.NavigateToAsync("AlbumDetail",
                    new Dictionary<string, object> { { "Item", item } });
        }
    }
}
