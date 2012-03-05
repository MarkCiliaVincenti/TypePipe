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
using System.Reflection.Emit;
using NUnit.Framework;
using Remotion.TypePipe.FutureInfos;
using Remotion.TypePipe.UnitTests.Utilities;

namespace Remotion.TypePipe.UnitTests.FutureInfos
{
  [TestFixture]
  public class FutureTypeTest
  {
    //private ModuleBuilder _moduleBuilder;

    //[TestFixtureSetUp]
    //public void GenerateAssembly ()
    //{
    //  var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly (new AssemblyName ("FutureTypeTest"), AssemblyBuilderAccess.RunAndSave);
    //  _moduleBuilder = assemblyBuilder.DefineDynamicModule ("FutureTypeTest.dll");
    //}

    //[Test]
    //public void Initialization ()
    //{
    //  // TODO
    //}

    [Test]
    public void FutureTypeIsAType ()
    {
      Assert.That (NewFutureType(), Is.InstanceOf<Type>());
      Assert.That (NewFutureType(), Is.AssignableTo<Type>());
    }

    [Test]
    public void BaseType ()
    {
      Assert.That (NewFutureType().BaseType, Is.EqualTo (typeof (object)));
    }

    [Test]
    public void Name ()
    {
      Assert.That (NewFutureType().Name, Is.Null);
    }

    [Test]
    public void HasElementTypeImpl ()
    {
      Assert.That (NewFutureType().HasElementType, Is.False);
    }

    [Test]
    public void Assembly ()
    {
      Assert.That (NewFutureType().Assembly, Is.Null);
    }

    [Test]
    public void GetConstructorImpl ()
    {
      // Arrange
      var futureType = NewFutureType();

      BindingFlags bindingFlags = (BindingFlags) (-1); // Does not matter
      Binder binder = null; // Does not matter
      Type[] parameterTypes = Type.EmptyTypes; // Does not matter, cannot be null
      ParameterModifier[] parameterModifiers = null; // Does not matter

      // Act
      var constructor = futureType.GetConstructor (bindingFlags, binder, parameterTypes, parameterModifiers);

      // Assert
      Assert.That (constructor, Is.TypeOf<FutureConstructor>());
      Assert.That (constructor.DeclaringType, Is.SameAs (futureType));
    }

    [Test]
    public void IsByRefImpl ()
    {
      Assert.That (NewFutureType().IsByRef, Is.False);
    }

    [Test]
    public void UnderlyingSystemType ()
    {
      var futureType = NewFutureType();
      Assert.That (futureType.UnderlyingSystemType, Is.SameAs (futureType));
    }

    [Test]
    public void GetAttributeFlagsImpl ()
    {
      var standardAttributes = typeof (VeryStandardClass).Attributes;

      Assert.That (standardAttributes, Is.EqualTo (TypeAttributes.Public | TypeAttributes.BeforeFieldInit));
      Assert.That (NewFutureType().Attributes, Is.EqualTo (standardAttributes));
    }

    [Test]
    public void SetTypeBuilder_ThrowsIfCalledMoreThanOnce ()
    {
      // Arrange
      var futureType = NewFutureType();
      var typeBuilder = new FakeAdapter<TypeBuilder>();
      //var typeBuilder = CreateTypeBuilder ("SetTypeBuilder_ThrowsIfCalledMoreThanOnce");

      // Act
      TestDelegate action = () => futureType.SetTypeBuilder (typeBuilder);

      // Assert
      Assert.That (action, Throws.Nothing);
      Assert.That (action, Throws.InvalidOperationException.With.Message.EqualTo ("TypeBuilder already set"));
    }

    [Test]
    public void Typebuilder ()
    {
      // Arrange
      var futureType = NewFutureType();
      var typeBuilder = new FakeAdapter<TypeBuilder>();

      // Act
      futureType.SetTypeBuilder (typeBuilder);

      // Assert
      Assert.That (futureType.TypeBuilder, Is.SameAs (typeBuilder));
    }

    [Test]
    public void TypeBuilder_ThrowsIfNotSet ()
    {
      Assert.That (
          () => NewFutureType().TypeBuilder,
          Throws.InvalidOperationException.With.Message.EqualTo ("TypeBuilder not set"));
    }

    private FutureType NewFutureType ()
    {
      return new FutureType();
    }

    //private TypeBuilder CreateTypeBuilder (string typeName)
    //{
    //  return _moduleBuilder.DefineType (typeName);
    //}
  }

  public class VeryStandardClass
  {
  }
}