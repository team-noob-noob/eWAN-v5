using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace NoobNoob.eWAN.Core.ValueObjects;

public class SubjectId : ValueOf<Guid, SubjectId>
{
    protected override void Validate()
    {
        if (Value == Guid.Empty)
            throw new ValidationException("Invalid MarkdownString", new []
            {
                new ValidationFailure()
                {
                    ErrorMessage = "MarkdownString cannot be empty",
                }
            });
    }
}