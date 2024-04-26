using FluentValidation;
using SSCore.API.Models.DTO;

namespace SSCore.API.Validators
{
    public class UpdateRegionRequestValidators:AbstractValidator<UpdateRegionRequestDto>
    {
        public UpdateRegionRequestValidators()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(3).MinimumLength(3);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15).MinimumLength(3);
            RuleFor(x => x.Area).GreaterThan(0);
        }
    }
}
