using System.Collections.Generic;

namespace ObjectValidation
{
    public class ValidationResult
    {
        public string PropertyName { get; set; }
        public List<ValidationRule> ValidationRules { get; set; }
    }
}
