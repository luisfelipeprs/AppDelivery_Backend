using AppDelivery.Communication.Requests;
using FluentValidation;
using AppDelivery.Exceptions;

namespace AppDelivery.Application.UseCases.Consumer;
internal class RegisterConsumerValidator : AbstractValidator<RequestRegisterConsumerJson>
{
    public RegisterConsumerValidator()
    {
        RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
        RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
        RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALID);
        RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.PASSWORD_EMPTY);
    }
}
