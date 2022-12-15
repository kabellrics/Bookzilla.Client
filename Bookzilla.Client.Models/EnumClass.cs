using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Models
{
    public class EnumClass
    {
    }
    public enum ReadingStatus
    {
        NonLu,
        EnCours,
        Lu
    }
    public enum SynchroStatus
    {
        New,
        Changed,
        Deleted,
        Synchronize
    }
    public enum SynchroFileStatus
    {
        Temp,
        Local,
        None
    }
}
