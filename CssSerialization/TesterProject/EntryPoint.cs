using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace TesterProject
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using System.Security.AccessControl;
    using Common;
    using Models.Enums;
    using Models.Factories;
    using Interfaces;
    using Interpretators;
    using Interpretators.Expressions.MeasurementUnits;
    using Interpretators.Expressions.PropertyValues;
    using TypeBuilders;
    using IO;
    using IO.ConsoleInputOutput;

    public class EntryPoint
    {
        public static Expression MakeDynamic<T>(Func<T> typeFunc, TypeBuilder enumBuilder, params object[] objects)
        {
            return Expression.MakeDynamic(typeFunc.GetType(), CallSiteHelpers.IsInternalFrame(new DynamicMethod("Get", MethodAttributes.Public, CallingConventions.Standard, new TypeDelegator(typeof(Func<T, object>)), objects.Select(o => Expression.Parameter(o.GetType()).GetType()).ToArray(), Assembly.GetExecutingAssembly().GetModules().First(), false), typeFunc, objects)/*, objects.Select(o => Expression.Parameter(o.GetType()))*/);
        }

        public static void Main()
        {
            IOutputWriter writer = new ConsoleWriter();
            //new DynamicMetaObject(, );
            //writer.WriteLine(dyn);
            TestBuildingType(writer);
            TestNativelyGettingEnumValue(writer);
            writer.WriteLine($"{BitConverter.DoubleToInt64Bits(32.1)}");
            var context = new Context();
            new DurationValueExpression(2, new Second()).Interpret(context);
            writer.WriteLine(context);
            TestCssPropertyFactory(writer);
            InputOutputTest(writer);
        }

        private static void TestBuildingType(IOutputWriter writer)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var location = assembly.Location;
            var lastIndexOfDot = location.LastIndexOf(".", StringComparison.Ordinal);
            var libraryPath = $"{location.Substring(0, lastIndexOfDot)}.dll";
            if (File.Exists(libraryPath))
            {
                var fileSystemAccessRulePath = new FileSecurity(libraryPath, AccessControlSections.Access);
                fileSystemAccessRulePath.RemoveAccessRuleAll(
                        new FileSystemAccessRule("KRAS-PC\\Kras", FileSystemRights.FullControl,
                            AccessControlType.Allow));
                File.Delete(libraryPath);
            }

            var codeProver = new EnumBuilderType();
            codeProver.CreateNewAssemblyBuilder(assembly.FullName);
            var enumTypeName = "NewTestEnumType";
            var newEnumType = codeProver.CreateEnumType(
                assembly.FullName,
                enumTypeName,
                "TestValue1",
                "TestValue2",
                "TestValue3",
                "TestValue4",
                "TestValue5");
            var resultObject = newEnumType;
            writer.WriteLine($"{resultObject}");
        }

        private static void TestNativelyGettingEnumValue(IOutputWriter writer)
        {
            var alignContent = TransformType.RotateY.Get();
            writer.WriteLine(alignContent.ToString());
        }

        private static void TestCssPropertyFactory(IOutputWriter writer)
        {
            writer.WriteLine(CssPropertyFactory.GetCssPropertyString(CssPropertyType.TableLayout));
        }

        private static void InputOutputTest(IOutputWriter writer)
        {
            string message = "Pesho se skachi na vlaka za sofia";
            var stringReader = new StringReader(message);
            IInputReader reader = new Reader(stringReader);
            var result2 = reader.ReadBytes();
            var result2AsString = string.Join(string.Empty, result2.Select(Convert.ToChar));
            writer.WriteLine(result2AsString);
            stringReader = new StringReader(message);
            reader = new Reader(stringReader);
            var result = reader.ReadBytesAsync().Result;
            var resultAsString = string.Join(string.Empty, result.Select(Convert.ToChar));
            writer.WriteLine(resultAsString);
            writer.Dispose();
            reader.Dispose();
            try
            {
                writer.WriteLine();
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre);
            }
        }
    }
}