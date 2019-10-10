using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Entidades;
using System.Web.Mvc;

namespace Negocio
{
    public class CustomRequired : RequiredAttribute, IClientValidatable
    {
        public CustomRequired()
        {
            ErrorMessage = Constantes.MESSAGE_REQUIRED_FIELD;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRequiredRule(ErrorMessage);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult _result;

            if (value is CalendarControl)
            {
                _result = base.IsValid((value as CalendarControl).FechaString, validationContext);

                if (_result != null)
                    _result = new ValidationResult(ErrorMessage, new List<string> { "FechaString" });
            }
            else
                _result = base.IsValid(value, validationContext);

            return _result;
        }
    }
}
