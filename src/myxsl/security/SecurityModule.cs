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

using System.Security.Principal;
using System.Threading;

namespace myxsl.security
{

    [XPathModule("security", XPathModuleAttribute.BuiltInModulesBaseNamespace + "security")]
   public static class SecurityModule {

      static IPrincipal CurrentPrincipal {
         get { return Thread.CurrentPrincipal; }
      }

      [XPathFunction("user-name", As = "xs:string")]
      public static string UserName() {
         return CurrentPrincipal.Identity.Name;
      }

      [XPathFunction("user-is-authenticated", As = "xs:boolean")]
      public static bool UserIsAuthenticated() {
         return CurrentPrincipal.Identity.IsAuthenticated;
      }

      [XPathFunction("user-is-in-role", "xs:boolean", As = "xs:string")]
      public static bool UserIsInRole(string role) {
         return CurrentPrincipal.IsInRole(role);
      }
   }
}
