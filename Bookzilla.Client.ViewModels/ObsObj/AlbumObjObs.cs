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
            get => Album.Id;
            set => SetProperty(Album.Id, value, Album, (emulator, item) => Album.Id = item);
        }
        public int SerieId
        {
            get => Album.SerieId;
            set => SetProperty(Album.SerieId, value, Album, (emulator, item) => Album.SerieId = item);
        }
        public string Name
        {
            get => Album.Name;
            set
            {
                SetProperty(Album.Name, value, Album, (emulator, item) => Album.Name = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public ReadingStatus ReadingStatus
        {
            get => Album.ReadingStatus;
            set
            {
                SetProperty(Album.ReadingStatus, value, Album, (emulator, item) => Album.ReadingStatus = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public int Order
        {
            get => Album.Order;
            set => SetProperty(Album.Order, value, Album, (emulator, item) => Album.Order = item);
        }
        public int CurrentPage
        {
            get => Album.CurrentPage;
            set => SetProperty(Album.CurrentPage, value, Album, (emulator, item) => Album.CurrentPage = item);
        }
        public string Path
        {
            get => Album.Path;
            set
            {
                SetProperty(Album.Path, value, Album, (emulator, item) => Album.Path = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string LocalPath
        {
            get => Album.LocalPath;
            set
            {
                SetProperty(Album.LocalPath, value, Album, (emulator, item) => Album.LocalPath = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string CoverArtPath
        {
            get => Album.CoverArtPath;
            set
            {
                SetProperty(Album.CoverArtPath, value, Album, (emulator, item) => Album.CoverArtPath = item);
                SynchroStatus = SynchroStatus.Changed;
            }
        }
        public string LocalCoverArtPath
        {
            get => Album.LocalCoverArtPath;
            set
            {
                SetProperty(Album.LocalCoverArtPath, value, Album, (emulator, item) => Album.LocalCoverArtPath = item);
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
        public SynchroFileStatus SynchroFileStatus
        {
            get => Album.SynchroFileStatus;
            set
            {
                SetProperty(Album.SynchroFileStatus, value, Album, (emulator, item) => Album.SynchroFileStatus = item);
            }
        }
    }
}
