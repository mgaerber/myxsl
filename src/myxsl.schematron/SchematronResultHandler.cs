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

using System.IO;
using System.Xml;
using System.Xml.XPath;
using myxsl.common;

namespace myxsl.schematron
{

    public class SchematronResultHandler {

      readonly SchematronValidator validator;
      readonly SchematronRuntimeOptions options;
      readonly XPathSerializationOptions defaultSerialization;

      internal SchematronResultHandler(SchematronValidator validator, SchematronRuntimeOptions options) {
         
         this.validator = validator;
         this.options = options;
         this.defaultSerialization = options.Serialization;
      }

      public bool IsValid() {

         XPathNavigator doc = ToDocument().CreateNavigator();
         doc.MoveToChild(XPathNodeType.Element);

         return doc.MoveToChild("failed-assert", SchematronInvoker.SvrlNamespace);
      }

      public IXPathNavigable ToDocument() {

         IXPathNavigable doc = this.validator.ItemFactory.BuildNode();

         XmlWriter writer = doc.CreateNavigator().AppendChild();
         
         To(writer);

         writer.Close();

         return doc;
      }

      public void To(Stream output) {
         To(output, null);
      }

      public void To(Stream output, XPathSerializationOptions options) {

         OverrideSerialization(options);

         this.validator.Validate(output, this.options);

         RestoreSerialization(options);
      }

      public void To(TextWriter output) {
         To(output, null);
      }

      public void To(TextWriter output, XPathSerializationOptions options) {

         OverrideSerialization(options);

         this.validator.Validate(output, this.options);

         RestoreSerialization(options);
      }

      public void To(XmlWriter output) {
         To(output, null);
      }

      public void To(XmlWriter output, XPathSerializationOptions options) {

         OverrideSerialization(options);

         this.validator.Validate(output, this.options);

         RestoreSerialization(options);
      }

      void OverrideSerialization(XPathSerializationOptions options) {

         if (options == null) {
            return;
         }

         this.options.Serialization = options;
      }

      void RestoreSerialization(XPathSerializationOptions options) {

         if (options == null) {
            return;
         }

         this.options.Serialization = this.defaultSerialization;
      }
   }
}
