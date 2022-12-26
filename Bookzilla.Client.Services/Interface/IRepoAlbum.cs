using Bookzilla.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IRepoAlbum
    {
        Task<IEnumerable<Album>> GetAll();
        Task<IEnumerable<Album>> GetAllByName(string search);
        Task<IEnumerable<Album>> GetAllBySeries(int id);
        Task<Album> Get(int id);
        Task<int> DeleteAlbumAsync(Album item);
        Task<int> UpsertAlbumAsync(Album item);
    }
}
