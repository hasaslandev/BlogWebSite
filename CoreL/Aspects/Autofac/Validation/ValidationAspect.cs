using Castle.DynamicProxy;
using CoreL.CrossCuttingConcerns.Validation;
using CoreL.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect(kodun başında sonunda hata verdiğinde vs. çalışacak yapı)
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType/*productvalidator*/))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator?)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType?.BaseType?.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Metodun parametrelerine bak validatorun tipine eşit olan parametreleri git bul 
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator!, entity);
            }
        }
    }
}
