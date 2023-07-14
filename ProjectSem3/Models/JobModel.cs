using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models
{
    public class JobModel
    {
        [DisplayName("ID JOB")]
        public int job_title_id { get; set; }
        [DisplayName("Job Name")]
        public string job_title_name { get; set; }
        [DisplayName("Description")]
        public string description { get; set; }
    }
}