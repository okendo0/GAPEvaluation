namespace GAPEvaluation.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Policy
    {
        [Key]
        public int IdPolicy { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
