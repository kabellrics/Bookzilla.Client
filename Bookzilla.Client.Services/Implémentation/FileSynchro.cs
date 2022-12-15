using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class FileSynchro : SynchroBase, IFileSynchro
    {
        public FileSynchro(BookzillaLocalDatabase context, String ApiAddress) : base(context, ApiAddress)
        {
        }
    }
}
