using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bookzilla.Client.Services.Implémentation
{
    public class FileSynchro : SynchroBase, IFileSynchro
    {
        public FileSynchro(BookzillaLocalDatabase context, String ApiAddress, ISettingsService settings) : base(context, ApiAddress, settings)
        {            
        }
		public async Task<bool> CollectionArtPartial()
		{
			try
            {
                var collections = await _context.GetCollectionsAsync();
                var collecToSynchro = collections.Where(x => string.IsNullOrEmpty(x.LocalImageArtPath));
                DownloadCollecArt(collecToSynchro);
            }
            catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
		}
        public async Task<bool> CollectionArtFull()
		{
			try
			{
                var collections = await _context.GetCollectionsAsync();
                DownloadCollecArt(collections);
            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
        }

        private void DownloadCollecArt(IEnumerable<Collection> collecToSynchro)
        {
            foreach (var item in collecToSynchro)
            {
                //DownloadFile In Correct Folder
            }
        }
        public async Task<bool> SeriesArtPartial()
		{
			try
            {
                var series = await _context.GetSeriesAsync();
                var seriesToSynchro = series.Where(x => string.IsNullOrEmpty(x.LocalCoverArtPath));
                DownloadSerieArt(seriesToSynchro);
            }
            catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
		}
        public async Task<bool> SeriesArtFull()
		{
			try
            {
                var series = await _context.GetSeriesAsync();
                DownloadSerieArt(series);

            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
        }

        private void DownloadSerieArt(IEnumerable<Serie> seriesToSynchro)
        {
            foreach (var item in seriesToSynchro)
            {
                //DownloadFile In Correct Folder
            }
        }
        public async Task<bool> CoverFilePartial()
		{
			try
			{
                var albums = await _context.GetAlbumsAsync();
                var albumsToSynchro = albums.Where(x => string.IsNullOrEmpty(x.LocalCoverArtPath));
                DownloadCoverArt(albumsToSynchro);
            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
		}
		public async Task<bool> CoverFileFull()
		{
			try
            {
                var albums = await _context.GetAlbumsAsync();
                DownloadCoverArt(albums);
            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
        }
        private void DownloadCoverArt(IEnumerable<Album> albumsToSynchro)
        {
            foreach (var item in albumsToSynchro)
            {
                //DownloadFile In Correct Folder
            }
        }
        public async Task<bool> FilePartial()
		{
			try
            {
                    var albums = await _context.GetAlbumsAsync();
                    var albumsToSynchro = albums.Where(x => string.IsNullOrEmpty(x.LocalPath) && x.SynchroFileStatus == SynchroFileStatus.Local);
                DownloadFileArt(albumsToSynchro);
            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
		}
		public async Task<bool> FileFull()
		{
			try
			{
                    var albums = await _context.GetAlbumsAsync();
                var albumsToSynchro = albums.Where(x => x.SynchroFileStatus == SynchroFileStatus.Local);
                DownloadFileArt(albumsToSynchro);
            }
			catch (Exception ex)
			{
				return false;
				//throw;
			}
			return true;
        }
        private void DownloadFileArt(IEnumerable<Album> albumsToSynchro)
        {
            foreach (var item in albumsToSynchro)
            {
                //DownloadFile In Correct Folder
            }
        }
    }
}
