using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class DownSynchro : SynchroBase, IDownSynchro
    {
        public DownSynchro(BookzillaLocalDatabase context, String ApiAddress) : base(context, ApiAddress)
        {
        }
        public async Task<bool> SynchroCollectionToServer()
        {
            try
            {
                await Task.Run(async () => await ToServerDeleteCollection());
                await Task.Run(async () => await ToServerUpdateCollection());
                await Task.Run(async () => await ToServerNewCollection());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private async Task ToServerDeleteCollection()
        {
            var collecs = await _context.GetCollectionsAsync();
            var ToDeleteCollec = collecs.Where(x => x.SynchroStatus == SynchroStatus.Deleted);
            foreach (var col in ToDeleteCollec)
            {
                await CollectionClient.CollectionDeleteAsync(col.Id);
                await _context.DeleteCollectionAsync(col);
            }
        }
        private async Task ToServerDeleteSerie()
        {
            var Series = await _context.GetSeriesAsync();
            var ToDeleteSerie = Series.Where(x => x.SynchroStatus == SynchroStatus.Deleted);
            foreach (var ser in ToDeleteSerie)
            {
                await SerieClient.SerieDeleteAsync(ser.Id);
                await _context.DeleteSerieAsync(ser);
            }
        }
        private async Task ToServerDeleteAlbum()
        {
            var Albums = await _context.GetAlbumsAsync();
            var ToDeleteAlbum = Albums.Where(x => x.SynchroStatus == SynchroStatus.Deleted);
            foreach (var ser in ToDeleteAlbum)
            {
                await AlbumClient.AlbumDeleteAsync(ser.Id);
                await _context.DeleteAlbumAsync(ser);
            }
        }
        private async Task ToServerUpdateCollection()
        {
            var collecs = await _context.GetCollectionsAsync();
            var ToUpdateCollec = collecs.Where(x => x.SynchroStatus == SynchroStatus.Changed);
            foreach (var col in ToUpdateCollec)
            {
                await CollectionClient.CollectionPutAsync(col.Id,ObjetConverter.DbToApi(col));
                await _context.SaveCollectionAsync(col);
            }
        }
        private async Task ToServerUpdateSerie()
        {
            var Series = await _context.GetSeriesAsync();
            var ToUpdateSerie = Series.Where(x => x.SynchroStatus == SynchroStatus.Changed);
            foreach (var col in ToUpdateSerie)
            {
                await SerieClient.SeriePutAsync(col.Id,ObjetConverter.DbToApi(col));
                await _context.SaveSerieAsync(col);
            }
        }
        private async Task ToServerUpdateAlbum()
        {
            var Albums = await _context.GetAlbumsAsync();
            var ToUpdateAlbum = Albums.Where(x => x.SynchroStatus == SynchroStatus.Changed);
            foreach (var col in ToUpdateAlbum)
            {
                await AlbumClient.AlbumPutAsync(col.Id,ObjetConverter.DbToApi(col));
                await _context.SaveAlbumAsync(col);
            }
        }
        private async Task ToServerNewCollection()
        {
            var collecs = await _context.GetCollectionsAsync();
            var ToCreateCollec = collecs.Where(x => x.SynchroStatus == SynchroStatus.New);
            foreach (var col in ToCreateCollec)
            {
                await CollectionClient.CollectionPostAsync(ObjetConverter.DbToApi(col));
                await _context.SaveCollectionAsync(col);
            }
        }
        private async Task ToServerNewSerie()
        {
            var Series = await _context.GetSeriesAsync();
            var ToCreateSerie = Series.Where(x => x.SynchroStatus == SynchroStatus.New);
            foreach (var col in ToCreateSerie)
            {
                await SerieClient.SeriePostAsync(ObjetConverter.DbToApi(col));
                await _context.SaveSerieAsync(col);
            }
        }
        private async Task ToServerNewAlbum()
        {
            var Albums = await _context.GetAlbumsAsync();
            var ToCreateAlbum = Albums.Where(x => x.SynchroStatus == SynchroStatus.New);
            foreach (var col in ToCreateAlbum)
            {
                await AlbumClient.AlbumPostAsync(ObjetConverter.DbToApi(col));
                await _context.SaveAlbumAsync(col);
            }
        }

        public async Task<bool> SynchroSerieToServer()
        {
            try
            {
                await Task.Run(async () => await ToServerDeleteSerie());
                await Task.Run(async () => await ToServerUpdateSerie());
                await Task.Run(async () => await ToServerNewSerie());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SynchroAlbumToServer()
        {
            try
            {
                await Task.Run(async () => await ToServerDeleteAlbum());
                await Task.Run(async () => await ToServerUpdateAlbum());
                await Task.Run(async () => await ToServerNewAlbum());
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
