using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Models
{
    public static class Constants
    {
        public const string DatabaseFilename = "bookzillaLocal.db3";

        public const SqlByte.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
    public class BookzillaLocalDatabase
    {
        SQLiteAsyncConnection Database;

        public BookzillaLocalDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var resultcollec = await Database.CreateTableAsync<Collection>();
            var resultserie = await Database.CreateTableAsync<Serie>();
            var resultalbum = await Database.CreateTableAsync<Album>();
        }

        #region Collection
        public async Task<List<Collection>> GetCollectionsAsync()
        {
            await Init();
            return await Database.Table<Collection>().ToListAsync();
        }

        public async Task<Collection> GetCollectionAsync(int id)
        {
            await Init();
            return await Database.Table<Collection>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveCollectionAsync(Collection item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteCollectionAsync(Collection item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        #endregion
        #region Serie
        public async Task<List<Serie>> GetSeriesAsync()
        {
            await Init();
            return await Database.Table<Serie>().ToListAsync();
        }

        public async Task<Serie> GetSerieAsync(int id)
        {
            await Init();
            return await Database.Table<Serie>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveSerieAsync(Serie item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteSerieAsync(Serie item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        #endregion
        #region Album
        public async Task<List<Album>> GetAlbumsAsync()
        {
            await Init();
            return await Database.Table<Album>().ToListAsync();
        }

        public async Task<Album> GetAlbumAsync(int id)
        {
            await Init();
            return await Database.Table<Album>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveAlbumAsync(Album item)
        {
            await Init();
            if (item.Id != 0)
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteAlbumAsync(Album item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        #endregion

    }
}
