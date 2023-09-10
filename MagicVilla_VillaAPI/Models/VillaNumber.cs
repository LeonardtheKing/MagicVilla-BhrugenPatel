using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace MagicVilla_VillaAPI.Models
{
    public class VillaNumber
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }
        // Foreign key property
        //[ForeignKey("Villa")]
        public int VillaId { get; set; }
        // Navigation property
        public Villa Villa { get; set; } = null!;
        public string SpecialDetails { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
