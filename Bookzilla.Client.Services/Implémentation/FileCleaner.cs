using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class FileCleaner : SynchroBase, IFileCleaner
    {
        public FileCleaner(BookzillaLocalDatabase context, string ApiAddress, ISettingsService settings) : base(context, ApiAddress, settings)
        {
        }
        public async Task Collections()
        {
            var collecs = await _context.GetCollectionsAsync();
            var newcollecs = collecs.Where(x => x.SynchroStatus == SynchroStatus.New);
            var Updatedcollecs = collecs.Where(x => x.SynchroStatus == SynchroStatus.Changed);
            var deletedcollecs = collecs.Where(x => x.SynchroStatus == SynchroStatus.Deleted);
            foreach (var item in deletedcollecs)
            {
                item.SynchroStatus = SynchroStatus.Synchronize;
                await _context.SaveCollectionAsync(item);
            }
            foreach (var item in newcollecs)
            {
                if(string.IsNullOrEmpty(item.ImageArtPath))
                    await _context.DeleteCollectionAsync(item);
            }
        }
        public async Task Series()
        {

        }
        public async Task Albums()
        {

        }
    }
}
