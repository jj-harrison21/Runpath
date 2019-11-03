using System.Collections.Generic;
using System.Linq;

namespace RunpathCodingTest.WebApi.Models.Builders
{
    public interface IAlbumModelBuilder
    {
        AlbumModel Build(Domain.Album album, List<Domain.Photo> photos);
    }
}
