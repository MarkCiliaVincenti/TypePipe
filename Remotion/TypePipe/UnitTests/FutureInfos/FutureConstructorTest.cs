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
using NUnit.Framework;
using Remotion.TypePipe.FutureInfos;

namespace Remotion.TypePipe.UnitTests.FutureInfos
{
  [TestFixture]
  public class FutureConstructorTest
  {

    [Test]
    public void Initialization ()
    {
      // Arrange
      var futureType = new FutureType();
      var futureConstructor = new FutureConstructor(futureType);

      // Assert
      Assert.That (futureConstructor.DeclaringType, Is.SameAs (futureType));
    }

    [Test]
    public void FutureConstructorIsAConstructorInfo ()
    {
      Assert.That (new FutureConstructor (null), Is.InstanceOf<ConstructorInfo> ());
      Assert.That (new FutureConstructor (null), Is.AssignableTo<ConstructorInfo> ());
    }
  }
}