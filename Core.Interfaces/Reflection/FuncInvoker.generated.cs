//------------------------------------------------------------------------------
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated.
//
//------------------------------------------------------------------------------
using System;

namespace Remotion.Reflection
{
  /// <summary>
  /// This interface allows invokers with fixed arguments to be returned without references to their generic argument types. 
  /// </summary>
  /// <remarks>
  /// <p>Note that casting a <c>FuncInvoker</c> struct to an interface is a boxing operation, thus creating an object on the
  /// heap and garbage collecting it later. For very performance-critical scenarios, it be better to avoid this and accept the references to 
  /// the invoker's generic argument types.</p>
  /// <p>It is recommended to wrap this interface within a <see cref="FuncInvokerWrapper{TResult}"/>, because returning an interface could lead to 
  /// ambigous castings if the final call to <see cref="With{A1}"/> is missing, while using structs will usually lead to a compile-time error as 
  /// expected.</p>
  /// </remarks>
  /// <typeparam name="TResult"> Return type of the method that will be invoked. </typeparam>
  public partial interface IFuncInvoker<TResult>
  {


    TResult With ();

    TResult With<A1, A2> (A1 a1, A2 a2);

    TResult With<A1, A2, A3> (A1 a1, A2 a2, A3 a3);

    TResult With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4);

    TResult With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5);

    TResult With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6);

    TResult With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7);
  }

  /// <summary>
  /// Used to wrap an <see cref="IFuncInvoker{TResult}"/> object rather than returning it directly.
  /// </summary>
  /// <typeparam name="TResult"> Return type of the method that will be invoked. </typeparam>
  public partial struct FuncInvokerWrapper<TResult> : IFuncInvoker<TResult>
  {


    public TResult With ()
    {
      return PerformAfterAction (_invoker.With ());
    }


    public TResult With<A1, A2> (A1 a1, A2 a2)
    {
      return PerformAfterAction (_invoker.With (a1, a2));
    }


    public TResult With<A1, A2, A3> (A1 a1, A2 a2, A3 a3)
    {
      return PerformAfterAction (_invoker.With (a1, a2, a3));
    }


    public TResult With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4)
    {
      return PerformAfterAction (_invoker.With (a1, a2, a3, a4));
    }


    public TResult With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
    {
      return PerformAfterAction (_invoker.With (a1, a2, a3, a4, a5));
    }


    public TResult With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
    {
      return PerformAfterAction (_invoker.With (a1, a2, a3, a4, a5, a6));
    }


    public TResult With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
    {
      return PerformAfterAction (_invoker.With (a1, a2, a3, a4, a5, a6, a7));
    }

  }
}
