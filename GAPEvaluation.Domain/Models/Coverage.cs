namespace GAPEvaluation.Domain.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Coverage
    {
        [Key]
        public int IdCoverage { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximun {1} and minimum {2} characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float CoveragePct { get; set; }

        [JsonIgnore]
        public virtual ICollection<Policy> Policies { get; set; }

    }
}
