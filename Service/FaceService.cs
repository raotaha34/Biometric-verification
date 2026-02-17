using Face_Recognition.Data;
using Face_Recognition.Models;
using Face_Recognition.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Face_Recognition.Service
{
    public class FaceService(ApplicationDbContext context, IHttpClientFactory httpClientFactory) : IFaceService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient();

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

        public async Task<FaceMatchResult> VerifyFaceAsync(string base64Image)
        {
            var payload = new { image = base64Image };
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5004/verify_face", payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<FaceMatchResult>() ?? new FaceMatchResult();
        }
    }
}