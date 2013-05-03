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
using System.Linq;
using Remotion.TypePipe.Caching;
using Remotion.Utilities;

namespace Remotion.TypePipe.Serialization
{
  /// <summary>
  /// A data container for serialization that holds flattened from an <see cref="AssembledTypeID"/>.
  /// </summary>
  [Serializable]
  public class AssembledTypeIDData
  {
    private readonly string _requestedTypeAssemblyQualifiedName;
    private readonly object[] _flattenedSerializableIDParts;

    public AssembledTypeIDData (string requestedTypeAssemblyQualifiedName, object[] flattenedSerializableIDParts)
    {
      ArgumentUtility.CheckNotNullOrEmpty ("requestedTypeAssemblyQualifiedName", requestedTypeAssemblyQualifiedName);
      ArgumentUtility.CheckNotNull ("flattenedSerializableIDParts", flattenedSerializableIDParts);

      _requestedTypeAssemblyQualifiedName = requestedTypeAssemblyQualifiedName;
      _flattenedSerializableIDParts = flattenedSerializableIDParts;
    }

    public string RequestedTypeAssemblyQualifiedName
    {
      get { return _requestedTypeAssemblyQualifiedName; }
    }

    public object[] FlattenedSerializableIDParts
    {
      get { return _flattenedSerializableIDParts; }
    }

    public AssembledTypeID CreateTypeID (IPipeline pipeline)
    {
      ArgumentUtility.CheckNotNull ("pipeline", pipeline);

      var requestedType = Type.GetType (_requestedTypeAssemblyQualifiedName, throwOnError: true);
      var parts = GetPartsArray (pipeline);

      return new AssembledTypeID (requestedType, parts);
    }

    private object[] GetPartsArray (IPipeline pipeline)
    {
      var typeIDProviders = pipeline.Participants.Select (p => p.PartialTypeIdentifierProvider).Where (p => p != null).ToList();
      Assertion.IsTrue (typeIDProviders.Count == _flattenedSerializableIDParts.Length);

      var parts = new object[_flattenedSerializableIDParts.Length];
      for (int i = 0; i < parts.Length; i++)
        parts[i] = DeserializeFlattenedID(typeIDProviders[i], _flattenedSerializableIDParts[i]);

      return parts;
    }

    private static object DeserializeFlattenedID (ITypeIdentifierProvider typeIDProvider, object flattenedIDPart)
    {
      if (flattenedIDPart == null)
        return null;

      return typeIDProvider.DeserializeFlattenedID (flattenedIDPart);
    }
  }
}