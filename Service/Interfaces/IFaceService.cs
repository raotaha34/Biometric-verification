using Face_Recognition.Models;

public interface IFaceService
{
    Task SaveImageAsync(string base64Image);
}