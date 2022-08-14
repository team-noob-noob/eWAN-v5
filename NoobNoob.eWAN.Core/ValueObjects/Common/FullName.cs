using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace NoobNoob.eWAN.Core.ValueObjects.Common;

/// <summary>
/// A person's name
/// </summary>
public class FullName : ValueOf<(string FirstName, string LastName, string? MiddleName), FullName>
{
    private static readonly Regex validNameRegex =
        new("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    protected override void Validate()
    {
        var validationFailures = new List<ValidationFailure>();

        if (!validNameRegex.IsMatch(Value.FirstName))
            validationFailures.Add(new ValidationFailure(nameof(Value.FirstName),
                $"{Value.FirstName} is not valid First Name"));

        if (!validNameRegex.IsMatch((Value.LastName)))
            validationFailures.Add(new ValidationFailure(nameof(Value.LastName),
                $"{Value.LastName} os not valid Last Name"));
        
        if (Value.MiddleName is not null && Value.MiddleName != "" && !validNameRegex.IsMatch((Value.MiddleName)))
            validationFailures.Add(new ValidationFailure(nameof(Value.MiddleName),
                $"{Value.MiddleName} is not valid Middle Name"));
        
        if (validationFailures.Count != 0)
            throw new ValidationException("Invalid character for Names", validationFailures);
    }
}