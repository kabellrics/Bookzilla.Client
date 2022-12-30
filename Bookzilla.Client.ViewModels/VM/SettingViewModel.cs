using Bookzilla.Client.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookzilla.Client.ViewModels.VM
{
    public class SettingViewModel : BaseViewModel
    {
        private string _BookzillaApiEndpoint;
        private string _BookzillaFolder;
        public string BookzillaApiEndpoint
        {
            get => _BookzillaApiEndpoint;
            set
            {
                SetProperty(ref _BookzillaApiEndpoint, value);
            }
        }

        public string BookzillaFolder
        {
            get => _BookzillaFolder;
            set
            {
                SetProperty(ref _BookzillaFolder, value);
            }
        }
        public ICommand ValidateEndpointCommand { get; }
        public ICommand SetBookzillaFolderCommand { get; }


        public SettingViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository)
        {
            TitlePage = "Paramètres";
            ValidateEndpointCommand = new AsyncRelayCommand(UpdateBookzillaApiEndpoint);
            SetBookzillaFolderCommand = new AsyncRelayCommand(Update_BookzillaFolder);
        }
        private async Task Update_BookzillaFolder()
        {
            _settingsService.BookzillaFolder = BookzillaFolder;
        }

        private async Task UpdateBookzillaApiEndpoint()
        {
            _settingsService.BookzillaApiEndpoint = BookzillaApiEndpoint;
        }
    }
}
