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
using Remotion.TypePipe.MutableReflection;

namespace Remotion.TypePipe.CodeGeneration.ReflectionEmit
{
  /// <summary>
  /// Extends <see cref="ITypeModificationHandler"/> with the <see cref="IDisposable"/> interface to allow callers to signal that all type 
  /// modifications have been handled.
  /// </summary>
  public interface IDisposableTypeModificationHandler : IDisposable, ITypeModificationHandler
  {
    // TODO 4745: Rename interface to ISubclassProxyBuilder, implementation SubclassProxyBuilder.
    // TODO 4745: void AddConstructor (MutableConstructorInfo constructor);

    // TODO 4745: Expected end result
    // var typeBuilder = ...;
    // using (var builder = _factory.CreateSubclassProxyBuilder (typeBuilder))
    // {
    //   foreach (...)
    //     builder.AddConstructor (unmodifiedExistingCtor);
    //   builder.ImplementSerializability();
    //   mutableType.Accept (builder);
    // }
    // return typeBuilder.CreateType();
  }
}