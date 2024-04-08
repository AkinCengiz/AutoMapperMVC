using AutoMapperMVC.Models.ORM;
using FluentValidation;

namespace AutoMapperMVC.FluentValidator;

public class ProductValidator : AbstractValidator<Product>
{
	public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz...";

	public ProductValidator()
	{
		RuleFor(x => x.ProductName).NotEmpty().WithMessage(NotEmptyMessage);
		RuleFor(x => x.UnitPrice).NotEmpty().WithMessage(NotEmptyMessage).GreaterThan(0).WithMessage("Girilen değer 0 dan büyük olmalıdır...")
			.PrecisionScale(9, 2, false).WithMessage("Ondalıklı kısım 2 baamaklı olmalıdır.");
		RuleFor(x => x.UnitsInStock).NotEmpty().WithMessage(NotEmptyMessage).GreaterThanOrEqualTo(0)
			.WithMessage("Negatif bir değer girilemez...");
		RuleFor(x => x.QuantityPerUnit).NotEmpty().WithMessage(NotEmptyMessage);
	}
}
