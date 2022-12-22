using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class SynchroService: ISynchroService
    {
        private readonly BookzillaLocalDatabase _context;
        private readonly String _ApiAddress;
        protected ISettingsService _settings;
        public SynchroService(BookzillaLocalDatabase context, String ApiAddress, ISettingsService settings)
        {
            _context = context;
            _ApiAddress = ApiAddress;
            _settings= settings;
            Up = new UpSynchro(_context, ApiAddress, _settings);
            Down = new DownSynchro(_context, ApiAddress, _settings);
            File = new FileSynchro(_context, ApiAddress, _settings);
            Clean = new FileCleaner(_context, ApiAddress, _settings);
        }
        public IUpSynchro Up { get; private set; }
        public IDownSynchro Down { get; private set; }
        public IFileSynchro File { get; private set; }
        public IFileCleaner Clean { get; private set; }
    }
}
