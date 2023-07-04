using FluentValidation;

namespace Application.ValidateLicense;

public class ValidateLicenseValidator : AbstractValidator<ValidateLicenseRequest>
{
    public ValidateLicenseValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}
