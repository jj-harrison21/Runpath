using System.Collections.Generic;
using System.Linq;

namespace RunpathCodingTest.WebApi.Models.Builders
{
    public class AlbumModelBuilder : IAlbumModelBuilder
    {
        private readonly IPhotoModelBuilder _photoModelBuilder;

        public AlbumModelBuilder(IPhotoModelBuilder photoModelBuilder)
        {
            this._photoModelBuilder = photoModelBuilder;
        }

        public AlbumModel Build(Domain.Album album, List<Domain.Photo> photos)
        {
            return new AlbumModel
            {
                Id = album.Id,
                Title = album.Title,
                UserId = album.UserId,
                Photos = photos.Select(x => _photoModelBuilder.Build(x)).ToList()
            };
        }
    }
}