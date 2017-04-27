namespace TesterProject
{
    using System;
    using System.Linq;
    using System.IO;
    using Models.Enums;
    using Models.Factories;
    using Interfaces;
    using Interpretators;
    using Interpretators.Expressions.MeasurementUnits;
    using Interpretators.Expressions.PropertyValues;
    using IO;
    using IO.ConsoleInputOutput;

    public class EntryPoint
    {
        public static void Main()
        {
            IOutputWriter writer = new ConsoleWriter();
            var context = new Context();
            new DurationValueExpression(2, new Second()).Interpret(context);
            writer.WriteLine(context);
            TestCssPropertyFactory(writer);
            InputOutputTest(writer);
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