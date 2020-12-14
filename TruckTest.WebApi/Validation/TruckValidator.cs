using FluentValidation;
using System;
using TruckTest.Domain.Entities;

namespace TruckTest.WebApi.Validation
{
    public class TruckValidator : AbstractValidator<Truck>
    {
        public TruckValidator() {
            RuleFor(x => x.Model).IsInEnum();
            RuleFor(x => x.YearFactory).Equal(DateTime.Now.Year).When(x => x.Id == 0);
            RuleFor(x => x.YearModel).GreaterThanOrEqualTo(x => x.YearFactory).LessThanOrEqualTo(x => x.YearFactory + 1);
        }
    }
}
