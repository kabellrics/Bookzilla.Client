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
    public class BaseViewModel : ObservableObject
    {
        public readonly ISettingsService _settingsService;
        public readonly INavigationService _navigationService;
        public readonly ISynchroService _synchroService;
        public readonly IRepository _repository;
        private readonly SemaphoreSlim _isBusyLock = new(1, 1);
        private bool _isInitialized;
        private bool _isBusy;
        private string _titlepage;
        public string TitlePage
        {
            get => _titlepage;
            set
            {
                SetProperty(ref _titlepage, value);
            }
        }
        public bool IsInitialized
        {
            get => _isInitialized;
            set => SetProperty(ref _isInitialized, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set => SetProperty(ref _isBusy, value);
        }
        public ICommand GoBackCommand { get; }
        public BaseViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
        {
            _settingsService = settingsService;
            _navigationService = navigationService;
            _synchroService = synchroService;
            _repository = repository;
            GoBackCommand = new AsyncRelayCommand(GoBackAsync);
        }
        private async Task GoBackAsync()
        {
            await _navigationService.GoBackAsync();
        }
        public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
        {
        }
        public async Task IsBusyFor(Func<Task> unitOfWork)
        {
            await _isBusyLock.WaitAsync();

            try
            {
                IsBusy = true;

                await unitOfWork();
            }
            finally
            {
                IsBusy = false;
                _isBusyLock.Release();
            }
        }
    }
}
