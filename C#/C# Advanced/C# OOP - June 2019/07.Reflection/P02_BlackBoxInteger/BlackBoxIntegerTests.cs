namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            //TODO put your reflection code here

            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == "BlackBoxInteger");

            //var classInstance = (BlackBoxInteger)Activator.CreateInstance(type,
            //    BindingFlags.Instance | BindingFlags.NonPublic,
            //    null,
            //    new object[] { parameter },
            //    null);

            var classInstance = (BlackBoxInteger)Activator.CreateInstance(type,
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                null,
                null);

            while (true)
            {
                string[] inputString = Console.ReadLine().Split("_");

                if (inputString[0] == "END")
                {
                    break;
                }

                string command = inputString[0];
                int parameter = int.Parse(inputString[1]);


                MethodInfo methodInfo = type.GetMethod(command,BindingFlags.Instance|BindingFlags.NonPublic);

                if (methodInfo != null)
                {
                    methodInfo.Invoke(classInstance, new object[] { parameter});

                    FieldInfo fieldInfo = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

                    Console.WriteLine(fieldInfo.GetValue(classInstance));
                }

            }
        }
    }
}

