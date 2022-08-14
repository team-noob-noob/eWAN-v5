using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace NoobNoob.eWAN.Core.ValueObjects;

/// <summary>
/// A string that handles validation and html rendering of Markdown text.
/// </summary>
public class MarkdownString : ValueOf<string, MarkdownString>
{
    protected override void Validate()
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new ValidationException("Invalid MarkdownString", new []
            {
                new ValidationFailure()
                {
                    ErrorMessage = "MarkdownString cannot be empty",
                }
            });
    }
}