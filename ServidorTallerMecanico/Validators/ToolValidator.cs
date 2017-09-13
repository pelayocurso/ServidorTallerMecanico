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
            /*
            public long Id { get; set; }
            public string Type { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public DateTime Date { get; set; }
            */

            RuleFor(x => x.Type)
                .NotNull().WithMessage("El campo \"Tipo\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Tipo\" no puede estar vacio.")
                .Length(0, 100).WithMessage("El campo \"Tipo\" no puede superar los 100 caracteres.")
                .Matches(@"^[a-zA-Z áéíóúÁÉÍÓÚñÑçÇ,.'-]+$").WithMessage("El campo \"Dueño\" no sigue un formato valido.");

            RuleFor(x => x.Name)
                .NotNull().WithMessage("El campo \"Nombre\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Nombre\" no puede estar vacio.")
                .Length(0, 100).WithMessage("El campo \"Nombre\" no puede superar los 100 caracteres.");

            RuleFor(x => x.Quantity)
                .NotNull().WithMessage("El campo \"Cantidad\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Cantidad\" no puede estar vacio.")
                .GreaterThan(-1).WithMessage("El campo \"Cantidad\" no puede ser negativo.");

        }
    }
}