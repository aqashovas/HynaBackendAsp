using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HynaBackendAsp.Models
{
    public class Fact
    {
        public int Id { get; set; }

        public int Orderby { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }



    }
}