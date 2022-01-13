using FluentValidation;
using Horizon.API.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horizon.API.Validator
{
    public class SaveFeedVisitValidator : AbstractValidator<SaveFeedVisitDto>
    {
        public SaveFeedVisitValidator()
        {
            RuleFor(fd => fd.AnimalId)
                .NotEmpty();
        }
    }
}
