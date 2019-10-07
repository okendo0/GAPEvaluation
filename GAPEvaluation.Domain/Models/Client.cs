namespace GAPEvaluation.Domain.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [MaxLength(20)]
        [Display(Name = "Nùmero de Identificación", AutoGenerateFilter = false)]
        public string IdNumber { get; set; }

        [MaxLength(30)]
        [Display(Name = "First Name", AutoGenerateFilter = false)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximun {1} and minimum {2} characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Display(Name = "Last Name", AutoGenerateFilter = false)]
        [StringLength(30, ErrorMessage = "The field {0} can contain maximun {1} and minimum {2} characters", MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        [JsonIgnore]
        public virtual ICollection<ClientPolicy> ClientPolicies { get; set; }
    }
}
