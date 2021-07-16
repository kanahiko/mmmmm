using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Models
{
    //add-migration CodeValueToDb
    public class CodeValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Value { get; set; }

    }
}
