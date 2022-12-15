using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IUpSynchro
    {
        Task<bool> SynchroCollectionFromServer();
        Task<bool> SynchroSerieFromServer();
        Task<bool> SynchroAlbumFromServer();
    }
}
