using Bookzilla.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IRepoSeries
    {
        Task<IEnumerable<Serie>> GetAll();
        Task<IEnumerable<Serie>> GetAllByName(string search);
        Task<IEnumerable<Serie>> GetAllByCollec(int id);
        Task<Serie> Get(int id);
        Task<int> DeleteSerieAsync(Serie item);
        Task<int> UpsertSerieAsync(Serie item);
    }
}
