using FluentValidation.Attributes;
using ServidorTallerMecanico.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Models
{
    [Validator(typeof(ToolValidator))]
    public class Tool
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}