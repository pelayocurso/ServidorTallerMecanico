using FluentValidation;
using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Validators
{
    public class VehicleValidator : AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(x => x.Owner)
                .NotEmpty().WithMessage("El campo x no puede estar vacio.")
                .Length(0, 100).WithMessage("El campo x no puede superar los 100 caracteres.");
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("El campo x no puede estar vacio.")
                .IsInEnum();

        }
    }
}