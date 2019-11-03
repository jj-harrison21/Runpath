namespace RunpathCodingTest.WebApi.Models.Builders
{
    public class PhotoModelBuilder : IPhotoModelBuilder
    {
        public PhotoModel Build(Domain.Photo photo)
        {
            return new PhotoModel
            {
                Title = photo.Title,
                ThumbnailUrl = photo.ThumbnailUrl,
                Url = photo.Url
            };
        }
    }
}