using BusinessCore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore
{
    public abstract class BusinessBase : IValidatableObject
    {
        private List<object> _validationRules;

        public void AddValidationRule<T>()
            where T : new()
        {
            if (_validationRules == null)
            {
                _validationRules = new List<object>();
            }

            _validationRules.Add(Activator.CreateInstance<T>());
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<BusinessValidationResult>();

            foreach (var rule in _validationRules)
            {
                errors.AddRange(BusinessValidationHelper.ExecuteValidationRule(rule, this));
            }

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    yield return new ValidationResult(error.Message, new string[] { error.Property });
                }
            }
            else
            {
                yield break;
            }
        }
    }
}
