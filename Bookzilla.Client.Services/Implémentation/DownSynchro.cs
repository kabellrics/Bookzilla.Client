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

        public async Task<bool> SynchroSerieToServer() { }
        public async Task<bool> SynchroAlbumToServer() { }
    }
}
