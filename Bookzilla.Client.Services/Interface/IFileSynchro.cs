using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IFileSynchro
    {
        Task<bool> CollectionArtPartial();
        Task<bool> CollectionArtFull();
        Task<bool> SeriesArtPartial();
        Task<bool> SeriesArtFull();
        Task<bool> CoverFilePartial();
        Task<bool> CoverFileFull();
        Task<bool> FilePartial();
        Task<bool> FileFull();
    }
}
