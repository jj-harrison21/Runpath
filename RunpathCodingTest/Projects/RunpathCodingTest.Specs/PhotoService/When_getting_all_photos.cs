using System.Collections.Generic;
using System.Linq;
using Machine.Fakes;
using Machine.Specifications;
using RunpathCodingTest.Domain;
using RunpathCodingTest.WebApi.HttpClient;
using RunpathCodingTest.WebApi.Models.Builders;

namespace RunpathCodingTest.Specs.PhotoService
{
    public class When_getting_all_photos : WithPhotoService
    {
        static List<Photo> photos;
        static List<Album> albums;

        static IEnumerable<WebApi.Models.AlbumModel> result;

        private Establish context = () =>
        {
            albums = new List<Album> { BuildAlbum(1), BuildAlbum(2) };
            photos = new List<Photo>
            {
                BuildPhoto(1), BuildPhoto(1), BuildPhoto(1),
                BuildPhoto(2), BuildPhoto(2),
            };

            The<IPhotoRequestor>().WhenToldTo(r => r.GetRequest<List<Photo>>("photos")).Return(photos);
            The<IPhotoRequestor>().WhenToldTo(r => r.GetRequest<List<Album>>("albums")).Return(albums);

            Configure<IPhotoModelBuilder, PhotoModelBuilder>();
            Configure<IAlbumModelBuilder, AlbumModelBuilder>();
        };

        Because of = () => result = Subject.GetAllPhotos();

        It should_return_all_albums = () => result.ToList().Count.ShouldEqual(albums.Count);

        It should_return_all_photos_for_each_album = () =>
        {
            result.First().Photos.Count().ShouldEqual(3);
            result.Last().Photos.Count().ShouldEqual(2);
        };
    }
}
