using Bookzilla.Client.Services.Interface;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.ViewModels.VM
{
    public class SerieListViewModel : BaseViewModel
    {
        public SerieListViewModel(ISettingsService settingsService, INavigationService navigationService, ISynchroService synchroService, IRepository repository)
            : base(settingsService, navigationService, synchroService, repository) { }
    }
}
