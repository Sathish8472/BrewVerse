﻿using System.ComponentModel.DataAnnotations;

namespace BarService.API.Models
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
