using System.Collections.Generic;

namespace ObjectValidation
{
    public class ObjectValidator
    {
        public static IEnumerable<ValidationResult> GetValidationSummary(object source)
        {
            //user reflection to find all public property
            System.Type _classRef = source.GetType();
            var _properties =  _classRef.GetProperties(); // public properties
            var _results = new List<ValidationResult>();
            foreach (var property in _properties)
            {
                var validationAttributes = property.GetCustomAttributes(typeof(ValidationAttribute), true) as ValidationAttribute[];
                if (validationAttributes.Length > 0)
                {
                    ValidationResult _validationResult = new ValidationResult() { PropertyName = property.Name, ValidationRules = new List<ValidationRule>() };
                    foreach (var attribute in validationAttributes)
                    {
                        var rule = new ValidationRule();
                        rule.ValidationName = attribute.GetType().Name;
                        bool result = attribute.Validate(property.GetValue(source));
                        rule.Status = result ? ValidationStatus.VALID : ValidationStatus.INVALID;
                        rule.ErrorMessage = result ? "Validation is passed " : attribute.ErrorMessage;
                        _validationResult.ValidationRules.Add(rule);
                    }
                    _results.Add(_validationResult);
                }
            }
            return _results;
        }
    }
}
