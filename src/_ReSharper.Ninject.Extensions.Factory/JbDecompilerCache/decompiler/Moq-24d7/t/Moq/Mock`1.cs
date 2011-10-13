// Type: Moq.Mock`1
// Assembly: Moq, Version=4.0.10827.0, Culture=neutral, PublicKeyToken=69f491c39445e920
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\tools\moq\NET40\Moq.dll

using Moq.Language;
using Moq.Language.Flow;
using Moq.Properties;
using Moq.Proxy;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace Moq
{
  public class Mock<T> : Mock where T : class
  {
    private static IProxyFactory proxyFactory = (IProxyFactory) new CastleProxyFactory();
    private T instance;
    private object[] constructorArguments;

    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Exposes the mocked object instance, so it's appropriate.", MessageId = "Object")]
    [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "The public Object property is the only one visible to Moq consumers. The protected member is for internal use only.")]
    public virtual T Object
    {
      get
      {
        return (T) base.Object;
      }
    }

    internal override Type MockedType
    {
      get
      {
        return typeof (T);
      }
    }

    static Mock()
    {
    }

    [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "skipInitialize")]
    internal Mock(bool skipInitialize)
    {
    }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Mock()
      : this(MockBehavior.Loose)
    {
    }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Mock(params object[] args)
      : this(MockBehavior.Loose, args)
    {
    }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Mock(MockBehavior behavior)
      : this(behavior, new object[0])
    {
    }

    [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Mock(MockBehavior behavior, params object[] args)
    {
      if (args == null)
        args = new object[1];
      this.Behavior = behavior;
      this.Interceptor = new Moq.Interceptor(behavior, typeof (T), (Mock) this);
      this.constructorArguments = args;
      this.ImplementedInterfaces.Add(typeof (IMocked<T>));
      this.CheckParameters();
    }

    [Obsolete("Expect has been renamed to Setup.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ISetup<T> Expect(Expression<Action<T>> expression)
    {
      return this.Setup(expression);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Expect has been renamed to Setup.", false)]
    public ISetup<T, TResult> Expect<TResult>(Expression<Func<T, TResult>> expression)
    {
      return this.Setup<TResult>(expression);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ExpectGet has been renamed to SetupGet.", false)]
    public ISetupGetter<T, TProperty> ExpectGet<TProperty>(Expression<Func<T, TProperty>> expression)
    {
      return this.SetupGet<TProperty>(expression);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("ExpectSet has been renamed to SetupSet.", false)]
    public ISetupSetter<T, TProperty> ExpectSet<TProperty>(Expression<Func<T, TProperty>> expression)
    {
      return (ISetupSetter<T, TProperty>) Mock.SetupSet<T, TProperty>((Mock) this, expression);
    }

    [Obsolete("ExpectSet has been renamed to SetupSet, and the new syntax allows you to pass the value in the expression itself, like f => f.Value = 25.", true)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ISetupSetter<T, TProperty> ExpectSet<TProperty>(Expression<Func<T, TProperty>> expression, TProperty value)
    {
      return (ISetupSetter<T, TProperty>) Mock.SetupSet<T, TProperty>((Mock) this, expression, value);
    }

    private void CheckParameters()
    {
      Extensions.ThrowIfNotMockeable(typeof (T));
      if (typeof (T).IsInterface && this.constructorArguments.Length > 0)
        throw new ArgumentException(Resources.ConstructorArgsForInterface);
    }

    private void InitializeInstance()
    {
      PexProtector.Invoke((Action) (() => this.instance = Mock<T>.proxyFactory.CreateProxy<T>((ICallInterceptor) this.Interceptor, this.ImplementedInterfaces.ToArray(), this.constructorArguments)));
    }

    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is actually the protected virtual implementation of the property Object.")]
    protected override object OnGetObject()
    {
      if ((object) this.instance == null)
        this.InitializeInstance();
      return (object) this.instance;
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public ISetup<T> Setup(Expression<Action<T>> expression)
    {
      return (ISetup<T>) Mock.Setup<T>((Mock) this, expression, (Func<bool>) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public ISetup<T, TResult> Setup<TResult>(Expression<Func<T, TResult>> expression)
    {
      return (ISetup<T, TResult>) Mock.Setup<T, TResult>((Mock) this, expression, (Func<bool>) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public ISetupGetter<T, TProperty> SetupGet<TProperty>(Expression<Func<T, TProperty>> expression)
    {
      return (ISetupGetter<T, TProperty>) Mock.SetupGet<T, TProperty>((Mock) this, expression, (Func<bool>) null);
    }

    public ISetupSetter<T, TProperty> SetupSet<TProperty>(Action<T> setterExpression)
    {
      return (ISetupSetter<T, TProperty>) Mock.SetupSet<T, TProperty>(this, setterExpression, (Func<bool>) null);
    }

    public ISetup<T> SetupSet(Action<T> setterExpression)
    {
      return (ISetup<T>) Mock.SetupSet<T>(this, setterExpression, (Func<bool>) null);
    }

    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "This sets properties, so it's appropriate.", MessageId = "Property")]
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property)
    {
      return this.SetupProperty<TProperty>(property, default (TProperty));
    }

    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "We're setting up a property, so it's appropriate.", MessageId = "Property")]
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public Mock<T> SetupProperty<TProperty>(Expression<Func<T, TProperty>> property, TProperty initialValue)
    {
      this.SetupGet<TProperty>(property).Returns((Func<TProperty>) (() => initialValue));
      Mock.SetupSet<T, TProperty>((Mock) this, property).Callback((Action<TProperty>) (p => initialValue = p));
      return this;
    }

    public Mock<T> SetupAllProperties()
    {
      Mock.SetupAllProperties((Mock) this);
      return this;
    }

    public ISetupConditionResult<T> When(Func<bool> condition)
    {
      return (ISetupConditionResult<T>) new ConditionalContext<T>(this, condition);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify(Expression<Action<T>> expression)
    {
      Mock.Verify<T>((Mock) this, expression, Times.AtLeastOnce(), (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify(Expression<Action<T>> expression, Times times)
    {
      Mock.Verify<T>((Mock) this, expression, times, (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify(Expression<Action<T>> expression, string failMessage)
    {
      Mock.Verify<T>((Mock) this, expression, Times.AtLeastOnce(), failMessage);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify(Expression<Action<T>> expression, Times times, string failMessage)
    {
      Mock.Verify<T>((Mock) this, expression, times, failMessage);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify<TResult>(Expression<Func<T, TResult>> expression)
    {
      Mock.Verify<T, TResult>((Mock) this, expression, Times.AtLeastOnce(), (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify<TResult>(Expression<Func<T, TResult>> expression, Times times)
    {
      Mock.Verify<T, TResult>((Mock) this, expression, times, (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify<TResult>(Expression<Func<T, TResult>> expression, string failMessage)
    {
      Mock.Verify<T, TResult>((Mock) this, expression, Times.AtLeastOnce(), failMessage);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void Verify<TResult>(Expression<Func<T, TResult>> expression, Times times, string failMessage)
    {
      Mock.Verify<T, TResult>((Mock) this, expression, times, failMessage);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression)
    {
      Mock.VerifyGet<T, TProperty>((Mock) this, expression, Times.AtLeastOnce(), (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times)
    {
      Mock.VerifyGet<T, TProperty>((Mock) this, expression, times, (string) null);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, string failMessage)
    {
      Mock.VerifyGet<T, TProperty>((Mock) this, expression, Times.AtLeastOnce(), failMessage);
    }

    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "By design")]
    public void VerifyGet<TProperty>(Expression<Func<T, TProperty>> expression, Times times, string failMessage)
    {
      Mock.VerifyGet<T, TProperty>((Mock) this, expression, times, failMessage);
    }

    public void VerifySet(Action<T> setterExpression)
    {
      Mock.VerifySet<T>(this, setterExpression, Times.AtLeastOnce(), (string) null);
    }

    public void VerifySet(Action<T> setterExpression, Times times)
    {
      Mock.VerifySet<T>(this, setterExpression, times, (string) null);
    }

    public void VerifySet(Action<T> setterExpression, string failMessage)
    {
      Mock.VerifySet<T>(this, setterExpression, Times.AtLeastOnce(), failMessage);
    }

    public void VerifySet(Action<T> setterExpression, Times times, string failMessage)
    {
      Mock.VerifySet<T>(this, setterExpression, times, failMessage);
    }

    [SuppressMessage("Microsoft.Usage", "CA2200:RethrowToPreserveStackDetails", Justification = "We want to reset the stack trace to avoid Moq noise in it.")]
    [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Raises the event, rather than being one.")]
    public void Raise(Action<T> eventExpression, EventArgs args)
    {
      EventInfo @event = Extensions.GetEvent<T>(eventExpression, this.Object);
      try
      {
        this.DoRaise(@event, args);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Raises the event, rather than being one.")]
    [SuppressMessage("Microsoft.Usage", "CA2200:RethrowToPreserveStackDetails", Justification = "We want to reset the stack trace to avoid Moq noise in it.")]
    public void Raise(Action<T> eventExpression, params object[] args)
    {
      EventInfo @event = Extensions.GetEvent<T>(eventExpression, this.Object);
      try
      {
        this.DoRaise(@event, args);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
