using System.Collections.Generic;
using System.Web.Http.Results;
using Machine.Fakes;
using Machine.Specifications;
using RunpathCodingTest.WebApi.Models;
using RunpathCodingTest.WebApi.Services;

namespace RunpathCodingTest.Specs.PhotoController
{
    public class When_getting_all_photos : WithSubject<WebApi.Controllers.PhotoController>
    {
        static OkNegotiatedContentResult<IEnumerable<AlbumModel>> result;
        static List<AlbumModel> expectedResult;


        private Establish context = () =>
        {
            expectedResult = new List<AlbumModel>();
            The<IPhotoService>().WhenToldTo(r => r.GetAllPhotos()).Return(expectedResult);
        };

        Because of = () => result = (OkNegotiatedContentResult<IEnumerable<AlbumModel>>)Subject.GetAll();

        It should_return_all_albums = () => result.Content.ShouldBeTheSameAs(expectedResult);
    }
}
