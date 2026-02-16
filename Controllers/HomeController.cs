using Face_Recognition.Models;
using Microsoft.AspNetCore.Mvc;
using Face_Recognition.Data;
using Microsoft.EntityFrameworkCore;

namespace Face_Recognition.Controllers
{
    public class HomeController(ApplicationDbContext context, IFaceService faceService) : Controller
    {
        private readonly IFaceService _faceService = faceService;
        private readonly ApplicationDbContext _context = context;
    
        // Index page (optional homepage)
        public IActionResult Index()
        {
            return View();
        }

        // Page to take picture from webcam
        public IActionResult TakePicture()
        {
            return View();
        }

        // Save captured image from front-end
        [HttpPost]
        public async Task<IActionResult> SaveImage([FromBody] ImageDto model)
        {
            if (model == null || string.IsNullOrEmpty(model.Image))
                return BadRequest("No image data received");

            await _faceService.SaveImageAsync(model.Image);
            return Json(new { success = true });
        }

        // Gallery to show all stored images
        public async Task<IActionResult> Gallery()
        {
            var images = await _context.FaceImages
                                       .OrderByDescending(f => f.CreatedAt)
                                       .ToListAsync();
            return View(images);
        }

        // Biometric login page
        public IActionResult BiometricLogin()
        {
            return View();
        }
    }
}