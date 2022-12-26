using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Bookzilla.Client.Models;

namespace Bookzilla.Client.ViewModels.ObsObj
{
    public class CollectionObjObs : ObservableObject
    {
        public CollectionObjObs(Collection Col) : base()
        {
            Collection = Col;
        }

        public Collection Collection { get; }
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
        public string ImageArtPath
        {
            get => Collection.ImageArtPath;
            set
            {
                SetProperty(Collection.ImageArtPath, value, Collection, (emulator, item) => Collection.ImageArtPath = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string LocalImageArtPath
        {
            get => Collection.LocalImageArtPath;
            set
            {
                SetProperty(Collection.LocalImageArtPath, value, Collection, (emulator, item) => Collection.LocalImageArtPath = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public SynchroStatus SynchroStatus
        {
            get => Collection.SynchroStatus;
            set
            {
                SetProperty(Collection.SynchroStatus, value, Collection, (emulator, item) => Collection.SynchroStatus = item);
            }
        }
    }
}
