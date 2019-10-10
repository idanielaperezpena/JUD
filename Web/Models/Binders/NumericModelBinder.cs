using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models.Binders
{
    public class NumericModelBinder<T> : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(T))
            {
                var _val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
                bindingContext.ModelMetadata.Model = _val.ParseTo<T>(NumberStyles.Number | NumberStyles.Currency);

                foreach (var item in bindingContext.ModelMetadata.GetValidators(controllerContext))
                {
                    foreach (var val in item.Validate(bindingContext.ModelMetadata.Container))
                    {
                        bindingContext.ModelState.AddModelError(val.MemberName, val.Message);
                    }
                }

                return bindingContext.ModelMetadata.Model;
            }

            return base.BindModel(controllerContext, bindingContext);
        }
    }
}