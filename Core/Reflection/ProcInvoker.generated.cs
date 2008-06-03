//------------------------------------------------------------------------------
// This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if 
// the code is regenerated.
//
//------------------------------------------------------------------------------
/* Copyright (C) 2005 - 2008 rubicon informationstechnologie gmbh
 *
 * This program is free software: you can redistribute it and/or modify it under 
 * the terms of the re:motion license agreement in license.txt. If you did not 
 * receive it, please visit http://www.re-motion.org/licensing.
 * 
 * Unless otherwise provided, this software is distributed on an "AS IS" basis, 
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. 
 */

using System;
using Remotion.Utilities;
using System.Reflection;

namespace Remotion.Reflection
{

  public partial struct ProcInvoker : IProcInvoker
  {
    private DelegateSelector _delegateSelector;


    private const int c_argCount = 0;

    public ProcInvoker (DelegateSelector delegateSelector)
    {
      _delegateSelector = delegateSelector;
    }

#pragma warning disable 162 // disable unreachable code warning. 
    private Type[] GetValueTypes (Type[] valueTypes)
    {
      if (c_argCount == 0)
        return valueTypes;
      Type[] fixedArgTypes = new Type[] {  };
      return ArrayUtility.Combine (fixedArgTypes, valueTypes);
    }

    private object[] GetValues (object[] values)
    {
      if (c_argCount == 0)
        return values;
      object[] fixedArgs = new object[] {  };
      return ArrayUtility.Combine (fixedArgs, values);
    }
#pragma warning restore 162

    public void Invoke (Type[] valueTypes, object[] values)
    {
      InvokerUtility.CheckInvokeArguments (valueTypes, values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public void Invoke (object[] values)
    {
      Type[] valueTypes = InvokerUtility.GetValueTypes (values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public Delegate GetDelegate (params Type[] parameterTypes)
    {
      return GetDelegate (ProcDelegates.MakeClosedType (parameterTypes));
    }

    public TDelegate GetDelegate<TDelegate> ()
    {
      return (TDelegate) (object) GetDelegate (typeof (TDelegate));
    }

    public Delegate GetDelegate (Type delegateType)
    {
      return _delegateSelector (delegateType);
    }

    public void With ()
    {
      GetDelegateWith () ();
    }

    public Proc GetDelegateWith ()
    {
      return GetDelegate<Proc> ();
    }
  }

  public partial struct ProcInvoker<TFixedArg1, TFixedArg2> : IProcInvoker
  {
    private DelegateSelector _delegateSelector;

    private TFixedArg1 _fixedArg1;
    private TFixedArg2 _fixedArg2;

    private const int c_argCount = 2;

    public ProcInvoker (DelegateSelector delegateSelector, TFixedArg1 fixedArg1, TFixedArg2 fixedArg2)
    {
      _delegateSelector = delegateSelector;
      _fixedArg1 = fixedArg1;
      _fixedArg2 = fixedArg2;
    }

#pragma warning disable 162 // disable unreachable code warning. 
    private Type[] GetValueTypes (Type[] valueTypes)
    {
      if (c_argCount == 0)
        return valueTypes;
      Type[] fixedArgTypes = new Type[] { typeof (TFixedArg1), typeof (TFixedArg2) };
      return ArrayUtility.Combine (fixedArgTypes, valueTypes);
    }

    private object[] GetValues (object[] values)
    {
      if (c_argCount == 0)
        return values;
      object[] fixedArgs = new object[] { _fixedArg1, _fixedArg2 };
      return ArrayUtility.Combine (fixedArgs, values);
    }
#pragma warning restore 162

    public void Invoke (Type[] valueTypes, object[] values)
    {
      InvokerUtility.CheckInvokeArguments (valueTypes, values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public void Invoke (object[] values)
    {
      Type[] valueTypes = InvokerUtility.GetValueTypes (values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public Delegate GetDelegate (params Type[] parameterTypes)
    {
      return GetDelegate (ProcDelegates.MakeClosedType (parameterTypes));
    }

    public TDelegate GetDelegate<TDelegate> ()
    {
      return (TDelegate) (object) GetDelegate (typeof (TDelegate));
    }

    public Delegate GetDelegate (Type delegateType)
    {
      return _delegateSelector (delegateType);
    }

    public void With ()
    {
      GetDelegateWith () (_fixedArg1, _fixedArg2);
    }

    public Proc<TFixedArg1, TFixedArg2> GetDelegateWith ()
    {
      return GetDelegate<Proc<TFixedArg1, TFixedArg2>> ();
    }
  }

  public partial struct ProcInvoker<TFixedArg1, TFixedArg2, TFixedArg3> : IProcInvoker
  {
    private DelegateSelector _delegateSelector;

    private TFixedArg1 _fixedArg1;
    private TFixedArg2 _fixedArg2;
    private TFixedArg3 _fixedArg3;

    private const int c_argCount = 3;

    public ProcInvoker (DelegateSelector delegateSelector, TFixedArg1 fixedArg1, TFixedArg2 fixedArg2, TFixedArg3 fixedArg3)
    {
      _delegateSelector = delegateSelector;
      _fixedArg1 = fixedArg1;
      _fixedArg2 = fixedArg2;
      _fixedArg3 = fixedArg3;
    }

#pragma warning disable 162 // disable unreachable code warning. 
    private Type[] GetValueTypes (Type[] valueTypes)
    {
      if (c_argCount == 0)
        return valueTypes;
      Type[] fixedArgTypes = new Type[] { typeof (TFixedArg1), typeof (TFixedArg2), typeof (TFixedArg3) };
      return ArrayUtility.Combine (fixedArgTypes, valueTypes);
    }

    private object[] GetValues (object[] values)
    {
      if (c_argCount == 0)
        return values;
      object[] fixedArgs = new object[] { _fixedArg1, _fixedArg2, _fixedArg3 };
      return ArrayUtility.Combine (fixedArgs, values);
    }
#pragma warning restore 162

    public void Invoke (Type[] valueTypes, object[] values)
    {
      InvokerUtility.CheckInvokeArguments (valueTypes, values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public void Invoke (object[] values)
    {
      Type[] valueTypes = InvokerUtility.GetValueTypes (values);
      GetDelegate (GetValueTypes (valueTypes)).DynamicInvoke (GetValues (values));
    }

    public Delegate GetDelegate (params Type[] parameterTypes)
    {
      return GetDelegate (ProcDelegates.MakeClosedType (parameterTypes));
    }

    public TDelegate GetDelegate<TDelegate> ()
    {
      return (TDelegate) (object) GetDelegate (typeof (TDelegate));
    }

    public Delegate GetDelegate (Type delegateType)
    {
      return _delegateSelector (delegateType);
    }

    public void With ()
    {
      GetDelegateWith () (_fixedArg1, _fixedArg2, _fixedArg3);
    }

    public Proc<TFixedArg1, TFixedArg2, TFixedArg3> GetDelegateWith ()
    {
      return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3>> ();
    }
  }



    public partial struct ProcInvoker
    {


        public void With<A1> (A1 a1)
        {
          GetDelegateWith<A1> () (a1);
        }

        public Proc<A1> GetDelegateWith<A1> ()
        {
          return GetDelegate<Proc<A1>> ();
        }

        public void With<A1, A2> (A1 a1, A2 a2)
        {
          GetDelegateWith<A1, A2> () (a1, a2);
        }

        public Proc<A1, A2> GetDelegateWith<A1, A2> ()
        {
          return GetDelegate<Proc<A1, A2>> ();
        }

        public void With<A1, A2, A3> (A1 a1, A2 a2, A3 a3)
        {
          GetDelegateWith<A1, A2, A3> () (a1, a2, a3);
        }

        public Proc<A1, A2, A3> GetDelegateWith<A1, A2, A3> ()
        {
          return GetDelegate<Proc<A1, A2, A3>> ();
        }

        public void With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4)
        {
          GetDelegateWith<A1, A2, A3, A4> () (a1, a2, a3, a4);
        }

        public Proc<A1, A2, A3, A4> GetDelegateWith<A1, A2, A3, A4> ()
        {
          return GetDelegate<Proc<A1, A2, A3, A4>> ();
        }

        public void With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
        {
          GetDelegateWith<A1, A2, A3, A4, A5> () (a1, a2, a3, a4, a5);
        }

        public Proc<A1, A2, A3, A4, A5> GetDelegateWith<A1, A2, A3, A4, A5> ()
        {
          return GetDelegate<Proc<A1, A2, A3, A4, A5>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6> () (a1, a2, a3, a4, a5, a6);
        }

        public Proc<A1, A2, A3, A4, A5, A6> GetDelegateWith<A1, A2, A3, A4, A5, A6> ()
        {
          return GetDelegate<Proc<A1, A2, A3, A4, A5, A6>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> () (a1, a2, a3, a4, a5, a6, a7);
        }

        public Proc<A1, A2, A3, A4, A5, A6, A7> GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> ()
        {
          return GetDelegate<Proc<A1, A2, A3, A4, A5, A6, A7>> ();
        }
    }

    public partial struct ProcInvoker<TFixedArg1>
    {


        public void With<A1, A2> (A1 a1, A2 a2)
        {
          GetDelegateWith<A1, A2> () (_fixedArg1, a1, a2);
        }

        public Proc<TFixedArg1, A1, A2> GetDelegateWith<A1, A2> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2>> ();
        }

        public void With<A1, A2, A3> (A1 a1, A2 a2, A3 a3)
        {
          GetDelegateWith<A1, A2, A3> () (_fixedArg1, a1, a2, a3);
        }

        public Proc<TFixedArg1, A1, A2, A3> GetDelegateWith<A1, A2, A3> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2, A3>> ();
        }

        public void With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4)
        {
          GetDelegateWith<A1, A2, A3, A4> () (_fixedArg1, a1, a2, a3, a4);
        }

        public Proc<TFixedArg1, A1, A2, A3, A4> GetDelegateWith<A1, A2, A3, A4> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2, A3, A4>> ();
        }

        public void With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
        {
          GetDelegateWith<A1, A2, A3, A4, A5> () (_fixedArg1, a1, a2, a3, a4, a5);
        }

        public Proc<TFixedArg1, A1, A2, A3, A4, A5> GetDelegateWith<A1, A2, A3, A4, A5> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2, A3, A4, A5>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6> () (_fixedArg1, a1, a2, a3, a4, a5, a6);
        }

        public Proc<TFixedArg1, A1, A2, A3, A4, A5, A6> GetDelegateWith<A1, A2, A3, A4, A5, A6> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2, A3, A4, A5, A6>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> () (_fixedArg1, a1, a2, a3, a4, a5, a6, a7);
        }

        public Proc<TFixedArg1, A1, A2, A3, A4, A5, A6, A7> GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> ()
        {
          return GetDelegate<Proc<TFixedArg1, A1, A2, A3, A4, A5, A6, A7>> ();
        }
    }

    public partial struct ProcInvoker<TFixedArg1, TFixedArg2>
    {


        public void With<A1> (A1 a1)
        {
          GetDelegateWith<A1> () (_fixedArg1, _fixedArg2, a1);
        }

        public Proc<TFixedArg1, TFixedArg2, A1> GetDelegateWith<A1> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1>> ();
        }

        public void With<A1, A2> (A1 a1, A2 a2)
        {
          GetDelegateWith<A1, A2> () (_fixedArg1, _fixedArg2, a1, a2);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2> GetDelegateWith<A1, A2> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2>> ();
        }

        public void With<A1, A2, A3> (A1 a1, A2 a2, A3 a3)
        {
          GetDelegateWith<A1, A2, A3> () (_fixedArg1, _fixedArg2, a1, a2, a3);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2, A3> GetDelegateWith<A1, A2, A3> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2, A3>> ();
        }

        public void With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4)
        {
          GetDelegateWith<A1, A2, A3, A4> () (_fixedArg1, _fixedArg2, a1, a2, a3, a4);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4> GetDelegateWith<A1, A2, A3, A4> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4>> ();
        }

        public void With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
        {
          GetDelegateWith<A1, A2, A3, A4, A5> () (_fixedArg1, _fixedArg2, a1, a2, a3, a4, a5);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5> GetDelegateWith<A1, A2, A3, A4, A5> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6> () (_fixedArg1, _fixedArg2, a1, a2, a3, a4, a5, a6);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5, A6> GetDelegateWith<A1, A2, A3, A4, A5, A6> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5, A6>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> () (_fixedArg1, _fixedArg2, a1, a2, a3, a4, a5, a6, a7);
        }

        public Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5, A6, A7> GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, A1, A2, A3, A4, A5, A6, A7>> ();
        }
    }

    public partial struct ProcInvoker<TFixedArg1, TFixedArg2, TFixedArg3>
    {


        public void With<A1> (A1 a1)
        {
          GetDelegateWith<A1> () (_fixedArg1, _fixedArg2, _fixedArg3, a1);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1> GetDelegateWith<A1> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1>> ();
        }

        public void With<A1, A2> (A1 a1, A2 a2)
        {
          GetDelegateWith<A1, A2> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2> GetDelegateWith<A1, A2> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2>> ();
        }

        public void With<A1, A2, A3> (A1 a1, A2 a2, A3 a3)
        {
          GetDelegateWith<A1, A2, A3> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2, a3);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3> GetDelegateWith<A1, A2, A3> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3>> ();
        }

        public void With<A1, A2, A3, A4> (A1 a1, A2 a2, A3 a3, A4 a4)
        {
          GetDelegateWith<A1, A2, A3, A4> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2, a3, a4);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4> GetDelegateWith<A1, A2, A3, A4> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4>> ();
        }

        public void With<A1, A2, A3, A4, A5> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
        {
          GetDelegateWith<A1, A2, A3, A4, A5> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2, a3, a4, a5);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5> GetDelegateWith<A1, A2, A3, A4, A5> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2, a3, a4, a5, a6);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5, A6> GetDelegateWith<A1, A2, A3, A4, A5, A6> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5, A6>> ();
        }

        public void With<A1, A2, A3, A4, A5, A6, A7> (A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
        {
          GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> () (_fixedArg1, _fixedArg2, _fixedArg3, a1, a2, a3, a4, a5, a6, a7);
        }

        public Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5, A6, A7> GetDelegateWith<A1, A2, A3, A4, A5, A6, A7> ()
        {
          return GetDelegate<Proc<TFixedArg1, TFixedArg2, TFixedArg3, A1, A2, A3, A4, A5, A6, A7>> ();
        }
    }
}
