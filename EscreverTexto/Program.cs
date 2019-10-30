using System;
using System.IO;
using System.IO.Compression;

namespace EscreverTexto
{
    class Program
    {
        private static string ficheiro;

        static void Main(string[] args)
        {
            // Declarate variables with some values to put on file
            string name = "Ana haha";
            int age = 24;
            float height = 166.2f;

            // Save file om the given directory folder
            ficheiro =
                Path.Combine(Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop), "TestFile.txt");

            // Instanciate streamwriter with file as argument
            using (StreamWriter sw = new StreamWriter(ficheiro)) 
            {
                sw.WriteLine(name);
                sw.WriteLine(age);
                sw.WriteLine(height);
            }


            // Read the values of the file
            using (StreamReader sr = new StreamReader(ficheiro)) 
            {
                // Read values and convert the ones to be able to read them
                name = sr.ReadLine();
                age = int.Parse(sr.ReadLine());
                float.TryParse(sr.ReadLine(), out height);
            }

            // Print them out to the console
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(height);


            // Create instance of filestream and set the mode and acess to the
            // file ficheiro
            FileStream fs =
                new FileStream(ficheiro, FileMode.Create, FileAccess.Write);

            // Write variables in binary to the file
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(name);
            bw.Write(age);
            bw.Write(height);

            // Close file
            bw.Close();

            // instance of type Filestream to set mode to open the file and
            // acess to read the file
            using (FileStream fr =
                new FileStream(ficheiro, FileMode.Open, FileAccess.Read)) 
            {
                // Binaryreader receives the file as a filestream
                using (BinaryReader br = new BinaryReader(fr)) 
                {
                    // Read each value of each type with specific read method
                    name = br.ReadString();
                    age = br.ReadInt32();
                    height = br.ReadSingle();
                }
            }

            // Print them out to the console
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(height);
        }
    }
}
