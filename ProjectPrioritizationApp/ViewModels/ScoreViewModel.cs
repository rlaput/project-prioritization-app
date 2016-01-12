using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectPrioritizationApp.ViewModels
{
    public class ScoreViewModel
    {
        public int ProjectId { get; set; }

        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Project Description")]
        public string ProjectDescription { get; set; }
        public float Score { get; set; }

        [DisplayName("BRD?")]
        public bool HasBRD { get; set; }
    }
}