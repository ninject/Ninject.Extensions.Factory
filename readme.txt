This Ninject extension allows that child kernels can be defined. A child kernel is a 
Ninject kernel that has a parent kernel. All requests that it cant resolve are passed
to the parent kernel.

Restrictions:
- Objects that are resolved by the parent kernel can not have any dependency to an object
  defined on a child kernel. This is by design. Otherwise it would be possible to access
  objects on another child kernel if the object is defined as singleton.
- The default behavior of Ninject that classes are bound to themself if not explicit exists
  is still exists. But in this case this will be done by the top most parent. This means that
  this class can not have any dependency defined on a child kernel. I strongly suggest to
  have a binding for all objects that are resolved by ninject and not to use this default behavior.

Example:
public class Foo
  public Foo(IBar bar)
  {
    this.Bar = bar;
  }

  public IBar Bar { get; private set; }
}

public class Bar
{
}

var parentKernel = new StandardKernel();
parentKernel.Bind<Bar>().ToSelf().InSingletonScope();

var childKernel1 = new ChildKernel(this.parentKernel);
childKernel1.Bind<IFoo>().ToSelf().InSingletonScope();

var childKernel1 = new ChildKernel(this.parentKernel);
childKernel2.Bind<IFoo>().ToSelf().InSingletonScope();

var foo1 = childKernel1.Get<Foo>();
var foo2 = childKernel2.Get<Foo>();
var foo3 = childKernel1.Get<Foo>();

In this example foo1 and foo2 will be different instances. foo1 and foo3 is the same instance. And all share the same bar.