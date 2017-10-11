﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 256)]
        public string Name { get; set; }
        public DateTime DateCreate { get; set; }
        [Required]
        [Range(1, 100)]
        public int Priority { get; set; }
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        virtual public Country Country { get; set; }
    }
}
