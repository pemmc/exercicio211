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

            //Windows
            //string path = @"C:\Users\apagar\Projects\exercicio211\file.txt";

            //macOS note
            //string path = "/Users/pauloeduardo/Projects/HashSet/file.txt";

            //macOS PC
            string path = "/Users/nxgames/Projects/exercicio211/exercicio211/file.txt";

            Console.WriteLine("Full path: " + path);
            
            try
            {
                //Abro o arquivo e leio
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');

                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);

                        //Como eu não criei o construtor para o LOGRECORD, passo assim os valores
                        //Se o USERNAME for repetido não entrará o username no meu SET! show
                        //Pois implementamos o GetHashCode e o Equals na minha classe LOGRECORD
                        if(set.Add(new LogRecord { Username = name, Instant = instant }))
                        {
                            Console.WriteLine("Usuário: "
                            + name
                            + " | "
                            + "Login: "
                            + instant);

                        }
                         
                    }

                    Console.WriteLine("Total users: " + set.Count);

                    /*COMO PERCORRER O set
                     
                    foreach (LogRecord logRecord in set)
                    {
                        Console.WriteLine("Usuário: "
                            + logRecord.Username
                            + " | "
                            + "Login: "
                            + logRecord.Instant);
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
