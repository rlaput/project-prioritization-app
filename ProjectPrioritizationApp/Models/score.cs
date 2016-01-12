using System;
using System.Collections.Generic;

namespace ProjectPrioritizationApp.Models
{
    public partial class score
    {
        public int Id { get; set; }
        public int CriterionId { get; set; }
        public int ProjectId { get; set; }
        public int Rate { get; set; }
        public virtual criterion criterion { get; set; }
        public virtual project project { get; set; }
    }
}
