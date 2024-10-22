using FluentValidation;
using PaymentService.Modules.Payments.Dto;

namespace PaymentService.Modules.Payments.Validators;

public class PaymentCreateDtoValidator : AbstractValidator<PaymentCreateDto>
{
	public PaymentCreateDtoValidator()
	{
		RuleFor(x => x.Price)
			.GreaterThan(0)
			.WithMessage("Price should be more than 0");
	}
}