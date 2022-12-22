using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class Repository : IRepository
    {
        private readonly BookzillaLocalDatabase _context;
        protected readonly ISettingsService _settings;
        public Repository(BookzillaLocalDatabase context, ISettingsService settings)
        {
            _context = context;
            _settings = settings;
            Albums = new RepoAlbum(_context, _settings);
            Series = new RepoSerie(_context, _settings);
            Collections = new RepoCollection(_context, _settings);
        }
        public IRepoAlbum Albums { get; private set; }
        public IRepoSeries Series { get; private set; }
        public IRepoCollection Collections { get; private set; }
    }
}
