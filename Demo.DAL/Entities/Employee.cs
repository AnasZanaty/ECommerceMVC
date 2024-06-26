﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Entities
{
    [Index (nameof(Name))]
    public class Employee :BaseEntity

    {
       // public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Name { get; set; }
        
        public string Address { get; set; }

        public decimal salary { get; set; }

        public string Email { get; set; }

        public string? ImageUrl { get; set; }
        public DateTime HireDate { get; set; } =  DateTime.Now;

        public int? DepartmentId { get; set; }
        
        public Department? Department { get; set; }
    
    
    }
}
