using System;
namespace ObjectValidation
{
    public class LengthValidatorAttribute : ValidationAttribute
    {
        public int MaxLength { get; set; }
        public override bool Validate(object data)
        {
            var obj = data.ToString();
            return obj.Length <= MaxLength;
        }
    }
}
