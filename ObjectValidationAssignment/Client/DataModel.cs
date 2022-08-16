namespace Client
{
    public class DataModel
    {
        [ObjectValidation.RequiredValidator(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [ObjectValidation.RangeValidator(1,100, ErrorMessage = "Age Value Must be with in range 1-100")]
        [ObjectValidation.RequiredValidator(ErrorMessage = "Age is required")]
        public int Age { get; set; }

        [ObjectValidation.RequiredValidator(ErrorMessage = "Contact Number Requires Value")]
        [ObjectValidation.LengthValidator(MaxLength = 10, ErrorMessage = "Maximum 10 numbers are allowed")]
        public string ContactNumber { get; set; }

        [ObjectValidation.RequiredValidator(ErrorMessage = "Email ID is required")]
        public string EmailID { get; set; }
    }
}
