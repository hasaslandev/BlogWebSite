using Castle.DynamicProxy;

namespace CoreL.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Öncelik

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
