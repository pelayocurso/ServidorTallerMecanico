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
            /*
            public long Id { get; set; }
            public string Owner { get; set; }
            public VehicleType Type { get; set; }
            public string Trouble { get; set; }
            public State State { get; set; }
            public double Budget { get; set; }
            public DateTime Date { get; set; }
            */

            RuleFor(x => x.Owner)
                .NotNull().WithMessage("El campo \"Dueño\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Dueño\" no puede estar vacio.")
                .Length(0, 100).WithMessage("El campo \"Dueño\" no puede superar los 100 caracteres.")
                .Matches(@"^[a-zA-Z áéíóúÁÉÍÓÚñÑçÇ,.'-]+$").WithMessage("El campo \"Dueño\" no sigue un formato valido.");

            RuleFor(x => x.Type)
                .NotNull().WithMessage("El campo \"Tipo\" no puede ser nulo.")
                //.NotEmpty().WithMessage("El campo \"Tipo\" no puede estar vacio.")
                .IsInEnum().WithMessage("Los valores permitidos para el campo \"Tipo\" son: MOTO, COCHE y CAMION");

            RuleFor(x => x.Registration)
                .NotNull().WithMessage("El campo \"Matricula\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Matricula\" no puede estar vacio.")
                .Matches(@"^[A-Z- 0-9]{6,12}$").WithMessage("El campo \"Matricula\" no es valido.");

            RuleFor(x => x.Trouble)
                .NotNull().WithMessage("El campo \"Averia\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Averia\" no puede estar vacio.")
                .Length(0, 400).WithMessage("El campo \"Averia\" no puede superar los 400 caracteres.");

            RuleFor(x => x.State)
                .NotNull().WithMessage("El campo \"Estado\" no puede ser nulo.")
                //.NotEmpty().WithMessage("El campo \"Estado\" no puede estar vacio.")
                .IsInEnum().WithMessage("Los valores permitidos para el campo \"Estado\" son: ESPERA, ENTRADA, REPARACIÓN, SALIDA y HECHO");

            RuleFor(x => x.Budget)
                .NotNull().WithMessage("El campo \"Presupuesto\" no puede ser nulo.")
                .NotEmpty().WithMessage("El campo \"Presupuesto\" no puede estar vacio.")
                .GreaterThan(0).WithMessage("El campo \"Presupuesto\" debe ser mayor que 0.");

            // RuleFor(x => x.Date);
        }
    }
}