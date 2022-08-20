using FastEndpoints;
using FluentValidation;
using NoobNoob.eWAN.Application.Contracts.Data;
using NoobNoob.eWAN.Application.Contracts.Requests;

namespace NoobNoob.eWAN.Application.Validation;

public class SubjectQueryRequestValidator : Validator<SubjectQueryRequest>
{
    public SubjectQueryRequestValidator()
    {
        RuleFor(x => x.SortBy)
            .Must(x => ValidSortByValues.Contains(x))
            .WithMessage($"SortBy must be one of {string.Join(", ", ValidSortByValues)}");
        
        
    }
    
    private static readonly IEnumerable<string> ValidSortByValues 
        = typeof(SubjectDto).GetProperties().Select(p => p.Name);
}