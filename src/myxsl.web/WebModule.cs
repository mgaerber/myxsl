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

using System.Web;

namespace myxsl.web
{

    [XPathModule(Prefix, Namespace)]
   public static class WebModule {

      internal const string Prefix = "web";
      internal const string Namespace = XPathModuleAttribute.BuiltInModulesBaseNamespace + "web";

      [XPathFunction("absolute-path", "xs:string", As = "xs:string")]
      public static string AbsolutePath(string appRelativePath) {
         return VirtualPathUtility.ToAbsolute(appRelativePath);
      }

      [XPathFunction("app-relative-path", "xs:string", As = "xs:string")]
      public static string AppRelativePath(string absolutePath) {
         return VirtualPathUtility.ToAppRelative(absolutePath);
      }

      [XPathFunction("combine-path", "xs:string?", "xs:string", As = "xs:string")]
      public static string CombinePath(string basePath, string relativePath) {
         return VirtualPathUtility.Combine(basePath, relativePath);
      }

      [XPathFunction("encode-url", "xs:string", As = "xs:string")]
      public static string EncodeUrl(string str) {
         return HttpUtility.UrlEncode(str);
      }
   }
}
