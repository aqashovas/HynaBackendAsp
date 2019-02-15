using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HynaBackendAsp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Blog> Blogs { get; set; }

        public List<ProjectCategory> ProjectCategories { get; set; }

    }
}