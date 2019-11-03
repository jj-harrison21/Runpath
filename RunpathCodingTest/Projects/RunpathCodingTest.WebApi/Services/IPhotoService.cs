using System.Collections.Generic;
using RunpathCodingTest.WebApi.Models;

namespace RunpathCodingTest.WebApi.Services
{
    public interface IPhotoService
    {
        IEnumerable<AlbumModel> GetAllPhotos();

        IList<AlbumModel> GetPhotosByUser(int userId);

        List<AlbumModel> GetPhotosByAlbum(int albumId);
    }
}
