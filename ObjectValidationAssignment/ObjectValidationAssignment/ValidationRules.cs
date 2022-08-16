namespace ObjectValidation
{
    public class ValidationRule
    {
        public string ValidationName { get; set; }
        public ValidationStatus Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ValidationStatus
    {
        VALID,
        INVALID
    }
}
