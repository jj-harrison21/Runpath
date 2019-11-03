using System;
using System.Collections.Generic;
using Machine.Fakes;
using Machine.Specifications;
using RunpathCodingTest.Domain;
using RunpathCodingTest.WebApi.Models;
using RunpathCodingTest.WebApi.Models.Builders;

namespace RunpathCodingTest.Specs.ModelBuilders
{
    public class When_building_a_photo_model : WithSubject<PhotoModelBuilder>
    {
        static PhotoModel result;
        static Photo photo;

        private Establish context = () =>
        {
            Random random = new Random();

            photo = new Photo
            {
                AlbumId = random.Next(),
                Title = "Photo Title",
                ThumbnailUrl = "Thumbnail URl",
                Url = "www.google.com"
            };
        };

        Because of = () => result = Subject.Build(photo);

        It should_map_the_photo_title = () => result.Title.ShouldEqual(photo.Title);

        It should_map_the_photo_thumbnail = () => result.ThumbnailUrl.ShouldEqual(photo.ThumbnailUrl);

        It should_map_the_photo_url = () => result.Url.ShouldEqual(photo.Url);
    }
}