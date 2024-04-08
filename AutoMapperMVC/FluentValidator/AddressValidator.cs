using AutoMapperMVC.Models.ORM;
using FluentValidation;

namespace AutoMapperMVC.FluentValidator;

public class AddressValidator : AbstractValidator<Address>
{
	public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz...";
	public AddressValidator()
	{
		RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
		RuleFor(x => x.PostalCode).NotEmpty().WithMessage(NotEmptyMessage).Length(5).WithMessage("{PropertyName} alanı 5 kaakter olmalıdır...");
		RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
	}
}
