namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string fieldName = "HarvestingFields";

            //TODO put your reflection code here
            //var assembly = Assembly.GetAssembly(typeof("HarvestingFields"));

            //var type = typeof(HarvestingFieldsTest).Assembly.GetTypes().FirstOrDefault(x => x.Name == fieldName);

            //var instance = Activator.CreateInstance(type);

            Type type = Type.GetType($"P01_HarvestingFields.{fieldName}");

            FieldInfo[] allFields = type.GetFields(BindingFlags.Instance |
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static);


            while (true)
            {
                string inputStr = Console.ReadLine();

                if (inputStr == "HARVEST")
                {
                    break;
                }

                FieldInfo[] fieldsToPrint = null;

                switch (inputStr)
                {
                    case "private":
                        fieldsToPrint = allFields.Where(f => f.IsPrivate == true).ToArray();
                        break;
                    case "protected":
                        fieldsToPrint = allFields.Where(f => f.IsFamily == true).ToArray();
                        break;
                    case "public":
                        fieldsToPrint = allFields.Where(f => f.IsPublic == true).ToArray();
                        break;
                    case "all":
                        fieldsToPrint = allFields.ToArray();
                        break;
                    default:
                        break;
                }

                foreach (var field in fieldsToPrint)
                {
                    string attributeName = field.Attributes.ToString();

                    string accessModifier = field.Attributes.ToString().ToLower() == "family"
                            ? "protected"
                            : field.Attributes.ToString().ToLower();


                    Console.WriteLine($"{accessModifier} {field.FieldType.Name} {field.Name}");
                }

            }



        }
    }
}
