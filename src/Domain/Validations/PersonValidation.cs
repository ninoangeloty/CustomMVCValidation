using BusinessCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class PersonValidation : BusinessValidationBase<Person>
    {
        public void Validate(Person model)
        {
            if (string.IsNullOrEmpty(model.LastName))
            {
                AddModelError("Last name is required.", _ => _.LastName);
            }
        }
    }
}
