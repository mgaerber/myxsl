﻿// Copyright 2012 Max Toro Q.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


namespace myxsl.common
{

    public sealed class XPathVariableInfo {

      readonly string _Name;
      readonly XPathSequenceType _Type;

      public string Name { get { return _Name; } }
      public XPathSequenceType Type { get { return _Type; } }

      internal XPathVariableInfo(string name, XPathSequenceType type) {
         
         this._Name = name;
         this._Type = type;
      }
   }
}
