using Application.Features.Buses.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Buses.Commands.PersonelAssign;
public class PersonelAssignedBusCommandValidator : AbstractValidator<PersonelAssignBusCommand>
{
    public PersonelAssignedBusCommandValidator()
    {

    }
}


