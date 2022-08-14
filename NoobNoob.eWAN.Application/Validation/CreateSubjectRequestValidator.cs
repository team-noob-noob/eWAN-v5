using FastEndpoints;
using FluentValidation;
using NoobNoob.eWAN.Application.Contracts.Requests;

namespace NoobNoob.eWAN.Application.Validation;

public class CreateSubjectRequestValidator : Validator<CreateSubjectRequest>
{
    public CreateSubjectRequestValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).MaximumLength(2000);
    }
}