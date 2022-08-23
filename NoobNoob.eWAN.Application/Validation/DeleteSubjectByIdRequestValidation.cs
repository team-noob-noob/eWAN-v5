using FastEndpoints;
using FluentValidation;
using NoobNoob.eWAN.Application.Contracts.Requests;

namespace NoobNoob.eWAN.Application.Validation;

public class DeleteSubjectByIdRequestValidation : Validator<DeleteSubjectByIdRequest>
{
    public DeleteSubjectByIdRequestValidation()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}