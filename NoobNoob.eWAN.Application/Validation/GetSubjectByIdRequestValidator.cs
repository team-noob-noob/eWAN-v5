using FastEndpoints;
using FluentValidation;
using NoobNoob.eWAN.Application.Contracts.Requests;

namespace NoobNoob.eWAN.Application.Validation;

public class GetSubjectByIdRequestValidator : Validator<GetSubjectByIdRequest>
{
    public GetSubjectByIdRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}