using Bookzilla.Client.APIClient;
using Bookzilla.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class SynchroBase
    {
        protected BookzillaLocalDatabase _context;
        protected AlbumClient AlbumClient;
        protected CollectionClient CollectionClient;
        protected SerieClient SerieClient;

        public SynchroBase(BookzillaLocalDatabase context,String ApiAddress)
        {
            _context = context;
            AlbumClient = new AlbumClient(ApiAddress, new HttpClient());
            CollectionClient = new CollectionClient(ApiAddress, new HttpClient());
            SerieClient = new SerieClient(ApiAddress, new HttpClient());
        }
    }
}
