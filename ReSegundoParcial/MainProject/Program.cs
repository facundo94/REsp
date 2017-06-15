using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace MainProject
{
    class Program
    {
        private static bool Serializar(ISerializable obj)
        { 
            return obj.SerializarXml() ? true : false;
        }

        private static bool DeSerializar(ISerializable obj)
        {
            return obj.DeSerializarXml() ? true : false;
        }

        static void Main(string[] args)
        {
            Manzana m1 = new Manzana(ConsoleColor.Red, 2, "Dist1");
            Manzana m2 = new Manzana(ConsoleColor.Red, 2, "Dist2");
            Manzana m3 = new Manzana(ConsoleColor.Red, 3, "Dist3");
            Platano p1 = new Platano(ConsoleColor.Yellow, 3, "Pais");
            Platano p2 = new Platano(ConsoleColor.Yellow, 4, "Pais2");
            Platano p3 = new Platano(ConsoleColor.Yellow, 5, "Pais3");
            Platano p4 = new Platano(ConsoleColor.Yellow, 6, "Pais4");
            Cajon<Fruta> cm = new Cajon<Fruta>(2, 5);
            Cajon<Platano> cp = new Cajon<Platano>(3, 10);

            cm += m1;
            cm += m2;
            try
            {
                cm += m3;
            }
            catch (CajonLlenoException e)
            {
                Console.WriteLine(e.Message);
            }

            cp += p1;
            cp += p2;
            cp += p3;
            try
            {
                cp += p4;
            }
            catch (CajonLlenoException e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine("\nCajon x");
            //Console.WriteLine(cp.ToString());

            m1.RutaArchivo = "Manzana.xml";
            if (Program.Serializar(m1))
                Console.WriteLine("\n-Manzana guardada correctamente!-");

            Manzana mn = new Manzana();
            mn.RutaArchivo = "Manzana.xml";

            if (Program.DeSerializar(mn))
                Console.WriteLine("\n-Manzana leida correctamente!-");
            Console.WriteLine("Manzana ledia dese xml");
            Console.WriteLine(mn.ToString());

            cm.RutaArchivo = "Cajon.xml";
            if (Program.Serializar(cm))
                Console.WriteLine("\n-Cajon guardado correctamente!-");

            Cajon<Fruta> cmn = new Cajon<Fruta>();
            cmn.RutaArchivo = "Cajon.xml";

            if (Program.DeSerializar(cmn))
                Console.WriteLine("\n-Cajon leido correctamente!-");
            Console.WriteLine("Cajon ledio dese xml");
            Console.WriteLine(cmn.ToString());

            if (cp.ImprimirTicket("CajonPlatanos.txt"))
                Console.WriteLine("\n-Cajon de platanos guardado correctamente!-");

            Console.ReadLine();
        }
    }
}
