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
            //RuleFor()
        }
    }
}