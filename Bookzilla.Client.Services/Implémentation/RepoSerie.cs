using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class RepoSerie : RepoBase, IRepoSeries
    {
        public RepoSerie(BookzillaLocalDatabase context, ISettingsService settings) : base(context, settings)
        {
        }
        public async Task<IEnumerable<Serie>> GetAll()
        {
            return await _context.GetSeriesAsync();
        } 
        public async Task<IEnumerable<Serie>> GetAllByName(string search)
        {
            var series = await _context.GetSeriesAsync();
            return series.Where(x => x.Name.Contains(search)).OrderBy(x => x.Name);
        } 
        public async Task<IEnumerable<Serie>> GetAllByCollec(int id)
        {
            var series = await _context.GetSeriesAsync();
            return series.Where(x => x.CollectionId == id).OrderBy(x => x.Name);
        } 
        public async Task<Serie> Get(int id)
        {
            return await _context.GetSerieAsync(id);
        }
        public async Task<int> DeleteSerieAsync(Serie item)
        {
            return await _context.DeleteSerieAsync(item);
        }
        public async Task<int> UpsertSerieAsync(Serie item)
        {
            return await _context.SaveSerieAsync(item);
        }
    }
}
