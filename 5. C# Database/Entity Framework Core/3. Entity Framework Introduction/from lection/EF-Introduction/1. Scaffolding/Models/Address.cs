﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _1._Scaffolding.Models;

public partial class Address
{
    [Key]
    [Column("AddressID")]
    public int AddressId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string AddressText { get; set; } = null!;

    [Column("TownID")]
    public int? TownId { get; set; }

    [Required]
    [Column("AppartmentNumber")]
    [StringLength(10)]
    public string AppartmentNumber { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [ForeignKey("TownId")]
    [InverseProperty("Addresses")]
    public virtual Town? Town { get; set; }
}
