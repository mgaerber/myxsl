﻿// Copyright 2011 Max Toro Q.
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
using System.Xml.XPath;
using System.Net.Mail;

namespace myxsl.net.mail
{

    sealed class XPathMailAddress {

      public string Address { get; set; }
      public string DisplayName { get; set; }

      public void ReadXml(XPathNavigator node) {

         if (node.MoveToFirstAttribute()) {

            do {
               if (String.IsNullOrEmpty(node.NamespaceURI)) {

                  switch (node.LocalName) {
                     case "address":
                        this.Address = node.Value;
                        break;

                     case "display-name":
                        this.DisplayName = node.Value;
                        break;

                     default:
                        break;
                  }
               }

            } while (node.MoveToNextAttribute());

            node.MoveToParent();
         }
      }

      public MailAddress ToMailAddress() {

         var mailAddress = !String.IsNullOrEmpty(this.DisplayName) ?
            new MailAddress(this.Address, this.DisplayName)
            : new MailAddress(this.Address);

         return mailAddress;
      }
   }
}
