using System;
using DotNetBackendTemplate.Entities.Concrete;
using FluentValidation;

namespace DotNetBackendTemplate.Business.ValidationRules.FluentValidation
{
	public class AssetValidator : AbstractValidator<Asset>
	{
		public AssetValidator()
		{
			RuleFor(a => a.AssetName).NotEmpty();
			RuleFor(a => a.AssetName).MinimumLength(3);
		}
	}
}

