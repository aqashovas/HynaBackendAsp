using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public int Orderby { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Icon { get; set; }

        public string Photo { get; set; }

        public string Desc { get; set; }

        public string Pdf { get; set; }

        public string Doc { get; set; }

        [Column(name:"ntext")]
        public string Text { get; set; }





    }
}