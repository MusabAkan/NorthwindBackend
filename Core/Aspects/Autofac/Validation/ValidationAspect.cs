
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
 

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        readonly Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                //gönderilen validator türü ile validator türü değilse  hata patlat
                throw new Exception(AspectMessages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (object entity in entities )
            {
                ValidationTool.Validate(validator, entity);
            }
             
        }
    }
}
