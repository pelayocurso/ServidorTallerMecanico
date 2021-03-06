﻿using FluentValidation.Attributes;
using ServidorTallerMecanico.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Models
{
    [Validator(typeof(VehicleValidator))]
    public class Vehicle
    {
        [Key]
        public long Id { get; set; }
        public string Owner { get; set; }
        public VehicleType Type { get; set; }
        public string Registration { get; set; }
        public string Trouble { get; set; }
        public State State { get; set; }
        public double Budget { get; set; }
        public DateTime Date { get; set; }
    }

    public enum State
    {
        ESPERA, ENTRADA, REPARACIÓN, SALIDA, HECHO
    }

    public enum VehicleType
    {
        MOTO, COCHE, CAMION
    }
}