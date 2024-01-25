using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Validations
{
    public static class ValidationUtility 
    {
        public static IList<string> ErrorMessages(this List<FluentValidation.Results.ValidationFailure> errors)
        {
            List<string> messages = new List<string>();
            errors.ForEach(error => { messages.Add(error.ErrorMessage); });
            return messages;
        }
    }
}
