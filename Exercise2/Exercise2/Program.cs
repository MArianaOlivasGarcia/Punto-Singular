using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Cadena = Console.ReadLine();

            Separador separador = new Separador();
            int i;
            string CadenaTemp = "";

            
                separador.SetString(Cadena);
                CadenaTemp = CadenaTemp + "-" + separador.silabear(); 

            
            Console.WriteLine(CadenaTemp);
                Console.Read();
        }




        
    }
}
