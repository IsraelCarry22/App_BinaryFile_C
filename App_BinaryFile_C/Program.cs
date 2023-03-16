using System;
using System.Collections.Generic;
using System.IO;
//using static System.Console;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace App_BinaryFile_C
{
    internal class Program
    {
        struct personal_information
        {
            public string name;
            public string last_name;
            public string telephone;
            public int age;
        }

        static void Main(string[] args)
        {
            WriterFile();
            ReaderFile();

            Console.WriteLine("Presiona una tecla para salir...");
            Console.ReadKey();
        }

        static void WriterFile()
        {
            var direccion = Directory.GetCurrentDirectory();
            var archivo = Path.Combine(direccion,"./BinariFile.dat");
            try
            {
                using (BinaryWriter Writer_Information = new BinaryWriter(File.Open(archivo, FileMode.Create)))
                {
                    Writer_Information.Write("Israel");
                    Writer_Information.Write("Carreon");
                    Writer_Information.Write("866-147-24-29");
                    Writer_Information.Write(18);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message);
            }
        }

        static void ReaderFile()
        {
            var direccion = Directory.GetCurrentDirectory();
            var archivo = Path.Combine(direccion, "./BinariFile.dat");
            personal_information persona = new personal_information();

            try
            {
                if (File.Exists(archivo))
                {
                    using (BinaryReader Reader_Information = new BinaryReader(File.Open(archivo, FileMode.Open)))
                    {
                        persona.name = Reader_Information.ReadString();
                        persona.last_name = Reader_Information.ReadString();
                        persona.telephone = Reader_Information.ReadString();
                        persona.age = Reader_Information.ReadInt32();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(Environment.NewLine + ex.Message);
            }

            Console.WriteLine("Nombre: " + persona.name);
            Console.WriteLine("Apellido: " + persona.last_name);
            Console.WriteLine("Telefono: " + persona.telephone);
            Console.WriteLine("Edad: " + persona.age);
        }
    }
}
