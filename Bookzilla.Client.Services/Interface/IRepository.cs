namespace Bookzilla.Client.Services.Interface
{
    public interface IRepository
    {
        IRepoAlbum Albums { get; }
        IRepoCollection Collections { get; }
        IRepoSeries Series { get; }
    }
}