using System.ComponentModel.DataAnnotations;
    namespace Face_Recognition.Models
    {
        public class FaceImage
        {
            public int Id { get; set; }

            [Required]
            public string ImageData { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        }
    }
