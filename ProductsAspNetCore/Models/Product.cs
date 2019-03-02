using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductsAspNetCore.Models
{
    public class Product 
    {
        public int ID { get; set; }

        [DisplayName("Nazwa")]
        public string Name { get; set; }

        [DisplayName("Kategoria")]
        public string Category { get; set; }

        [DisplayName("Cena jednostkowa")]
        public double Price { get; set; }

        [DisplayName("Iloœæ")]
        public int Quantity { get; set; }

        [DisplayName("Przypisane do")]
        public string AssigntTo { get; set; }
    }
}