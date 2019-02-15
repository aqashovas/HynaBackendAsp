using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HynaBackendAsp.Models
{
    public class Partner
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Logo { get; set; }

    }
}