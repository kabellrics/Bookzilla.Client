using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class SettingsService : ISettingsService
    {
        private readonly string IdBookzillaApiEndpoint = "bookzilla_endpoint";
        private readonly string BookzillaApiEndpointDefault = String.Empty;
        private readonly string IdBookzillaFolder = "bookzilla_folder";
        private readonly string BookzillaFolderDefault = String.Empty;
        public string BookzillaApiEndpoint
        {
            get => Preferences.Get(IdBookzillaApiEndpoint, BookzillaApiEndpointDefault);
            set => Preferences.Set(IdBookzillaApiEndpoint, value);
        }
        public string BookzillaFolder
        {
            get => Preferences.Get(IdBookzillaFolder, BookzillaFolderDefault);
            set => Preferences.Set(IdBookzillaFolder, value);
        }
        }
}
