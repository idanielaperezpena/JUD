using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Entidades;

namespace Negocio
{
    public class CustomEmailAddress : RegularExpressionAttribute, IClientValidatable
    {
        public CustomEmailAddress() : this(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")
        {
        }

        public CustomEmailAddress(string pattern) : base(pattern)
        {
            ErrorMessage = Constantes.MESSAGE_EMAIL_FORMAT;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRegexRule(ErrorMessage, Pattern);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _result = base.IsValid(value, validationContext);

            if (_result != null)
                _result = new ValidationResult(ErrorMessage);

            return _result;
        }

        public class CustomMultipleEmailAddress : CustomEmailAddress
        {
            public CustomMultipleEmailAddress() : base(@"^((\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)\s*[;]{0,1}\s*)+$")
            {
                ErrorMessage = Constantes.MESSAGE_MULTIPLE_EMAIL_FORMAT;
            }
        }
    }
}
