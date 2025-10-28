using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BZ_WebMobileTemplate.Shared.Data
{
    [Table("UPRO_S_Function", Schema = "dbo")]
    public class UPRO_S_Function
    {
        [Key]
        [Column("FunctionID")]
        public int FunctionId { get; set; }

        [Column("FunctionName")]
        [StringLength(255)] // Adjust based on actual varchar length
        public string? FunctionName { get; set; }

        [Column("Description")]
        [StringLength(255)] // Adjust based on actual varchar length
        public string? Description { get; set; }
    }
}
