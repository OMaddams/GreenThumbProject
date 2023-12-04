namespace GreenThumbProject.Models
{
    public class GardenPlantModel
    {
        public int GardenId { get; set; }
        public int PlantId { get; set; }
        public GardenModel Garden { get; set; } = null!;
        public PlantModel Plant { get; set; } = null!;
    }
}
