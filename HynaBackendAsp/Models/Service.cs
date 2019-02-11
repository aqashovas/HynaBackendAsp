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

        public int Orderby { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public string Photo { get; set; }

        public string Desc { get; set; }

        public string Pdf { get; set; }

        public string Doc { get; set; }

        [Column(name:"ntext")]
        public string Text { get; set; }





    }
}