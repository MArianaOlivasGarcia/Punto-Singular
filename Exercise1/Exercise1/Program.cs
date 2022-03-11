using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un texto:");
            string Cadena = Console.ReadLine();
            string CadenaOrdenada = new String(Cadena.ToLower().OrderBy(x => x).ToArray());
            var res = from a in CadenaOrdenada.ToCharArray().Where(Char.IsLetter)
                      group a by a into b
                      select new
                      {
                          Letter = b.Key,
                          Times = b.Count()
                      };

            foreach (var item in res)
            {
                Console.WriteLine(string.Format("{0} -> {1}", item.Letter, item.Times));
            }

            Console.WriteLine(CadenaOrdenada);

            Console.Read();

        }
    }
}
