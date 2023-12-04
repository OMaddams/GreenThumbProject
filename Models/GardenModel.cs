using System.ComponentModel.DataAnnotations;

namespace GreenThumbProject.Models
{
    public class GardenModel
    {
        [Key]

        public int GardenId { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; } = null!;

        public List<GardenPlantModel> GardenPlant { get; } = new();

    }
}
