using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectPrioritizationApp.Models
{
    public partial class project
    {
        public project()
        {
            this.scores = new List<score>();
        }

        public int Id { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("BRD?")]
        public bool HasBRD { get; set; }

        public virtual ICollection<score> scores { get; set; }
    }
}
