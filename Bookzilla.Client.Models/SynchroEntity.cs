using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Models
{
    public class SynchroEntity
    {
        public SynchroStatus SynchroStatus { get; set; } = SynchroStatus.Synchronize;
    }
}
