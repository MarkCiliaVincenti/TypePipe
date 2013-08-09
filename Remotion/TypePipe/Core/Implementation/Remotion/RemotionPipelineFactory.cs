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
using Remotion.TypePipe.CodeGeneration.ReflectionEmit;

namespace Remotion.TypePipe.Implementation.Remotion
{
  // TODO 5545: Move this to Remotion.Core.
  /// <summary>
  /// Decorates created <see cref="IModuleBuilderFactory"/> instances with <see cref="RemotionModuleBuilderFactoryDecorator"/>.
  /// </summary>
  public class RemotionPipelineFactory : DefaultPipelineFactory
  {
    [CLSCompliant (false)]
    protected override IModuleBuilderFactory NewModuleBuilderFactory ()
    {
      var moduleBuilderFactory = base.NewModuleBuilderFactory();
      return new RemotionModuleBuilderFactoryDecorator (moduleBuilderFactory);
    }
  }
}