using System.Web.Http.Results;
using Machine.Fakes;
using Machine.Specifications;

namespace RunpathCodingTest.Specs.PhotoController
{
    public class When_getting_all_photos_by_album_id_with_invalid_id : WithSubject<WebApi.Controllers.PhotoController>
    {
        static BadRequestErrorMessageResult result;

        Because of = () => result = (BadRequestErrorMessageResult)Subject.GetByAlbumId(0);

        It should_return_all_albums = () => result.Message.ShouldEqual("Invalid album id");
    }
}
