using Bookzilla.Client.APIClient;
using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class UpSynchro : SynchroBase, IUpSynchro
    {
        public UpSynchro(BookzillaLocalDatabase context, String ApiAddress, ISettingsService settings) : base(context, ApiAddress, settings)
        {
        }
        public async Task<bool> SynchroCollectionFromServer()
        {
            try
            {
                var servercollec = await CollectionClient.CollectionGetAsync();
                foreach (var item in servercollec)
                {
                    Collection dbcollec = new Collection();
                    dbcollec.Name = item.Name;
                    dbcollec.Id = item.Id;
                    dbcollec.ImageArtPath = item.ImageArtPath;
                    await _context.SaveCollectionAsync(dbcollec);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SynchroSerieFromServer()
        {
            try
            {
                var serverserie = await SerieClient.SerieGetAsync();
                foreach (var item in serverserie)
                {
                    Serie dbserie = new Serie();
                    dbserie.Name = item.Name;
                    dbserie.Id = item.Id;
                    dbserie.CollectionId = item.CollectionId;
                    dbserie.CoverArtPath = item.CoverArtPath;
                    await _context.SaveSerieAsync(dbserie);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SynchroAlbumFromServer()
        {
            try
            {
                var serverAlbum = await AlbumClient.AlbumGetAsync();
                foreach (var item in serverAlbum)
                {
                    Album dbAlbum = new Album();
                    dbAlbum.Name = item.Name;
                    dbAlbum.Id = item.Id;
                    dbAlbum.SerieId = item.SerieId;
                    dbAlbum.CoverArtPath = item.CoverArtPath;
                    dbAlbum.CurrentPage = item.CurrentPage;
                    dbAlbum.Order = item.Order;
                    dbAlbum.Path = item.Path;
                    dbAlbum.ReadingStatus = item.ReadingStatus;
                    await _context.SaveAlbumAsync(dbAlbum);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
