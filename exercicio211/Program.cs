using System;
using System.IO;
using System.Collections.Generic;

using exercicio211.Entities;

namespace exercicio211
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            / 
            */

            //Como a ordem não importa não vou usar o HashOrderSet, vou usar HashSet que é mais rápido!
            HashSet<LogRecord> set = new HashSet<LogRecord>();

            string path = "/Users/nxgames/Projects/exercicio211/exercicio211/file.txt";

            Console.WriteLine("Full path: " + path);
            
            try
            {
                //Abro o arquivo e leio
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[]    line = sr.ReadLine().Split(' ');

                        string      name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);

                        //Como eu não criei o construtor para o LOGRECORD, passo assim os valores
                        //Se o USERNAME for repetido não entrará o username no meu SET! show
                        //Pois implementamos o GetHashCode e o Equals na minha classe LOGRECORD
                        set.Add(new LogRecord { Username = name, Instant = instant });

                        Console.WriteLine(set.ToString());


                        //Console.WriteLine("Nome: " + " | " + "Login: ");
                    }

                    Console.WriteLine("Total users: " + set.Count);

                    /*COMO PERCORRER O SET
                    for (int i = 0; i < set.Count; i++)
                    {
                        Console.WriteLine("Nome: "
                             + set
                             + " | "
                             + set;
                    }
                    */
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
