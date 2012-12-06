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
using System.Runtime.Serialization;
using NUnit.Framework;
using Remotion.Development.UnitTesting;
using Remotion.TypePipe.Serialization;
using Remotion.TypePipe.Serialization.Implementation;
using Rhino.Mocks;

namespace Remotion.TypePipe.UnitTests.Serialization.Implementation
{
  [TestFixture]
  public class SerializationSurrogateBaseTest
  {
    private SerializationInfo _info;
    private StreamingContext _context;

    private SerializationSurrogateBase _serializationSurrogateBase;

    private IObjectFactoryRegistry _objectFactoryRegistryMock;
    private Func<IObjectFactory, Type, StreamingContext, object> _createRealObjectAssertions;

    [SetUp]
    public void SetUp ()
    {
      var serializableType = ReflectionObjectMother.GetSomeSerializableType();
      var formatterConverter = new FormatterConverter();
      _info = new SerializationInfo (serializableType, formatterConverter);
      _context = new StreamingContext ((StreamingContextStates) 7);

      _objectFactoryRegistryMock = MockRepository.GenerateStrictMock<IObjectFactoryRegistry>();
      _createRealObjectAssertions = (f, t, c) => { throw new Exception ("should not be called"); };

      using (new ServiceLocatorScope (typeof (IObjectFactoryRegistry), () => _objectFactoryRegistryMock))
      {
        // Use testable class instead of partial mock, because RhinoMocks chokes on non-virtual ISerializable.GetObjectData.
        _serializationSurrogateBase = new TestableSerializationSurrogateBase (_info, _context, (f, t, c) => _createRealObjectAssertions (f, t, c));
      }
    }

    [Test]
    public void Initialization ()
    {
      Assert.That (_serializationSurrogateBase.SerializationInfo, Is.SameAs (_info));
    }

    [Test]
    public void GetRealObject ()
    {
      var underlyingType = ReflectionObjectMother.GetSomeType();
      var context = new StreamingContext ((StreamingContextStates) 8);

      _info.AddValue ("<tp>underlyingType", underlyingType.AssemblyQualifiedName);
      _info.AddValue ("<tp>factoryIdentifier", "factory1");

      var fakeObjectFactory = MockRepository.GenerateStub<IObjectFactory>();
      var fakeObject = new object();
      _objectFactoryRegistryMock.Expect (mock => mock.Get ("factory1")).Return (fakeObjectFactory);
      _createRealObjectAssertions = (factory, type, ctx) =>
      {
        Assert.That (factory, Is.SameAs (fakeObjectFactory));
        Assert.That (type, Is.SameAs (underlyingType));
        Assert.That (ctx, Is.EqualTo (context).And.Not.EqualTo (_context));

        return fakeObject;
      };

      var result = _serializationSurrogateBase.GetRealObject (context);

      _objectFactoryRegistryMock.VerifyAllExpectations();
      Assert.That (result, Is.SameAs (fakeObject));
    }

    [Test]
    [ExpectedException (typeof (TypeLoadException), MatchType = MessageMatch.StartsWith,
        ExpectedMessage = "Could not load type 'UnknownType' from assembly 'Remotion.TypePipe, ")]
    public void GetRealObject_UnderlyingTypeNotFound ()
    {
      _info.AddValue ("<tp>underlyingType", "UnknownType");
      _info.AddValue ("<tp>factoryIdentifier", "factory1");

      _serializationSurrogateBase.GetRealObject (new StreamingContext());
    }

    [Test]
    [ExpectedException (typeof (NotSupportedException), ExpectedMessage = "This method should not be called.")]
    public void GetObjectData ()
    {
      _serializationSurrogateBase.GetObjectData (null, new StreamingContext());
    }
  }
}