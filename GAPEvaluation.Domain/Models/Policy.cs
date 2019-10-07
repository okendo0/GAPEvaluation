namespace GAPEvaluation.Domain.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Policy
    {
        [Key]
        public int IdPolicy { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximun {1} and minimum {2} characters", MinimumLength = 3)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int IdCoverage { get; set; }

        [JsonIgnore]
        public virtual Coverage Coverage { get; set; }

        [JsonIgnore]
        public virtual ICollection<ClientPolicy> ClientPolicies  { get; set; }
    }
}
