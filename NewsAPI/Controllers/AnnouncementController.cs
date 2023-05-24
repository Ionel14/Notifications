using Microsoft.AspNetCore.Mvc;
using NewsAPI.Model;
using NewsAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? 
                throw new ArgumentNullException(nameof(AnnouncementCollectionService));
        }

        /// <summary>
        /// Get announcements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            List<Announcement> announcements = await _announcementCollectionService.GetAll();
            return Ok(announcements);
        }


        /// <summary>
        /// Create announcements
        /// </summary>
        /// <param name="announcement"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] AnnouncementCreation announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement can not be null!");
            }
            Announcement announ = new Announcement
            {
                Id = Guid.NewGuid(),
                Author = announcement.Author,
                CategoryId = announcement.CategoryId,
                ImageUrl = announcement.ImageUrl,
                Message = announcement.Message,
                Title = announcement.Title,
            };
            await _announcementCollectionService.Create(announ);
            return Ok();
        }

        /// <summary>
        /// Update Announcement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="announcement"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement([Required]Guid id, [FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement can not be null!");
            }

            bool isUpdated = await _announcementCollectionService.Update(id, announcement);

            if (!isUpdated)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Delete Announcement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([Required] Guid id)
        {
            bool isDeleted = await _announcementCollectionService.Delete(id);

            if (!isDeleted)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("getByCategory/{categoryId}")]
        public async Task<IActionResult> GetAnnouncementsByCategory(string categoryId)
        {
            return Ok(await _announcementCollectionService.GetAnnouncementsByCategoryId(categoryId));
        }

        ///// <summary>
        ///// GET Summary
        ///// </summary>
        ///// <returns></returns>

        //[HttpGet]
        //public ActionResult GetDummy()
        //{
        //    string message = "dummy message";
        //    return Ok(message);
        //}

        ///// <summary>
        ///// POST Summary
        ///// </summary>
        ///// <returns></returns>

        //[HttpPost]
        //public ActionResult PostDummy()
        //{
        //    string message = "dummy message";
        //    return Ok(message);
        //}

        ///// <summary>
        ///// PUT Summary
        ///// </summary>
        ///// <returns></returns>

        //[HttpPut]
        //public ActionResult PutDummy()
        //{
        //    string message = "dummy message";
        //    return Ok(message);
        //}

        ///// <summary>
        ///// DELETE Summary
        ///// </summary>
        ///// <returns></returns>

        //[HttpDelete]
        //public ActionResult DeleteDummy()
        //{
        //    string message = "dummy message";
        //    return Ok(message);
        //}
    }
}
