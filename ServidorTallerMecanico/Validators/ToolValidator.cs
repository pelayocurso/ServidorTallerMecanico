using FluentValidation;
using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Validators
{
    public class ToolValidator : AbstractValidator<Tool>
    {
        public ToolValidator()
        {
            RuleFor(x => x.Type)
                .NotNull()
                    .WithMessage("El tipo de herramienta debe tener algun valor.")
                .NotEmpty()
                    .WithMessage("El tipo de herramienta no puede estar en blanco.")
                .Length(0,100)
                    .WithMessage("El tipo de herramienta no puede ser mayor de 100 caracteres.");

            RuleFor(x => x.)
        }
    }
}