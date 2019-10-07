namespace GAPEvaluation.Domain.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class ClientPolicy
    {
        [Key]
        public int IdClientPolicy { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int IdClient { get; set; }

        [Required]
        [Display(Name = "Tipo de Póliza")]
        public int IdPolicy { get; set; }

        [Required]
        [Display(Name = "Tipo de Riesgo")]
        public int IdRiskType { get; set; }

        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float CoveragePct { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }

        [JsonIgnore]
        public virtual Policy Policy { get; set; }

        [JsonIgnore]
        public virtual RiskType RiskType { get; set; }
    }
}
