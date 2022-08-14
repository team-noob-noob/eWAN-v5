using System.Text.RegularExpressions;
using FluentValidation;
using FluentValidation.Results;
using ValueOf;

namespace NoobNoob.eWAN.Core.ValueObjects.Common;

/// <summary>
/// Address of a Location
/// </summary>
public class Address : ValueOf<(string Line1, string? Line2, string City, string Country, string? ZipCode),
    Address>
{
    private static Regex addressValidCharsRegex = 
            new Regex("^[a-z ,.'-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    
    protected override void Validate()
    {
        var validationFailures = new List<ValidationFailure>();

        if (!addressValidCharsRegex.IsMatch(Value.Line1))
            validationFailures.Add(new ValidationFailure(nameof(Value.Line1), $"{Value.Line1} is not valid Address"));
        
        if (Value.Line2 is not null && !addressValidCharsRegex.IsMatch(Value.Line2))
            validationFailures.Add(new ValidationFailure(nameof(Value.Line2), $"{Value.Line2} is not valid Address"));
        
        if (!addressValidCharsRegex.IsMatch(Value.Country))
            validationFailures.Add(new ValidationFailure(nameof(Value.Country), $"{Value.Country} is not valid Country"));
        
        if (Value.ZipCode is not null && !addressValidCharsRegex.IsMatch(Value.ZipCode))
            validationFailures.Add(new ValidationFailure(nameof(Value.ZipCode), $"{Value.ZipCode} is not valid ZIP Code"));        
            
        if (validationFailures.Count != 0)
            throw new ValidationException("Invalid characters for Home Address", validationFailures);
    }
}
