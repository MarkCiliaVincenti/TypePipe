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
using Remotion.TypePipe.Serialization;

namespace Remotion.TypePipe.Development.UnitTesting.Serialization
{
  [Serializable]
  public class FlatValueStub : IFlatValue
  {
    public FlatValueStub ()
        : this ("real value") {}

    public FlatValueStub (object realValue)
    {
      RealValue = realValue;
    }

    public object RealValue { get; set; }

    public object GetRealValue ()
    {
      return RealValue;
    }


    #region Generated by ReSharper

    protected bool Equals (FlatValueStub other)
    {
      return Equals (RealValue, other.RealValue);
    }

    public override bool Equals (object obj)
    {
      if (ReferenceEquals (null, obj))
        return false;
      if (ReferenceEquals (this, obj))
        return true;
      if (obj.GetType () != this.GetType ())
        return false;
      return Equals ((FlatValueStub) obj);
    }

    public override int GetHashCode ()
    {
      return (RealValue != null ? RealValue.GetHashCode () : 0);
    }

    #endregion
  }
}