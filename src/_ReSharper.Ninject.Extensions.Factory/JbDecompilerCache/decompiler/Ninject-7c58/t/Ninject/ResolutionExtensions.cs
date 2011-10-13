// Type: Ninject.ResolutionExtensions
// Assembly: Ninject, Version=2.3.0.0, Culture=neutral, PublicKeyToken=c7192dc5380945e7
// Assembly location: C:\Projects\Ninject\ninject.extensions.factory\lib\Ninject\net-4.0\Ninject.dll

using Ninject.Activation;
using Ninject.Infrastructure;
using Ninject.Parameters;
using Ninject.Planning.Bindings;
using Ninject.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ninject
{
  public static class ResolutionExtensions
  {
    public static T Get<T>(this IResolutionRoot root, params IParameter[] parameters)
    {
      return Enumerable.Single<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, false, true)));
    }

    public static T Get<T>(this IResolutionRoot root, string name, params IParameter[] parameters)
    {
      return Enumerable.Single<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, false, true)));
    }

    public static T Get<T>(this IResolutionRoot root, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return Enumerable.Single<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), constraint, (IEnumerable<IParameter>) parameters, false, true)));
    }

    public static T TryGet<T>(this IResolutionRoot root, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, true, true)));
    }

    public static T TryGet<T>(this IResolutionRoot root, string name, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, true, true)));
    }

    public static T TryGet<T>(this IResolutionRoot root, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<T>(Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), constraint, (IEnumerable<IParameter>) parameters, true, true)));
    }

    public static IEnumerable<T> GetAll<T>(this IResolutionRoot root, params IParameter[] parameters)
    {
      return Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, true, false));
    }

    public static IEnumerable<T> GetAll<T>(this IResolutionRoot root, string name, params IParameter[] parameters)
    {
      return Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, true, false));
    }

    public static IEnumerable<T> GetAll<T>(this IResolutionRoot root, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return Enumerable.Cast<T>((IEnumerable) ResolutionExtensions.GetResolutionIterator(root, typeof (T), constraint, (IEnumerable<IParameter>) parameters, true, false));
    }

    public static object Get(this IResolutionRoot root, Type service, params IParameter[] parameters)
    {
      return Enumerable.Single<object>(ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, false, true));
    }

    public static object Get(this IResolutionRoot root, Type service, string name, params IParameter[] parameters)
    {
      return Enumerable.Single<object>(ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, false, true));
    }

    public static object Get(this IResolutionRoot root, Type service, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return Enumerable.Single<object>(ResolutionExtensions.GetResolutionIterator(root, service, constraint, (IEnumerable<IParameter>) parameters, false, true));
    }

    public static object TryGet(this IResolutionRoot root, Type service, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<object>(ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, true, true));
    }

    public static object TryGet(this IResolutionRoot root, Type service, string name, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<object>(ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, true, false));
    }

    public static object TryGet(this IResolutionRoot root, Type service, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return ResolutionExtensions.TryGet<object>(ResolutionExtensions.GetResolutionIterator(root, service, constraint, (IEnumerable<IParameter>) parameters, true, false));
    }

    public static IEnumerable<object> GetAll(this IResolutionRoot root, Type service, params IParameter[] parameters)
    {
      return ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) null, (IEnumerable<IParameter>) parameters, true, false);
    }

    public static IEnumerable<object> GetAll(this IResolutionRoot root, Type service, string name, params IParameter[] parameters)
    {
      return ResolutionExtensions.GetResolutionIterator(root, service, (Func<IBindingMetadata, bool>) (b => b.Name == name), (IEnumerable<IParameter>) parameters, true, false);
    }

    public static IEnumerable<object> GetAll(this IResolutionRoot root, Type service, Func<IBindingMetadata, bool> constraint, params IParameter[] parameters)
    {
      return ResolutionExtensions.GetResolutionIterator(root, service, constraint, (IEnumerable<IParameter>) parameters, true, false);
    }

    private static IEnumerable<object> GetResolutionIterator(IResolutionRoot root, Type service, Func<IBindingMetadata, bool> constraint, IEnumerable<IParameter> parameters, bool isOptional, bool isUnique)
    {
      Ensure.ArgumentNotNull((object) root, "root");
      Ensure.ArgumentNotNull((object) service, "service");
      Ensure.ArgumentNotNull((object) parameters, "parameters");
      IRequest request = root.CreateRequest(service, constraint, parameters, isOptional, isUnique);
      return root.Resolve(request);
    }

    private static T TryGet<T>(IEnumerable<T> iterator)
    {
      try
      {
        return Enumerable.SingleOrDefault<T>(iterator);
      }
      catch (ActivationException ex)
      {
        return default (T);
      }
    }
  }
}
