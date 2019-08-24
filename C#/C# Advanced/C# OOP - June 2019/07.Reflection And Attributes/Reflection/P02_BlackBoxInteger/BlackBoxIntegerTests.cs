namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            var instace = Activator.CreateInstance(type, true);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split("_");
                string methodName = tokens[0];
                int value = int.Parse(tokens[1]);

                var method = methods.FirstOrDefault(m => m.Name == methodName);

                method.Invoke(instace, new object[] { value });

                var field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                Console.WriteLine(field.GetValue(instace));
                 
                input = Console.ReadLine();
            }
        }
    }
}
