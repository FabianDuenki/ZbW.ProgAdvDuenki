using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection1 {
    class Program {
        static void Main(string[] args) {
            if (args.Length < 1) {
                return;
            }

            var path = args[0];
            if (!File.Exists(path)) {
                return;
            }

            var assembly = Assembly.LoadFile(path);
            if (assembly == null) return;

            Console.WriteLine($"Assembly: {assembly.FullName}");
           
            foreach(var module in assembly.GetModules())
            {
                Console.WriteLine($"\tModule: {module.Name}");
                assembly.GetTypes();
                foreach(var type in assembly.GetTypes())
                {
                    Console.WriteLine($"\t\tClass: {type.Name}");
                    foreach (var method in type.GetMethods())
                    {
                        var methodParameters = method.GetParameters().Select(p => { return { Type: p.ParameterType.Name, Name: p.Name} });
                        Console.WriteLine($"\t\t\tMethod: {method.Name}({methodParameters.Select(p=>$"{p.ParameterType.Name} {p.Name}")})");
                    }
                }
                foreach(var field in module.GetFields())
                {

                }
            }

            

            // TODO: Implementierung gemäss Aufgabenstellung
        }
    }
}
