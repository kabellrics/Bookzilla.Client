using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class RepoCollection : RepoBase, IRepoCollection
    {
        public RepoCollection(BookzillaLocalDatabase context, ISettingsService settings) : base(context, settings)
        {
        }
        public async Task<IEnumerable<Collection>> GetAll()
        {
            return await _context.GetCollectionsAsync();
        }
        public async Task<IEnumerable<Collection>> GetAllByName(string search)
        {
            var collecs = await _context.GetCollectionsAsync();
            return collecs.Where(x => x.Name.Contains(search)).OrderBy(x => x.Name);
        }
        public async Task<IEnumerable<Collection>> GetCurrentReading()
        {
            var albs = await _context.GetAlbumsAsync();
            var readingalbs = albs.Where(x => x.ReadingStatus == ReadingStatus.EnCours);
            var seriereadingids = readingalbs.GroupBy(x => x.SerieId).Select(x => x.Key).ToList();
            var series = await _context.GetSeriesAsync();
            var readingseries = series.Where(x => seriereadingids.Any(y => y == x.Id));
            var collecreadingids = readingseries.GroupBy(x => x.CollectionId).Select(x => x.Key).ToList();
            var collecs = await _context.GetCollectionsAsync();
            return collecs.Where(x => collecreadingids.Any(y => y == x.Id));
        }
        public async Task<Collection> Get(int id)
        {
            return await _context.GetCollectionAsync(id);
        }
        public async Task<int> DeleteCollectionAsync(Collection item)
        {
            item.SynchroStatus = SynchroStatus.Deleted;
            return await _context.SaveCollectionAsync(item);
        }
        public async Task<int> UpsertCollectionAsync(Collection item)
        {
            return await _context.SaveCollectionAsync(item);
        }
    }
}
