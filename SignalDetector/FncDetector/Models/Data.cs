using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FncDetector.Models
{
    class Data
    {
        [Key]
        public String NameDevice { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public String x { get; set; }
        [Required]
        public String y { get; set; }
        [Required]
        public String z { get; set; }

    }
}
