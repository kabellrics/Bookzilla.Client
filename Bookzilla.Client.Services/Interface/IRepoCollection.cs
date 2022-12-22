using Bookzilla.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Interface
{
    public interface IRepoCollection
    {
        Task<IEnumerable<Collection>> GetAll();
        Task<IEnumerable<Collection>> GetAllByName(string search);
        Task<Collection> Get(int id);
        Task<int> DeleteCollectionAsync(Collection item);
        Task<int> UpsertCollectionAsync(Collection item);
    }
}
