 namespace P01_HarvestingFields
{
    using System;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            string input = string.Empty;
            Type classType = typeof(HarvestingFields);
            object instance = Activator.CreateInstance(classType);
            FieldInfo[] fieldsInfo = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                StringBuilder sb = new StringBuilder();
                if (input == "private")
                {
                    foreach (FieldInfo field in fieldsInfo)
                    {
                        if (field.IsPrivate)
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                }
                else if (input == "public")
                {
                    foreach (FieldInfo field in fieldsInfo)
                    {
                        if (field.IsPublic)
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                    }
                }
                else if (input == "protected")
                {
                    foreach (FieldInfo field in fieldsInfo)
                    {
                        if (field.IsFamily)
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                    }
                }
                else if (input == "all")
                {
                    foreach (FieldInfo field in fieldsInfo)
                    {
                        if (field.IsFamily)
                        {
                            sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                        }
                        else
                        {
                            sb.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                        }
                       
                        
                    }
                }
                Console.WriteLine(sb.ToString().TrimEnd());
            }
        }
    }
}
