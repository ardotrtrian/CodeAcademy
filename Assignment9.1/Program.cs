using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment9._1
{
    class Program
    {
        /*
         Extendable Hello World TranslatorFunctional Specification1.
        
         Functional Requirements
         1.1.Must be implemented as a console application
         1.2.When executed must print “Hello World” (in English)
         1.3.Must allow configuring one or more translator plug-ins that translate “Hello World” to another language.
             The configuration file must support an application setting named “Plugins” with the value containing comma-separated list of available plugins.
         1.4.The translator plugins must allow obtaining the target language and translation of “Hello World” in the target language.
         1.5.For each configured translator plug-in, the application must print the supported target language and the translated equivalent of “Hello World” in that language.
        
         2.Implementation Details
         2.1.A class library named Plugin.dll must implement 
         2.1.1.An abstract translator base class named TranslatorBase with an abstract method string Translate() that returns the translation of “Hello World”.
         2.1.2.An attribute named Language with a readonly string property returningthe target language.
         2.2.The plug-ins must be implemented as class library assemblies and put into the Plugins subfolder within the application directory
         2.3.The plug-in assembly can contain zero or more classes deriving from TranslatorBase (one per target language)
         2.4.The application must discover all classes in all configured plugin assemblies that derive from TranslatorBase class and for each discovered class instantiate an 
             object of that class and print the result of Translate method invoked for that object.
         2.5.If a translator class has a LanguageAttribute applied then the application must print the target language specified by that attribute next to the printed translation 
             of “Hello World”. Otherwise append “(n/a)” to the printed translation
         */
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var resultAssembly = Assembly.LoadFrom(@"C:\Users\artavazd.trtrian\source\repos\Assignment1\Assignment9.1\Plugins\Plugin.dll");

            Console.WriteLine("Hello World");

            foreach (var type in resultAssembly.DefinedTypes.Where(dt=>dt.BaseType.Name == "TranslatorBase"))
            {
                var ctor = type.GetConstructors().Where(c=>c.GetParameters().Length == 0).FirstOrDefault(); //get constructor info

                var translator = ctor.Invoke(new object[0]); //instantiation 

                var translateMethodInfo = translator.GetType().GetMethod("Translate"); //get method info

                var translation = translateMethodInfo.Invoke(translator, new object[0]); //method call

                var attributeInfo = type.CustomAttributes.FirstOrDefault(ca => ca.AttributeType.Name == "LanguageAttribute"); //get custom attribute info

                string attributeFieldValue;

                if (attributeInfo != null)
                {
                    attributeFieldValue = (string)attributeInfo.ConstructorArguments[0].Value;  //get attribute field value
                }
                else
                {
                    attributeFieldValue = "n/a";
                }

                Console.WriteLine($"{translation} ({attributeFieldValue})");
            }
        }
    }
}
