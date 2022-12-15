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
        public SynchroService(BookzillaLocalDatabase context, String ApiAddress)
        {
            _context = context;
            _ApiAddress = ApiAddress;
        }
        public IUpSynchro Up { get; private set; }
        public IDownSynchro Down { get; private set; }
        public IFileSynchro File { get; private set; }
    }
}
