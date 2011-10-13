// Type: Ninject.Parameters.Parameter
// Assembly: Ninject, Version=2.3.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\lib\Ninject\net-4.0\Ninject.dll

using Ninject.Activation;
using Ninject.Infrastructure;
using Ninject.Planning.Targets;
using System;

namespace Ninject.Parameters
{
  public class Parameter : IParameter, IEquatable<IParameter>
  {
    public string Name { get; private set; }

    public bool ShouldInherit { get; private set; }

    public Func<IContext, ITarget, object> ValueCallback { get; private set; }

    public Parameter(string name, object value, bool shouldInherit)
      : this(name, (Func<IContext, ITarget, object>) ((ctx, target) => value), shouldInherit)
    {
    }

    public Parameter(string name, Func<IContext, object> valueCallback, bool shouldInherit)
    {
      Ensure.ArgumentNotNullOrEmpty(name, "name");
      Ensure.ArgumentNotNull((object) valueCallback, "valueCallback");
      this.Name = name;
      this.ValueCallback = (Func<IContext, ITarget, object>) ((ctx, target) => valueCallback(ctx));
      this.ShouldInherit = shouldInherit;
    }

    public Parameter(string name, Func<IContext, ITarget, object> valueCallback, bool shouldInherit)
    {
      Ensure.ArgumentNotNullOrEmpty(name, "name");
      Ensure.ArgumentNotNull((object) valueCallback, "valueCallback");
      this.Name = name;
      this.ValueCallback = valueCallback;
      this.ShouldInherit = shouldInherit;
    }

    public object GetValue(IContext context, ITarget target)
    {
      Ensure.ArgumentNotNull((object) context, "context");
      return this.ValueCallback(context, target);
    }

    public override bool Equals(object obj)
    {
      IParameter other = obj as IParameter;
      if (other == null)
        return base.Equals(obj);
      else
        return this.Equals(other);
    }

    public override int GetHashCode()
    {
      return this.GetType().GetHashCode() ^ this.Name.GetHashCode();
    }

    public bool Equals(IParameter other)
    {
      if (other.GetType() == this.GetType())
        return other.Name.Equals(this.Name);
      else
        return false;
    }
  }
}
