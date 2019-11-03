using System.Web.Http;
using RunpathCodingTest.WebApi.Services;

namespace RunpathCodingTest.WebApi.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        //get all albums and photos

        [Route("GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var photos = _photoService.GetAllPhotos();
            return Ok(photos);
        }

        //get photos for a specific album
        [Route("GetByAlbumId/{id}")]
        [HttpGet]
        public IHttpActionResult GetByAlbumId(int id)
        {
            if (id < 1)
                return BadRequest("Invalid album id");

            var photos = _photoService.GetPhotosByAlbum(id);
            return Ok(photos);
        }

        //get photos for a specific user
        [Route("GetByUserId/{id}")]
        [HttpGet]
        public IHttpActionResult GetByUserId(int id)
        {
            if (id < 1)
                return BadRequest("Invalid user id");

            var photos = _photoService.GetPhotosByUser(id);
            return Ok(photos);
        }
    }
}
