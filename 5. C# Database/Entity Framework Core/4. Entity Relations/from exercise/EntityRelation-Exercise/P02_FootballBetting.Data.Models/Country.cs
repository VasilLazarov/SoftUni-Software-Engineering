﻿using P02_FootballBetting.Data.Common;
using System.ComponentModel.DataAnnotations;


namespace P02_FootballBetting.Data.Models
{
    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }

        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string Name { get; set; } = null!;

        //TODO: create nav collections
        public virtual ICollection<Town> Towns { get; set; }
    }
}