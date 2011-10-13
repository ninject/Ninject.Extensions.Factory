// Type: Ninject.Syntax.IResolutionRoot
// Assembly: Ninject, Version=2.3.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\lib\Ninject\net-4.0\Ninject.dll

using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using System;
using System.Collections.Generic;

namespace Ninject.Syntax
{
  public interface IResolutionRoot
  {
    bool CanResolve(IRequest request);

    IEnumerable<object> Resolve(IRequest request);

    IRequest CreateRequest(Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique);
  }
}
