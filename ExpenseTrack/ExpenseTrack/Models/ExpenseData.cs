using System.ComponentModel.DataAnnotations;

namespace ExpenseTrack.Models
{
    public class ExpenseData
    {
        public int Id { get; set; }  

        public decimal Value { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
