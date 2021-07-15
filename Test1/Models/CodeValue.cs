using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test1.Models
{
    public class CodeValue
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int code { get; set; }
        [Required]
        [StringLength(200)]
        public string Value { get; set; }
    }
}
