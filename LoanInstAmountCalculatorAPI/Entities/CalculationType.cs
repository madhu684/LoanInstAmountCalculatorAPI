using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanInstAmountCalculatorAPI.Entities
{
    public class CalculationType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
