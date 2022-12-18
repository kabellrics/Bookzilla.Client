using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IDownSynchro
    {
        Task<bool> SynchroCollectionToServer();
        Task<bool> SynchroSerieToServer();
        Task<bool> SynchroAlbumToServer();
    }
}
