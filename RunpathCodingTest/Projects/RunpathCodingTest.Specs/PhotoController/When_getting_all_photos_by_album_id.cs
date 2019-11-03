using System.Collections.Generic;
using System.Web.Http.Results;
using Machine.Fakes;
using Machine.Specifications;
using RunpathCodingTest.WebApi.Models;
using RunpathCodingTest.WebApi.Services;

namespace RunpathCodingTest.Specs.PhotoController
{
    public class When_getting_all_photos_by_album_id : WithSubject<WebApi.Controllers.PhotoController>
    {
        static OkNegotiatedContentResult<List<AlbumModel>> result;
        static List<AlbumModel> expectedResult;


        private Establish context = () =>
        {
            expectedResult = new List<AlbumModel>();
            The<IPhotoService>().WhenToldTo(r => r.GetPhotosByAlbum(1)).Return(expectedResult);
        };

        Because of = () => result = (OkNegotiatedContentResult<List<AlbumModel>>)Subject.GetByAlbumId(1);

        It should_return_all_albums = () => result.Content.ShouldBeTheSameAs(expectedResult);
    }
}
