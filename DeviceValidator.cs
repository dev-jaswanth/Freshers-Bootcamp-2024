using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Property)]
class RequiredAttribute : Attribute
{
    public string ErrorMessage { get; set; }

    public RequiredAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}

[AttributeUsage(AttributeTargets.Property)]
class RangeAttribute : Attribute
{
    public int Min { get; }
    public int Max { get; }
    public string ErrorMessage { get; set; }

    public RangeAttribute(int min, int max, string errorMessage)
    {
        Min = min;
        Max = max;
        ErrorMessage = errorMessage;
    }
}

[AttributeUsage(AttributeTargets.Property)]
class MaxLengthAttribute : Attribute
{
    public int MaxLength { get; }
    public string ErrorMessage { get; set; }

    public MaxLengthAttribute(int maxLength, string errorMessage)
    {
        MaxLength = maxLength;
        ErrorMessage = errorMessage;
    }
}


interface IValidator
{
    bool Validate(object obj, out List<string> errors);
}


class ObjectValidator : IValidator
{
    public bool Validate(object obj, out List<string> errors)
    {
        errors = new List<string>();

        
        var properties = obj.GetType().GetProperties();

        foreach (var property in properties)
        {
            
            if (Attribute.IsDefined(property, typeof(RequiredAttribute)))
            {
                var value = property.GetValue(obj);

                if (value == null || (value is string && string.IsNullOrEmpty((string)value)))
                {
                    var errorMessage = (property.GetCustomAttributes(typeof(RequiredAttribute), true)[0] as RequiredAttribute).ErrorMessage;
                    errors.Add(errorMessage);
                }
            }
            
            if (Attribute.IsDefined(property, typeof(RangeAttribute)))
            {
                var value = (int)property.GetValue(obj);
                var rangeAttribute = (RangeAttribute)property.GetCustomAttributes(typeof(RangeAttribute), true)[0];

                if (value < rangeAttribute.Min || value > rangeAttribute.Max)
                {
                    errors.Add(rangeAttribute.ErrorMessage);
                }
            }

            if (Attribute.IsDefined(property, typeof(MaxLengthAttribute)))
            {
                var value = property.GetValue(obj) as string;
                var maxLengthAttribute = (MaxLengthAttribute)property.GetCustomAttributes(typeof(MaxLengthAttribute), true)[0];

                if (value != null && value.Length > maxLengthAttribute.MaxLength)
                {
                    errors.Add(maxLengthAttribute.ErrorMessage);
                }
            }
        }

        return errors.Count == 0;
    }
}

class Device
{
    [Required(ErrorMessage = "ID Property Requires Value")]
    [MaxLength(100, "Max of 100 Characters are allowed")]
    public string Id { get; set; }

    [Range(10, 100, "Code Value Must Be Within 10-100")]
    public int Code { get; set; }

    public string Description { get; set; }
}

class Program
{
    static void Main()
    {

        IValidator validator = new ObjectValidator();

        
        Device deviceObj = new Device { Id = "Some Random Input Id", Code = 50 };

      
        List<string> errors;
        bool isValid = validator.Validate(deviceObj, out errors);

        if (!isValid)
        {
            foreach (string item in errors)
            {
                Console.WriteLine(item);
            }
        }
        else
        {
            Console.WriteLine("Object is valid.");
        }
    }
}
