using FluentValidation;
using SSCore.API.Models.DTO;

namespace SSCore.API.Validators
{
    public class AddRegionRequestValidators : AbstractValidator<AddRegionRequestDto>
    {
        public AddRegionRequestValidators()
        {
            RuleFor(x => x.Code).NotEmpty().MaximumLength(3).MinimumLength(3);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15).MinimumLength(3);
            RuleFor(x => x.Area).GreaterThan(0);

            //RuleFor(x => x.Code).MaximumLength(3).MinimumLength(3);
        }
    }
}
