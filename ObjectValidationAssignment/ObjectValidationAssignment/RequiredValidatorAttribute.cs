using System;

namespace ObjectValidation
{
    public class RequiredValidatorAttribute : ValidationAttribute
    {
        public override bool Validate(object data)
        {
            var _value =(object)data ?? string.Empty;
            return !string.IsNullOrWhiteSpace(_value.ToString());
        }
    }
}
