using System;
using static ObjectValidation.ObjectValidator;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DataModel data = new DataModel()
            {   
                Name = null,
                Age = 123,
                ContactNumber = "462786574365",
                EmailID = string.Empty
            };
            dynamic validationSummerry = GetValidationSummary(data);

            foreach (var validationResult in validationSummerry)
            {
                Console.WriteLine($"Validations for {validationResult.PropertyName} property :");
                foreach (var rule in validationResult.ValidationRules)
                {
                    Console.WriteLine($" {rule.ValidationName} is applied for {validationResult.PropertyName}");
                    Console.WriteLine($" Validation Status for {validationResult.PropertyName} is {rule.Status}");
                    Console.WriteLine($" {rule.ErrorMessage}");
                    Console.WriteLine("");
                }
            }
        }
    }
}
