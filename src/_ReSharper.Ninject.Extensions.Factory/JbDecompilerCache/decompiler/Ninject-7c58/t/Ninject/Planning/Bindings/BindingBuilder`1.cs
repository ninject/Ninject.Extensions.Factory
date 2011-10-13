// Type: Ninject.Planning.Bindings.BindingBuilder`1
// Assembly: Ninject, Version=2.3.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\lib\Ninject\net-4.0\Ninject.dll

using Ninject;
using Ninject.Activation;
using Ninject.Activation.Providers;
using Ninject.Infrastructure;
using Ninject.Infrastructure.Introspection;
using Ninject.Infrastructure.Language;
using Ninject.Parameters;
using Ninject.Planning.Targets;
using Ninject.Syntax;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ninject.Planning.Bindings
{
  public class BindingBuilder<T> : IBindingSyntax<T>, IBindingToSyntax<T>, IBindingWhenInNamedWithOrOnSyntax<T>, IBindingWhenSyntax<T>, IBindingInNamedWithOrOnSyntax<T>, IBindingInSyntax<T>, IBindingNamedWithOrOnSyntax<T>, IBindingNamedSyntax<T>, IBindingWithOrOnSyntax<T>, IBindingWithSyntax<T>, IBindingOnSyntax<T>, IBindingSyntax, IFluentSyntax, IHaveBinding, IHaveKernel
  {
    public IBinding Binding { get; private set; }

    public IKernel Kernel { get; private set; }

    public BindingBuilder(IBinding binding, IKernel kernel)
    {
      Ensure.ArgumentNotNull((object) binding, "binding");
      Ensure.ArgumentNotNull((object) kernel, "kernel");
      this.Binding = binding;
      this.Kernel = kernel;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToSelf()
    {
      this.Binding.ProviderCallback = StandardProvider.GetCreationCallback(this.Binding.Service);
      this.Binding.Target = BindingTarget.Self;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> To<TImplementation>() where TImplementation : T
    {
      this.Binding.ProviderCallback = StandardProvider.GetCreationCallback(typeof (TImplementation));
      this.Binding.Target = BindingTarget.Type;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> To(Type implementation)
    {
      this.Binding.ProviderCallback = StandardProvider.GetCreationCallback(implementation);
      this.Binding.Target = BindingTarget.Type;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToConstructor(Expression<Func<IConstructorArgumentSyntax, T>> newExpression)
    {
      NewExpression ctorExpression = newExpression.Body as NewExpression;
      if (ctorExpression == null)
        throw new ArgumentException("The expression must be a constructor call.", "newExpression");
      this.Binding.ProviderCallback = StandardProvider.GetCreationCallback(ctorExpression.Type, ctorExpression.Constructor);
      this.Binding.Target = BindingTarget.Type;
      this.AddConstructorArguments(ctorExpression, newExpression.Parameters[0]);
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToProvider<TProvider>() where TProvider : IProvider
    {
      this.Binding.ProviderCallback = (Func<IContext, IProvider>) (ctx => (IProvider) ResolutionExtensions.Get<TProvider>((IResolutionRoot) ctx.Kernel, new IParameter[0]));
      this.Binding.Target = BindingTarget.Provider;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToProvider(Type providerType)
    {
      this.Binding.ProviderCallback = (Func<IContext, IProvider>) (ctx => ResolutionExtensions.Get((IResolutionRoot) ctx.Kernel, providerType, new IParameter[0]) as IProvider);
      this.Binding.Target = BindingTarget.Provider;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToProvider(IProvider provider)
    {
      this.Binding.ProviderCallback = (Func<IContext, IProvider>) (ctx => provider);
      this.Binding.Target = BindingTarget.Provider;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToMethod(Func<IContext, T> method)
    {
      this.Binding.ProviderCallback = (Func<IContext, IProvider>) (ctx => (IProvider) new CallbackProvider<T>(method));
      this.Binding.Target = BindingTarget.Method;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWhenInNamedWithOrOnSyntax<T> ToConstant(T value)
    {
      this.Binding.ProviderCallback = (Func<IContext, IProvider>) (ctx => (IProvider) new ConstantProvider<T>(value));
      this.Binding.Target = BindingTarget.Constant;
      this.Binding.ScopeCallback = StandardScopeCallbacks.Singleton;
      return (IBindingWhenInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> When(Func<IRequest, bool> condition)
    {
      this.Binding.Condition = condition;
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenInjectedInto<TParent>()
    {
      return this.WhenInjectedInto(typeof (TParent));
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenInjectedInto(Type parent)
    {
      this.Binding.Condition = (Func<IRequest, bool>) (r =>
      {
        if (r.Target != null)
          return r.Target.Member.ReflectedType == parent;
        else
          return false;
      });
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenClassHas<TAttribute>() where TAttribute : Attribute
    {
      return this.WhenClassHas(typeof (TAttribute));
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenMemberHas<TAttribute>() where TAttribute : Attribute
    {
      return this.WhenMemberHas(typeof (TAttribute));
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenTargetHas<TAttribute>() where TAttribute : Attribute
    {
      return this.WhenTargetHas(typeof (TAttribute));
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenClassHas(Type attributeType)
    {
      if (!typeof (Attribute).IsAssignableFrom(attributeType))
        throw new InvalidOperationException(ExceptionFormatter.InvalidAttributeTypeUsedInBindingCondition(this.Binding, "WhenClassHas", attributeType));
      this.Binding.Condition = (Func<IRequest, bool>) (r =>
      {
        if (r.Target != null)
          return ExtensionsForMemberInfo.HasAttribute((MemberInfo) r.Target.Member.ReflectedType, attributeType);
        else
          return false;
      });
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenMemberHas(Type attributeType)
    {
      if (!typeof (Attribute).IsAssignableFrom(attributeType))
        throw new InvalidOperationException(ExceptionFormatter.InvalidAttributeTypeUsedInBindingCondition(this.Binding, "WhenMemberHas", attributeType));
      this.Binding.Condition = (Func<IRequest, bool>) (r =>
      {
        if (r.Target != null)
          return ExtensionsForMemberInfo.HasAttribute(r.Target.Member, attributeType);
        else
          return false;
      });
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenTargetHas(Type attributeType)
    {
      if (!typeof (Attribute).IsAssignableFrom(attributeType))
        throw new InvalidOperationException(ExceptionFormatter.InvalidAttributeTypeUsedInBindingCondition(this.Binding, "WhenTargetHas", attributeType));
      this.Binding.Condition = (Func<IRequest, bool>) (r =>
      {
        if (r.Target != null)
          return ExtensionsForICustomAttributeProvider.HasAttribute((ICustomAttributeProvider) r.Target, attributeType);
        else
          return false;
      });
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingInNamedWithOrOnSyntax<T> WhenParentNamed(string name)
    {
      string.Intern(name);
      this.Binding.Condition = (Func<IRequest, bool>) (r =>
      {
        if (r.ParentContext != null)
          return string.Equals(r.ParentContext.Binding.Metadata.Name, name, StringComparison.Ordinal);
        else
          return false;
      });
      return (IBindingInNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> Named(string name)
    {
      string.Intern(name);
      this.Binding.Metadata.Name = name;
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingNamedWithOrOnSyntax<T> InSingletonScope()
    {
      this.Binding.ScopeCallback = StandardScopeCallbacks.Singleton;
      return (IBindingNamedWithOrOnSyntax<T>) this;
    }

    public IBindingNamedWithOrOnSyntax<T> InTransientScope()
    {
      this.Binding.ScopeCallback = StandardScopeCallbacks.Transient;
      return (IBindingNamedWithOrOnSyntax<T>) this;
    }

    public IBindingNamedWithOrOnSyntax<T> InThreadScope()
    {
      this.Binding.ScopeCallback = StandardScopeCallbacks.Thread;
      return (IBindingNamedWithOrOnSyntax<T>) this;
    }

    public IBindingNamedWithOrOnSyntax<T> InScope(Func<IContext, object> scope)
    {
      this.Binding.ScopeCallback = scope;
      return (IBindingNamedWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithConstructorArgument(string name, object value)
    {
      this.Binding.Parameters.Add((IParameter) new ConstructorArgument(name, value));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithConstructorArgument(string name, Func<IContext, object> callback)
    {
      this.Binding.Parameters.Add((IParameter) new ConstructorArgument(name, callback));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithConstructorArgument(string name, Func<IContext, ITarget, object> callback)
    {
      this.Binding.Parameters.Add((IParameter) new ConstructorArgument(name, callback));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithPropertyValue(string name, object value)
    {
      this.Binding.Parameters.Add((IParameter) new PropertyValue(name, value));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithPropertyValue(string name, Func<IContext, object> callback)
    {
      this.Binding.Parameters.Add((IParameter) new PropertyValue(name, callback));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithPropertyValue(string name, Func<IContext, ITarget, object> callback)
    {
      this.Binding.Parameters.Add((IParameter) new PropertyValue(name, callback));
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithParameter(IParameter parameter)
    {
      this.Binding.Parameters.Add(parameter);
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingWithOrOnSyntax<T> WithMetadata(string key, object value)
    {
      this.Binding.Metadata.Set(key, value);
      return (IBindingWithOrOnSyntax<T>) this;
    }

    public IBindingOnSyntax<T> OnActivation(Action<T> action)
    {
      this.Binding.ActivationActions.Add((Action<IContext, object>) ((context, instance) => action((T) instance)));
      return (IBindingOnSyntax<T>) this;
    }

    public IBindingOnSyntax<T> OnActivation(Action<IContext, T> action)
    {
      this.Binding.ActivationActions.Add((Action<IContext, object>) ((context, instance) => action(context, (T) instance)));
      return (IBindingOnSyntax<T>) this;
    }

    public IBindingOnSyntax<T> OnDeactivation(Action<T> action)
    {
      this.Binding.DeactivationActions.Add((Action<IContext, object>) ((context, instance) => action((T) instance)));
      return (IBindingOnSyntax<T>) this;
    }

    public IBindingOnSyntax<T> OnDeactivation(Action<IContext, T> action)
    {
      this.Binding.DeactivationActions.Add((Action<IContext, object>) ((context, instance) => action(context, (T) instance)));
      return (IBindingOnSyntax<T>) this;
    }

    private void AddConstructorArguments(NewExpression ctorExpression, ParameterExpression constructorArgumentSyntaxParameterExpression)
    {
      ParameterInfo[] parameters = ctorExpression.Constructor.GetParameters();
      for (int index = 0; index < ctorExpression.Arguments.Count; ++index)
        this.AddConstructorArgument(ctorExpression.Arguments[index], parameters[index].Name, constructorArgumentSyntaxParameterExpression);
    }

    private void AddConstructorArgument(Expression argument, string argumentName, ParameterExpression constructorArgumentSyntaxParameterExpression)
    {
      MethodCallExpression methodCallExpression = argument as MethodCallExpression;
      if (methodCallExpression != null && !(methodCallExpression.Method.GetGenericMethodDefinition().DeclaringType != typeof (IConstructorArgumentSyntax)))
        return;
      Delegate compiledExpression = Expression.Lambda(argument, new ParameterExpression[1]
      {
        constructorArgumentSyntaxParameterExpression
      }).Compile();
      this.Binding.Parameters.Add((IParameter) new ConstructorArgument(argumentName, (Func<IContext, object>) (ctx => compiledExpression.DynamicInvoke(new object[1]
      {
        (object) new BindingBuilder<T>.ConstructorArgumentSyntax(ctx)
      }))));
    }

    Type IFluentSyntax.GetType()
    {
      return this.GetType();
    }

    private class ConstructorArgumentSyntax : IConstructorArgumentSyntax
    {
      public IContext Context { get; private set; }

      public ConstructorArgumentSyntax(IContext context)
      {
        this.Context = context;
      }

      public T1 Inject<T1>()
      {
        throw new InvalidOperationException("This method is for declaration that a parameter shall be injected only!");
      }
    }
  }
}
