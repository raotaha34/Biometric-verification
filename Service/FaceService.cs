using Face_Recognition.Data;
using Face_Recognition.Models;

namespace Face_Recognition.Service
{
    public class FaceService(ApplicationDbContext context) : IFaceService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task SaveImageAsync(string base64Image)
        {
            try
            {
                Console.WriteLine($"Received image data length: {base64Image.Length}");
                Console.WriteLine($"First 100 chars: {base64Image[..Math.Min(100, base64Image.Length)]}");
                
                var base64Data = base64Image.Split(',')[1]; // Removes "data:image/jpeg;base64,"
                Console.WriteLine($"After split, base64 data length: {base64Data.Length}");
                
                var faceImage = new FaceImage
                {
                    ImageData = base64Data,
                    CreatedAt = DateTime.Now
                };
                
                _context.FaceImages.Add(faceImage);
                await _context.SaveChangesAsync();
                
                Console.WriteLine($"Saved image with ID: {faceImage.Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
                throw;
            }
        }
    }
}