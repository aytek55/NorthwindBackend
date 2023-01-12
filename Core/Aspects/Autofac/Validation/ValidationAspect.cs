using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect:MethodInterception
    {

        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            // Gönderilen validator tipi bir IValidator değilse hata dönsün.
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(AspectMessages.ValidationTypeError);
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            // public class BrandValidator : AbstractValidator<Brand> buradaki brand nesnesine ulaşmak için aşağıdaki kod kullanılır.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            // Metodda ki brand türündeki nesneyi (nesneleri) yakalamak için...
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            // yakaladığın entitiylere validasyon uygula
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }


    }
}
