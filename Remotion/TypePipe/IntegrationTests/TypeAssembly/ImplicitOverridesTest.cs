// Copyright (c) rubicon IT GmbH, www.rubicon.eu
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
using NUnit.Framework;
using Remotion.TypePipe.MutableReflection;
using System.Linq;

namespace Remotion.TypePipe.IntegrationTests.TypeAssembly
{
  [TestFixture]
  public class ImplicitOverridesTest : TypeAssemblerIntegrationTestBase
  {
    [Test]
    public void OverrideMethod ()
    {
      var overriddenMethod = GetDeclaredMethod (typeof (BaseType), "OverridableMethod");
      var type = AssembleType<DerivedTpe> (
          proxyType =>
          {
            var mutableMethod = proxyType.AddMethod (
                "OverridableMethod",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof (string),
                ParameterDeclaration.EmptyParameters,
                ctx =>
                {
                  Assert.That (ctx.HasBaseMethod, Is.True);
                  Assert.That (ctx.BaseMethod, Is.EqualTo (overriddenMethod));
                  return ExpressionHelper.StringConcat (ctx.CallBase (ctx.BaseMethod), Expression.Constant (" overridden"));
                });
            Assert.That (mutableMethod.BaseMethod, Is.EqualTo (overriddenMethod));
            Assert.That (mutableMethod.GetBaseDefinition (), Is.EqualTo (overriddenMethod));
            Assert.That (mutableMethod.AddedExplicitBaseDefinitions, Is.Empty);

            var methods = proxyType.GetMethods();
            Assert.That (methods.Where (mi => mi.Name == "OverridableMethod"), Is.EqualTo (new[] { mutableMethod }));
            Assert.That (methods, Has.No.Member (typeof (DerivedTpe).GetMethod ("OverridableMethod")));
          });

      var instance = (DerivedTpe) Activator.CreateInstance (type);
      var method = GetDeclaredMethod (type, "OverridableMethod");

      Assert.That (method.GetBaseDefinition (), Is.EqualTo (overriddenMethod));

      var result = method.Invoke (instance, null);
      Assert.That (result, Is.EqualTo ("BaseType overridden"));
      Assert.That (instance.OverridableMethod (), Is.EqualTo ("BaseType overridden"));
    }

    [Test]
    public void OverrideMethod_WithParameters ()
    {
      var overriddenMethod = GetDeclaredMethod (typeof (BaseType), "OverridableMethodWithParameters");
      var type = AssembleType<DerivedTpe> (
          proxyType =>
          {
            var mutableMethod = proxyType.AddMethod (
                "OverridableMethodWithParameters",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof (string),
                new[] { new ParameterDeclaration (typeof (string), "p1") },
                ctx =>
                {
                  Assert.That (ctx.HasBaseMethod, Is.True);
                  Assert.That (ctx.BaseMethod, Is.EqualTo (overriddenMethod));
                  return ExpressionHelper.StringConcat (
                      ctx.CallBase (ctx.BaseMethod, ctx.Parameters.Cast<Expression>()), Expression.Constant (" overridden"));
                });
            Assert.That (mutableMethod.BaseMethod, Is.EqualTo (overriddenMethod));
            Assert.That (mutableMethod.GetBaseDefinition (), Is.EqualTo (overriddenMethod));

            var methods = proxyType.GetMethods();
            Assert.That (methods.Where (mi => mi.Name == "OverridableMethodWithParameters"), Is.EqualTo (new[] { mutableMethod }));
            Assert.That (methods, Has.No.Member (typeof (DerivedTpe).GetMethod ("OverridableMethodWithParameters")));
          });

      var instance = (DerivedTpe) Activator.CreateInstance (type);
      var method = GetDeclaredMethod (type, "OverridableMethodWithParameters");

      Assert.That (method.GetBaseDefinition (), Is.EqualTo (overriddenMethod));

      var result = method.Invoke (instance, new object[] { "xxx" });
      Assert.That (result, Is.EqualTo ("BaseType xxx overridden"));
      Assert.That (instance.OverridableMethodWithParameters ("xxx"), Is.EqualTo ("BaseType xxx overridden"));
    }

    [Test]
    public void OverrideOverride ()
    {
      var overriddenMethodInBase = GetDeclaredMethod (typeof (BaseType), "MethodOverriddenInDerived");
      var overriddenMethodInDerived = GetDeclaredMethod (typeof (DerivedTpe), "MethodOverriddenInDerived");

      var type = AssembleType<DerivedTpe> (
          proxyType =>
          {
            var mutableMethod = proxyType.AddMethod (
                "MethodOverriddenInDerived",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof (string),
                ParameterDeclaration.EmptyParameters,
                ctx =>
                {
                  Assert.That (ctx.HasBaseMethod, Is.True);
                  Assert.That (ctx.BaseMethod, Is.EqualTo(overriddenMethodInDerived));
                  return ExpressionHelper.StringConcat (ctx.CallBase (ctx.BaseMethod), Expression.Constant (" overridden"));
                });
            Assert.That (mutableMethod.BaseMethod, Is.EqualTo (overriddenMethodInDerived));
            Assert.That (mutableMethod.GetBaseDefinition (), Is.EqualTo (overriddenMethodInBase));
          });

      var instance = (DerivedTpe) Activator.CreateInstance (type);
      var method = GetDeclaredMethod (type, "MethodOverriddenInDerived");

      Assert.That (method.GetBaseDefinition(), Is.EqualTo (overriddenMethodInBase));

      var result = method.Invoke (instance, null);
      Assert.That (result, Is.EqualTo ("DerivedTpe overridden"));
      Assert.That (instance.MethodOverriddenInDerived(), Is.EqualTo ("DerivedTpe overridden"));
    }

    [Test]
    public void Override_OutAndRefParameters ()
    {
      var overriddenMethod = GetDeclaredMethod (typeof (BaseType), "MethodWithOutAndRefParameters");

      var type = AssembleType<DerivedTpe> (p => p.GetOrAddOverride (overriddenMethod));

      var instance = (DerivedTpe) Activator.CreateInstance (type);
      var method = GetDeclaredMethod (type, "MethodWithOutAndRefParameters");

      Assert.That (method.GetBaseDefinition(), Is.EqualTo (overriddenMethod));

      var arguments = new object[] { 0, "hello" };
      var result = method.Invoke (instance, arguments);

      Assert.That (result, Is.Null);
      Assert.That (arguments, Is.EqualTo (new object[] { 7, "hello blub" }));
    }

    public class BaseType
    {
      public virtual string OverridableMethod ()
      {
        return "BaseType";
      }

      public virtual string OverridableMethodWithParameters (string s)
      {
        return "BaseType " + s;
      }

      public virtual string MethodOverriddenInDerived ()
      {
        return "BaseType";
      }

      public virtual void MethodWithOutAndRefParameters (out int i, ref string s)
      {
        i = 7;
        s += " blub";
      }
    }

    public class DerivedTpe : BaseType
    {
      public override string MethodOverriddenInDerived ()
      {
        return "DerivedTpe";
      }
    }
  }
}