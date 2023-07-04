using FluentValidation;

namespace Application.CreateLicense;

public class ValidateLicenseValidator : AbstractValidator<CreateLicenseRequest>
{
    public ValidateLicenseValidator()
    {
        RuleFor(x => x.Expires).GreaterThanOrEqualTo(DateTime.Now);
        RuleFor(x => x.UserId).NotEmpty();
    }
}
