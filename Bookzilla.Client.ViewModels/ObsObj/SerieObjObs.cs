using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Bookzilla.Client.Models;

namespace Bookzilla.Client.ViewModels.ObsObj
{
    public class SerieObjObs : ObservableObject
    {
        public SerieObjObs(Serie Ser) : base()
        {
            Serie = Ser;
        }

        public Serie Serie { get; }
        public int Id
        {
            get => Collection.Id;
            set => SetProperty(Collection.Id, value, Collection, (emulator, item) => Collection.Id = item);
        }
        public string Name
        {
            get => Collection.Name;
            set
            {
                SetProperty(Collection.Name, value, Collection, (emulator, item) => Collection.Name = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public SynchroStatus SynchroStatus
        {
            get => Serie.SynchroStatus;
            set
            {
                SetProperty(Serie.SynchroStatus, value, Serie, (emulator, item) => Serie.SynchroStatus = item);
            }
        }
    }
}
