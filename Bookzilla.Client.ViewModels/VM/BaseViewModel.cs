using Bookzilla.Client.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public BaseViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
        {
            _settingsService = settingsService;
            _navigationService = navigationService;
            _synchroService = synchroService;
            _repository = repository;
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
