using Bookzilla.Client.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.ViewModels.ObsObj
{
    public class AlbumObjObs : ObservableObject
    {
        public AlbumObjObs(Album Alb) : base()
        {
            Album = Alb;
        }

        public Album Album { get; }
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
            get => Album.SynchroStatus;
            set
            {
                SetProperty(Album.SynchroStatus, value, Album, (emulator, item) => Album.SynchroStatus = item);
            }
        }
    }
}
