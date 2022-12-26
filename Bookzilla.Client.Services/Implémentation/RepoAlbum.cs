using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class RepoAlbum : RepoBase, IRepoAlbum
    {
        public RepoAlbum(BookzillaLocalDatabase context, ISettingsService settings) : base(context, settings)
        {
        }
        public async Task<IEnumerable<Album>> GetAll()
        {
            return await _context.GetAlbumsAsync();
        }
        public async Task<IEnumerable<Album>> GetAllByName(string search)
        {
            var albs = await _context.GetAlbumsAsync();
            return albs.Where(x=>x.Name.Contains(search)).OrderBy(x=>x.Name);
        }
        public async Task<IEnumerable<Album>> GetAllBySeries(int id)
        {
            var albs = await _context.GetAlbumsAsync();
            return albs.Where(x=>x.SerieId == id).OrderBy(x=>x.Name);
        }
        public async Task<Album> Get(int id)
        {
            return await _context.GetAlbumAsync(id);
        }
        public async Task<int> DeleteAlbumAsync(Album item)
        {
            item.SynchroStatus = SynchroStatus.Deleted;
            return await _context.SaveAlbumAsync(item);
        }
        public async Task<int> UpsertAlbumAsync(Album item)
        {
            return await _context.SaveAlbumAsync(item);
        }
    }
}
