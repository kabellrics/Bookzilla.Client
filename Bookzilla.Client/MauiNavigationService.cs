using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client
{
    public class MauiNavigationService : INavigationService
    {
        private readonly ISettingsService _settingsService;

        public MauiNavigationService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public Task InitializeAsync() =>
             NavigateToAsync(
            string.IsNullOrEmpty(_settingsService.BookzillaApiEndpoint) || string.IsNullOrEmpty(_settingsService.BookzillaFolder)
                ? "Settings"
                : "Home");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
