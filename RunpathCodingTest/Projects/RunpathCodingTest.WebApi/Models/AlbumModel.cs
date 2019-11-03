using System.Collections.Generic;

namespace RunpathCodingTest.WebApi.Models
{
    public class AlbumModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public List<PhotoModel> Photos { get; set; }
    }
}
