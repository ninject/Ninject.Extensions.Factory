// Type: Castle.DynamicProxy.IProxyBuilder
// Assembly: Castle.Core, Version=2.5.1.0, Culture=neutral, PublicKeyToken=407dd0808d44fbdc
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\lib\Castle-DynamicProxy\net-4.0\Castle.Core.dll

using Castle.Core.Logging;
using System;

namespace Castle.DynamicProxy
{
  public interface IProxyBuilder
  {
    ILogger Logger { get; set; }

    ModuleScope ModuleScope { get; }

    [Obsolete("Use CreateClassProxyType method instead.")]
    Type CreateClassProxy(Type classToProxy, ProxyGenerationOptions options);

    [Obsolete("Use CreateClassProxyType method instead.")]
    Type CreateClassProxy(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

    Type CreateClassProxyType(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

    Type CreateInterfaceProxyTypeWithTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, Type targetType, ProxyGenerationOptions options);

    Type CreateInterfaceProxyTypeWithoutTarget(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

    Type CreateInterfaceProxyTypeWithTargetInterface(Type interfaceToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);

    Type CreateClassProxyTypeWithTarget(Type classToProxy, Type[] additionalInterfacesToProxy, ProxyGenerationOptions options);
  }
}
