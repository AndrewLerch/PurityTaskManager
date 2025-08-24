using System.ComponentModel.DataAnnotations;

namespace PurityTaskManager.Attributes;

/// <summary>
/// Data Attribute for a DateTime field which will validate based on whether the date is in the future
/// </summary>
public class FutureDateAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        // Check if the value is a DateTime and is not null
        if (value is DateTime datetime)
        {
            // Compare the date with the current date
            return datetime > DateTime.Today;
        }

        // If the value is null or not a DateTime, consider it invalid
        return false;
    }

    public override string FormatErrorMessage(string name)
    {
        return $"{name} must be a future date.";
    }
}