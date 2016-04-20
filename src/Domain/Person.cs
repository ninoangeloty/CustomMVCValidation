using BusinessCore;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Person : BusinessBase
    {
        public Person()
        {
            base.AddValidationRule<PersonValidation>();
        }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
