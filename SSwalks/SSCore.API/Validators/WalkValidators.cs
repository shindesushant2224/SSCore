using FluentValidation;
using SSCore.API.Models.DTO;

namespace SSCore.API.Validators
{
    public class AddWalkValidators:AbstractValidator<AddWalksDto>
    {
        public AddWalkValidators()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15).MinimumLength(3);
            RuleFor(x => x.Lenght).GreaterThan(0);
        }
    }
    public class UpdateWalkValidators : AbstractValidator<UpdateWalksDto>
    {
        public UpdateWalkValidators()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15).MaximumLength(3);
            RuleFor(x => x.Lenght).GreaterThan(0);
        }
    }
}
