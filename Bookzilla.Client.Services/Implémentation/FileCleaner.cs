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
        public async Task Collections() { }
        public async Task Series() { }
        public async Task Albums() { }
    }
}
