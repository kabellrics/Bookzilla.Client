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
            get => Serie.Id;
            set => SetProperty(Serie.Id, value, Serie, (emulator, item) => Serie.Id = item);
        }
        public int CollectionId
        {
            get => Serie.CollectionId;
            set => SetProperty(Serie.CollectionId, value, Serie, (emulator, item) => Serie.CollectionId = item);
        }
        public string Name
        {
            get => Serie.Name;
            set
            {
                SetProperty(Serie.Name, value, Serie, (emulator, item) => Serie.Name = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string CoverArtPath
        {
            get => Serie.CoverArtPath;
            set
            {
                SetProperty(Serie.CoverArtPath, value, Serie, (emulator, item) => Serie.CoverArtPath = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string LocalCoverArtPath
        {
            get => Serie.LocalCoverArtPath;
            set
            {
                SetProperty(Serie.LocalCoverArtPath, value, Serie, (emulator, item) => Serie.LocalCoverArtPath = item);
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
