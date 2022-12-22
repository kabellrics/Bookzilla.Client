using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface ISynchroService
    {
        public IUpSynchro Up { get; }
        public IDownSynchro Down { get; }
        public IFileSynchro File { get; }
        public IFileCleaner Clean { get; }

    }
}
