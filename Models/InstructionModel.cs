using System.ComponentModel.DataAnnotations;

namespace GreenThumbProject.Models
{
    public class InstructionModel
    {
        [Key]

        public int InstructionId { get; set; }

        public string InstructionDescription { get; set; } = null!;

        public int PlantId { get; set; }
        public PlantModel Plant { get; set; } = null!;

        public override string ToString()
        {
            return InstructionDescription;
        }
    }
}
