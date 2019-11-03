using System;
using Machine.Fakes;
using RunpathCodingTest.Domain;

namespace RunpathCodingTest.Specs.PhotoService
{
    public class WithPhotoService : WithSubject<WebApi.Services.PhotoService>
    {
        private static Random random = new Random();

        protected static Photo BuildPhoto(int albumId)
        {
            return new Photo
            {
                AlbumId = albumId,
                Title = $"Photo {random.Next()} in {albumId}",
                ThumbnailUrl = $"Thumbnail {random.Next()}",
                Url = $"Url {random.Next()}"
            };
        }

        protected static Album BuildAlbum(int albumId, int? userId = null)
        {
            return new Album
            {
                Id = albumId,
                Title = $"Album {albumId}",
                UserId = userId ?? random.Next()
            };
        }

    }
}
