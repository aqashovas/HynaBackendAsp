using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Faq
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer { get; set; }

        public FaqCategory FaqCategory { get; set; }
    }
}