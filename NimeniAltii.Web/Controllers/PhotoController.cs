using BlogLab.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NimeniAltii.Models.Photo;
using NimeniAltiiLab.Repository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace NimeniAltii.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IPhotoService _photoService;

        public PhotoController(
            IPhotoRepository photoRepository,
            IBlogRepository blogRepository,
            IPhotoService photoService)
        {
            _photoRepository = photoRepository;
            _blogRepository = blogRepository;
            _photoService = photoService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Photo>> UploadPhoto(IFormFile file)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var uploadResult = await _photoService.AddPhotoAsync(file);

            if (uploadResult.Error != null) return BadRequest(uploadResult.Error.Message);

            var photoCreate = new PhotoCreate
            {
                PublicId = uploadResult.PublicId,
                ImageUrl = uploadResult.SecureUrl.AbsoluteUri,
                Description = file.FileName
            };

            var photo = await _photoRepository.InsertAsync(photoCreate, applicationUserId);

            return Ok(photo);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Photo>>> GetByApplicationUserId()
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var photos = await _photoRepository.GetAllByUserIdAsync(applicationUserId);

            return Ok(photos);
        }

        [HttpGet("{photoId}")]
        public async Task<ActionResult<Photo>> Get(int photoId)
        {
            var photo = await _photoRepository.GetAsync(photoId);

            return Ok(photo);
        }

        [Authorize]
        [HttpDelete("{photoId}")]
        public async Task<ActionResult<int>> Delete(int photoId)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundPhoto = await _photoRepository.GetAsync(photoId);

            if (foundPhoto != null)
            {
                if (foundPhoto.ApplicationUserId == applicationUserId)
                {
                    var blogs = await _blogRepository.GetAllByUserIdAsync(applicationUserId);

                    var usedInBlog = blogs.Any(b => b.PhotoId == photoId);

                    if (usedInBlog) return BadRequest("Nu poti sterge aceasta imagine.");

                    var deleteResult = await _photoService.DeletePhotoAsync(foundPhoto.PublicId);

                    if (deleteResult.Error != null) return BadRequest(deleteResult.Error.Message);

                    var affectRows = await _photoRepository.DeleteAsync(foundPhoto.PhotoId);

                    return Ok(affectRows);
                } 
                else 
                {
                    return BadRequest("Imaginea nu a fost incarcata de utilizatorul curent.");
                }
            }

            return BadRequest("Imaginea nu exista.");
        }


    }
}
