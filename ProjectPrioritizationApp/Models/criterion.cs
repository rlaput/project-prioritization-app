using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectPrioritizationApp.Models
{
    public partial class criterion
    {
        public criterion()
        {
            this.scores = new List<score>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Criterion")]
        public string CriterionName { get; set; }

        [Required]
        public float Weight { get; set; }
        public virtual ICollection<score> scores { get; set; }
    }
}
