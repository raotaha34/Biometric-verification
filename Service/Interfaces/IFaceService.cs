using Face_Recognition.Models;
using System.Threading.Tasks;

namespace Face_Recognition.Service.Interfaces
{
    public interface IFaceService
    {
        Task SaveImageAsync(string base64Image);
        Task<FaceMatchResult> VerifyFaceAsync(string base64Image);
    }

    public class FaceMatchResult
    {
        public bool MatchFound { get; set; }
        public int? UserId { get; set; }
        public float Confidence { get; set; }
    }
}