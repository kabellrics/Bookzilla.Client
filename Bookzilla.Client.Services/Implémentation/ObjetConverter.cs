using Bookzilla.Client.APIClient;
using Bookzilla.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public static class ObjetConverter
    {
        public static Collection ApiToDb(ApiCollection apiCollection)
        {
            return new Collection()
            {
                Name = apiCollection.Name,
                Id = apiCollection.Id,
                ImageArtPath = apiCollection.ImageArtPath
            };
        }
        public static ApiCollection DbToApi(Collection collection)
        {
            return new ApiCollection()
            {
                Name = collection.Name,
                Id = collection.Id,
                ImageArtPath = collection.ImageArtPath
            };
        }
        public static Serie ApiToDb(APISerie item)
        {
            return new Serie()
            {
                Name = item.Name,
                Id = item.Id,
                CollectionId = item.CollectionId,
                CoverArtPath = item.CoverArtPath
            };
        }
        public static APISerie DbToApi(Serie item)
        {
            return new APISerie()
            {
                Name = item.Name,
                Id = item.Id,
                CollectionId = item.CollectionId,
                CoverArtPath = item.CoverArtPath
            };
        }
        public static Album ApiToDb(ApiAlbum item)
        {
            return new Album()
            {
                Name = item.Name,
                Id = item.Id,
                SerieId = item.SerieId,
                CoverArtPath = item.CoverArtPath,
                CurrentPage = item.CurrentPage,
                Order = item.Order,
                Path = item.Path,
                ReadingStatus = item.ReadingStatus,
            };
        }
        public static ApiAlbum DbToApi(Album item)
        {
            return new ApiAlbum()
            {
                Name = item.Name,
                Id = item.Id,
                SerieId = item.SerieId,
                CoverArtPath = item.CoverArtPath,
                CurrentPage = item.CurrentPage,
                Order = item.Order,
                Path = item.Path,
                ReadingStatus = item.ReadingStatus
            };
        }
    }
}
