using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Получить список методов класса Console\n2 - Получить свойства и их значения класса\n" +
                "3 - Методы Substring класса String\n4 - Получить список конструкторов класса List<T>");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        Type cons = typeof(Console);
                        MethodInfo[] methods = cons.GetMethods();
                        foreach (var item in methods)
                        {
                            Console.Write("Имя метода: {0}", item.Name);
                            ParameterInfo[] param = item.GetParameters();
                            Console.WriteLine("Параметры:");
                            for (int i = 0; i < param.Length; i++)
                            {
                                Console.Write("{0} {1} ", param[i].ParameterType.Name, param[i].Name);
                            }
                            Console.WriteLine();
                        }
                    }
                    break;
                case "2":
                    {
                        SomeClass sc = new SomeClass();
                        sc.name = "name1";
                        sc.sname = "sname1";
                        sc.age = 100500;
                        Type types = typeof(SomeClass);
                        FieldInfo[] fields = types.GetFields();
                        foreach (var item in fields)
                        {
                            Console.Write("{0} {1} : {2}\n", item.FieldType.Name, item.Name, item.GetValue(sc));
                        }
                    }
                    break;
                case "3":
                    {
                        Type t = typeof(String);
                        Type[] paramtypes = { typeof(int) };
                        MethodInfo methInfo = t.GetMethod("Substring", paramtypes);
                        Console.Write("Введите строку: ");
                        string str = Console.ReadLine();
                        Console.Write("Введите индекс: ");
                        int index = Int32.Parse(Console.ReadLine());
                        object[] indxs = { index };
                        object invokeVal = methInfo.Invoke(str, indxs);
                        Console.WriteLine(invokeVal);
                    }
                    break;
                case "4":
                    {
                        Type typ = typeof(List<>);
                        ConstructorInfo[] constrInfo = typ.GetConstructors();
                        foreach (var item in constrInfo)
                        {
                            Console.WriteLine("Конструктор: {0}", item.Name);
                            ParameterInfo[] p = item.GetParameters();
                            Console.WriteLine("Параметры:");
                            foreach (var item1 in p)
                                Console.Write("{0} {1} ", item1.ParameterType.Name, item1.Name);
                            Console.WriteLine();
                        }
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}
