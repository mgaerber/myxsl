﻿// Copyright 2010 Max Toro Q.
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

using System;
using System.Xml;

namespace myxsl.common
{

    public class XmlParsingOptions {

      XmlResolver _XmlResolver;

      public Uri BaseUri { get; set; }

      public bool PerformDtdValidation { get; set; }
      
      public ConformanceLevel ConformanceLevel { get; set; }

      public XmlResolver XmlResolver {
         get {
            return _XmlResolver
               ?? (_XmlResolver = new XmlDynamicResolver());
         }
         set {
            _XmlResolver = value;
         }
      }

      public XmlParsingOptions() {
         this.ConformanceLevel = ConformanceLevel.Document;
      }

      public static explicit operator XmlReaderSettings(XmlParsingOptions options) {

         var settings = new XmlReaderSettings {
            ConformanceLevel = options.ConformanceLevel,
            DtdProcessing = DtdProcessing.Ignore,
            XmlResolver = (options.PerformDtdValidation) ? options.XmlResolver : null,
         };

         return settings;
      }
   }
}
