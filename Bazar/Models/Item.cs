using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Bazar.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] MainImage { get; set; }
        public bool Sold { get; set; } = false;
        public DateTime Added { get; set; }
        public virtual string AddedByUser { get; set; }
        public virtual IdentityUser? IdentityUser { get; set; }


    }
}
