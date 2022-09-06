using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_API2.Models
{
    public class Item
    {
        [Required]
        [Range(1,100)]
        public int id { get; set; }
        [StringLength(maximumLength:9, MinimumLength =2)]
        public string name { get; set; }
        public bool Iscomplete { get; set; }
    }
}
