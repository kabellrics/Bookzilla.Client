using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class RepoBase
    {
        protected BookzillaLocalDatabase _context;
        protected ISettingsService _settings;
        public RepoBase(BookzillaLocalDatabase context,  ISettingsService settings)
        {
            _context = context;
            _settings = settings;
        }
    }
}
