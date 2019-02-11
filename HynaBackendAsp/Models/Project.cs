using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HynaBackendAsp.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(name:"ntext")]
        public string Text { get; set; }

        public string Photo { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; }

    }
}