using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HynaBackendAsp.Models
{
    public class About
    {
        public int Id { get; set; }

        [Required]
        public string Tittle { get; set; }

        [Column(name:"ntext")]
        public string Text { get; set; }

        public string Photo { get; set; }

    }
}