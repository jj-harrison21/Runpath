using System;
using System.Collections.Generic;
using Machine.Fakes;
using Machine.Specifications;
using RunpathCodingTest.Domain;
using RunpathCodingTest.WebApi.Models;
using RunpathCodingTest.WebApi.Models.Builders;

namespace RunpathCodingTest.Specs.ModelBuilders
{
    public class When_building_an_album_model : WithSubject<AlbumModelBuilder>
    {
        static AlbumModel result;
        static Album album;
        static List<Photo> photos;

        private Establish context = () =>
        {
            Random random = new Random();

            album = new Album
            {
                Id = random.Next(),
                Title = "album Title",
                UserId = random.Next()
            };

            photos = new List<Photo>
            {
                new Photo{ AlbumId = album.Id },
                new Photo{ AlbumId = album.Id }
            };

            The<IPhotoModelBuilder>().WhenToldTo(x => x.Build(Param.IsAny<Photo>())).Return(new PhotoModel());
        };

        Because of = () => result = Subject.Build(album, photos);

        It should_map_the_album_id = () => result.Id.ShouldEqual(album.Id);

        It should_map_the_album_title = () => result.Title.ShouldEqual(album.Title);

        It should_map_the_album_user_id = () => result.UserId.ShouldEqual(album.UserId);

        It should_map_the_album_photos = () => result.Photos.Count.ShouldEqual(photos.Count);
    }
}