using System.ComponentModel.DataAnnotations;

namespace GreenThumbProject.Models
{
    public class PlantModel
    {
        [Key]

        public int PlantId { get; set; }

        public string PlantName { get; set; } = null!;

        public string? PlantDescription { get; set; }
        public List<InstructionModel> Instructions { get; } = new List<InstructionModel>();

        public List<GardenPlantModel> GardenPlants { get; } = new();

    }
}
