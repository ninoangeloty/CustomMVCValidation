using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Helpers
{
    public static class BusinessValidationHelper
    {
        public static IEnumerable<BusinessValidationResult> ExecuteValidationRule(object validationRule, object instance)
        {
            validationRule.GetType().GetMethod("Validate").Invoke(validationRule, new object[] { instance });
            return (IEnumerable<BusinessValidationResult>)validationRule.GetType().GetProperty("ValidationResult").GetValue(validationRule);
        }

        public static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            if (expression.Body.GetType() == typeof(UnaryExpression))
            {
                var operand = expression.Body.GetType().GetProperty("Operand").GetValue(expression.Body);
                var memberValue = operand.GetType().GetProperty("Member").GetValue(operand);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
            }
            else
            {
                var memberValue = expression.Body.GetType().GetProperty("Member").GetValue(expression.Body);
                return memberValue.GetType().GetProperty("Name").GetValue(memberValue).ToString();
            }
        }
    }
}
