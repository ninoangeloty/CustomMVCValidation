using BusinessCore.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore
{
    public abstract class BusinessValidationBase<T>
        where T : BusinessBase
    {
        public BusinessValidationBase()
        {
            ValidationResult = new Collection<BusinessValidationResult>();
        }

        public void AddModelError(string message, Expression<Func<T, object>> property)
        {
            ValidationResult.Add(new BusinessValidationResult(message, BusinessValidationHelper.GetPropertyName<T>(property)));
        }

        public ICollection<BusinessValidationResult> ValidationResult { get; set; }
    }
}
