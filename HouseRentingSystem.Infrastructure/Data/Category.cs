using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HouseRentingSystem.Infrastructure.Data
{
    [Comment("House Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public List<House> Houses { get; set; } = new List<House>();
    }
}
