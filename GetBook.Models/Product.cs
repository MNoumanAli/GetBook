﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [DisplayName("List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        [DisplayName("Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }

        [DisplayName("Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        public string ImageURL { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}