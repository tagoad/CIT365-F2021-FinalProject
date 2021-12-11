using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentPlanner.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        [Required]
        public Member AssignedTo { get; set; }
        [Required]
        public string Topic { get; set; }
    }
}
