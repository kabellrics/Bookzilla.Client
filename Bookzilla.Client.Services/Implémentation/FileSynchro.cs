using Bookzilla.Client.Models;
using Bookzilla.Client.Services.Interface;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Bookzilla.Client.Services.Implémentation
{
    public class FileSynchro : SynchroBase, IFileSynchro
    {
        private readonly string CollecArtFolder = "CollecArt";
        private readonly string SerieArtFolder = "SerieArt";
        private readonly string CoverFolder = "Cover";
        private readonly string FileFolder = "File";
        public FileSynchro(BookzillaLocalDatabase context, String ApiAddress, ISettingsService settings) : base(context, ApiAddress, settings)
        {
            
        }

        private string GetLocalPath(string Folder, string file)
        {
            return Path.Combine(_settings.BookzillaFolder, Folder, file);
        }
        private String GetLocalCollecArtPath(string filepath)
        {
            return GetLocalPath(CollectionArtFolder, Path.GetFileName(filepath));
        }
        private String GetLocalSerieArtPath(string filepath)
        {
            return GetLocalPath(SerieArtFolder, Path.GetFileName(filepath));
        }
        private String GetLocalCoverPath(string filepath)
        {
            return GetLocalPath(CoverFolder, Path.GetFileName(filepath));
        }
        private String GetLocalFilePath(string filepath)
        {
            return GetLocalPath(FileFolder, Path.GetFileName(filepath));
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
        private string CreateLocalCollecArtPath( string filepath)
        {
            return CreateLocalPath(CollecArtFolder,Path.GetFileName(filepath));
        }
        private string CreateLocalSerieArtPath( string filepath)
        {
            return CreateLocalPath(SerieArtFolder, Path.GetFileName(filepath));
        }
        private string CreateLocalCoverPath( string filepath)
        {
            return CreateLocalPath(CoverFolder, Path.GetFileName(filepath));
        }
        private string CreateLocalFilePath( string filepath)
        {
            return CreateLocalPath(FileFolder, Path.GetFileName(filepath));
        }
        private string CreateLocalPath(string folder,string filepath)
        {
            return Path.Combine(_settings.BookzillaFolder, folder,filepath);
        }
        private async void DownloadCoverArt(IEnumerable<Album> albumsToSynchro)
        {
            foreach (var item in albumsToSynchro)
            {
                //DownloadFile In Correct Folder
                using(var httpClient = new HttpClient())
                {
                    var uri = Path.Combine(_settings.BookzillaApiEndpoint, item.CoverArtPath);
                    var outputPath = CreateLocalCoverPath(item.CoverArtPath);
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(uri);
                    File.WriteAllBytes(outputPath, fileBytes);
                }
            }
        }

        private async void DownloadSerieArt(IEnumerable<Serie> seriesToSynchro)
        {
            foreach (var item in seriesToSynchro)
            {
                //DownloadFile In Correct Folder
                using (var httpClient = new HttpClient())
                {
                    var uri = Path.Combine(_settings.BookzillaApiEndpoint, item.CoverArtPath);
                    var outputPath = CreateLocalSerieArtPath(item.CoverArtPath);
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(uri);
                    File.WriteAllBytes(outputPath, fileBytes);
                }
            }
        }
        private async void DownloadCollecArt(IEnumerable<Collection> collecToSynchro)
        {
            foreach (var item in collecToSynchro)
            {
                //DownloadFile In Correct Folder
                using (var httpClient = new HttpClient())
                {
                    var uri = Path.Combine(_settings.BookzillaApiEndpoint, item.ImageArtPath);
                    var outputPath = CreateLocalCollecArtPath(item.ImageArtPath);
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(uri);
                    File.WriteAllBytes(outputPath, fileBytes);
                }
            }
        }
        private async void DownloadFileArt(IEnumerable<Album> albumsToSynchro)
        {
            foreach (var item in albumsToSynchro)
            {
                //DownloadFile In Correct Folder
                using (var httpClient = new HttpClient())
                {
                    var uri = Path.Combine(_settings.BookzillaApiEndpoint, item.Path);
                    var outputPath = CreateLocalFilePath(item.Path);
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(uri);
                    File.WriteAllBytes(outputPath, fileBytes);
                }
            }
        }
    }
}
