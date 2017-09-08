using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Models
{
    public class Vehicle
    {
        [Key]
        public long Id { get; set; }
        public string Owner { get; set; }
        public string Type { get; set; }
        public string Trouble { get; set; }
        public string State { get; set; }
        public double Budget { get; set; }
        public DateTime Date { get; set; }
    }
}