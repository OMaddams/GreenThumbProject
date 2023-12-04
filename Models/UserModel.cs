using EntityFrameworkCore.EncryptColumn.Attribute;
using System.ComponentModel.DataAnnotations;

namespace GreenThumbProject.Models
{
    public class UserModel
    {
        [Key]

        public int UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string? UserEmail { get; set; }

        [EncryptColumn]
        public string UserPassword { get; set; } = null!;

        public GardenModel? Garden { get; set; }
    }
}
