using Microsoft.EntityFrameworkCore;
using Face_Recognition.Models;

namespace Face_Recognition.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<FaceImage> FaceImages { get; set; }
    }
}
