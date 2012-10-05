﻿// Copyright (c) rubicon IT GmbH, www.rubicon.eu
//
// See the NOTICE file distributed with this work for additional information
// regarding copyright ownership.  rubicon licenses this file to you under 
// the Apache License, Version 2.0 (the "License"); you may not use this 
// file except in compliance with the License.  You may obtain a copy of the 
// License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.  See the 
// License for the specific language governing permissions and limitations
// under the License.
// 
using System;
using System.Reflection;
using Microsoft.Scripting.Ast;
using Remotion.Utilities;

namespace Remotion.TypePipe.Expressions
{
  /// <summary>
  /// Represents the instantiation of a delegate.
  /// </summary>
  public class NewDelegateExpression : TypePipeExpressionBase
  {
    private readonly Expression _target;
    private readonly MethodInfo _method;

    public NewDelegateExpression (Type delegateType, Expression target, MethodInfo method)
        : base (ArgumentUtility.CheckNotNull ("delegateType", delegateType))
    {
      // target may be null for static methods
      ArgumentUtility.CheckNotNull ("method", method);
      Assertion.IsNotNull (method.DeclaringType);

      if (!delegateType.IsSubclassOf (typeof (Delegate)))
        throw new ArgumentException ("Delegate type must be subclass of 'System.Delegate'.", "delegateType");

      if (!method.IsStatic && target == null)
        throw new ArgumentException ("Instance method requires target.", "method");

      if (target != null && !method.DeclaringType.IsAssignableFrom (target.Type))
        throw new ArgumentException ("Method is not declared on type hierarchy of target.", "method");

      _target = target;
      _method = method;
    }

    public Expression Target
    {
      get { return _target; }
    }

    public MethodInfo Method
    {
      get { return _method; }
    }

    public override bool CanReduce
    {
      get { return true; }
    }

    public override Expression Reduce ()
    {
      var constructor = Type.GetConstructor (new[] { typeof (object), typeof (IntPtr) });
      var methodAddress = _method.IsVirtual
                              ? (Expression) new VirtualMethodAddressExpression (_target, _method)
                              : new NonVirtualMethodAddressExpression (_method);
      var target = _target ?? Expression.Constant (null, typeof (object));

      return Expression.New (constructor, target, methodAddress);
    }

    public override Expression Accept (ITypePipeExpressionVisitor visitor)
    {
      ArgumentUtility.CheckNotNull ("visitor", visitor);

      return visitor.VisitNewDelegate (this);
    }

    protected internal override Expression VisitChildren (ExpressionVisitor visitor)
    {
      ArgumentUtility.CheckNotNull ("visitor", visitor);

      var newTarget = visitor.Visit (_target);
      if (newTarget != _target)
        return new NewDelegateExpression (Type, newTarget, _method);
      else
        return this;
    }
  }
}