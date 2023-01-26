using BP.API.Models;
using FluentValidation;

namespace BP.API.Validation
{
    public class ContactValidator : AbstractValidator<ContactDTO>
    {
        public ContactValidator()
        {
            RuleFor(i => i.Id).LessThan(100).WithMessage("Id 99'dan büyük olamaz !");
        }
    }
}
