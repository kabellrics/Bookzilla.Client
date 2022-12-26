using Bookzilla.Client.APIClient;
using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class SynchroBase
    {
        protected ISettingsService _settings;
        protected BookzillaLocalDatabase _context;
        protected AlbumClient AlbumClient;
        protected CollectionClient CollectionClient;
        protected SerieClient SerieClient;
        protected FileClient FileClient;

        public SynchroBase(BookzillaLocalDatabase context,String ApiAddress, ISettingsService settings)
        {
            _context = context;
            _settings = settings;
            AlbumClient = new AlbumClient(ApiAddress, new HttpClient());
            CollectionClient = new CollectionClient(ApiAddress, new HttpClient());
            SerieClient = new SerieClient(ApiAddress, new HttpClient());
            FileClient = new FileClient(ApiAddress, new HttpClient());
        }
    }
}
