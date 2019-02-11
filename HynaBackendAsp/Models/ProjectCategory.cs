using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HynaBackendAsp.Models
{
    public class ProjectCategory
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public Project Project { get; set; }
    }
}