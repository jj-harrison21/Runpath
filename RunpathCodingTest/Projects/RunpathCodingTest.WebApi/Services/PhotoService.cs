using System.Collections.Generic;
using System.Linq;
using RunpathCodingTest.Configuration;
using RunpathCodingTest.WebApi.HttpClient;
using RunpathCodingTest.WebApi.Models;
using RunpathCodingTest.WebApi.Models.Builders;

namespace RunpathCodingTest.WebApi.Services
{
    public class PhotoService : IPhotoService
    {
        readonly IPhotoRequestor _httpClientRequestor;
        readonly IAlbumModelBuilder _albumModelBuilder;

        public PhotoService(IPhotoRequestor httpClientRequestor, IAlbumModelBuilder albumModelBuilder)
        {
            this._httpClientRequestor = httpClientRequestor;
            this._albumModelBuilder = albumModelBuilder;
        }

        public IEnumerable<AlbumModel> GetAllPhotos()
        {
            var albums = _httpClientRequestor.GetRequest<List<Domain.Album>>(ApiSettings.Settings.AlbumUrl);
            var photos = _httpClientRequestor.GetRequest<List<Domain.Photo>>(ApiSettings.Settings.PhotoUrl);

            var albumModels = albums
                                .Select(x => _albumModelBuilder.Build(x, photos.Where(p => p.AlbumId == x.Id).ToList()));

            return albumModels;
        }

        public IList<AlbumModel> GetPhotosByUser(int userId)
        {
            var albums = _httpClientRequestor.GetRequest<List<Domain.Album>>(ApiSettings.Settings.AlbumUrl);
            var photos = _httpClientRequestor.GetRequest<List<Domain.Photo>>(ApiSettings.Settings.PhotoUrl);

            var albumModels = albums
                                .Where(a => a.UserId == userId)
                                .Select(x => _albumModelBuilder.Build(x, photos.Where(p => p.AlbumId == x.Id).ToList()));

            return albumModels.ToList();
        }

        public List<AlbumModel> GetPhotosByAlbum(int albumId)
        {
            var albums = _httpClientRequestor.GetRequest<List<Domain.Album>>(ApiSettings.Settings.AlbumUrl);
            var photos = _httpClientRequestor.GetRequest<List<Domain.Photo>>(ApiSettings.Settings.PhotoUrl);

            var albumModels = albums
                                .Where(a => a.Id == albumId)
                                .Select(x => _albumModelBuilder.Build(x, photos.Where(p => p.AlbumId == x.Id).ToList()));

            return albumModels.ToList();
        }
    }
}