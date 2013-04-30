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
using System.Diagnostics;
using Remotion.Utilities;

namespace Remotion.TypePipe.Caching
{
  /// <summary>
  /// A data structure that can be used as keys for constructor delegates.
  /// </summary>
  /// <remarks>
  /// Note that the length of the type key (object array) is assumed to be equal.
  /// </remarks>
  public struct ConstructionKey
  {
    private readonly object[] _typeKey;
    private readonly Type _delegateType;
    private readonly bool _allowNonPublic;

    private readonly int _hashCode;

    public ConstructionKey (object[] typeKey, Type delegateType, bool allowNonPublic)
    {
      // Using Debug.Assert because it will be compiled away.
      Debug.Assert (typeKey != null);
      Debug.Assert (delegateType != null);

      _typeKey = typeKey;
      _delegateType = delegateType;
      _allowNonPublic = allowNonPublic;

      // Pre-compute hash code.
      _hashCode = EqualityUtility.GetRotatedHashCode (EqualityUtility.GetRotatedHashCode (typeKey), delegateType, allowNonPublic);
    }

    public object[] TypeKey
    {
      get { return _typeKey; }
    }

    public Type DelegateType
    {
      get { return _delegateType; }
    }

    public bool AllowNonPublic
    {
      get { return _allowNonPublic; }
    }

    public override bool Equals (object obj)
    {
      // Using Debug.Assert because it will be compiled away.
      Debug.Assert (obj != null);

      // Unsafe implementation for performance.
      var other = (ConstructionKey) obj;
      Debug.Assert (_typeKey.Length == other._typeKey.Length);

      // ReSharper disable LoopCanBeConvertedToQuery // No LINQ for performance reasons.
      for (int i = 0; i < _typeKey.Length; i++)
      {
        if (!object.Equals (_typeKey[i], other._typeKey[i]))
          return false;
      }

      return _delegateType == other._delegateType && _allowNonPublic == other._allowNonPublic;
    }

    public override int GetHashCode ()
    {
      return _hashCode;
    }
  }
}