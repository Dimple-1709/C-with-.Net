using System;
namespace ObjectValidation
{
    public class RangeValidatorAttribute : ValidationAttribute
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public RangeValidatorAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        
        public override bool Validate(object data)
        {
            int value = Convert.ToInt32(data);
            return value >= MinValue && value <= MaxValue;
        }
    }
}
