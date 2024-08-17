using System.ComponentModel.DataAnnotations;

namespace INDWalks.API.Models.DTOs
{
    public class AddRegionDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Code cannot be less than 3 characters")]
        [MaxLength(3, ErrorMessage = "Code cannot be more than 3 characters")]
        public string Code { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
