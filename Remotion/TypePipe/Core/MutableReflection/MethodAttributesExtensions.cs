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
using System.Reflection;
using Remotion.Utilities;

namespace Remotion.TypePipe.MutableReflection
{
  /// <summary>
  /// Provides extensions methods for working with <see cref="MethodAttributes"/>.
  /// </summary>
  public static class MethodAttributesExtensions
  {
    public static MethodAttributes AdjustVisibilityForAssemblyBoundaries (this MethodAttributes originalAttributes)
    {
      return IsSet (originalAttributes, MethodAttributes.FamORAssem)
                 ? ChangeVisibility (originalAttributes, MethodAttributes.Family)
                 : originalAttributes;
    }

    public static MethodAttributes ChangeVisibility (this MethodAttributes originalAttributes, MethodAttributes newVisibility)
    {
      return (originalAttributes & ~MethodAttributes.MemberAccessMask) | newVisibility;
    }

    public static bool IsSet (this MethodAttributes attributes, MethodAttributes flag)
    {
      Assertion.IsTrue (flag != 0);

      return (attributes & flag) == flag;
    }
  }
}