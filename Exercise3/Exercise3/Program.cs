using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresa una contraseña:");

            string Cadena = Console.ReadLine();
            
            if ( IsValid(Cadena) )
            {
                Console.WriteLine("Contraseña válida");
            }

            Console.Read();

        }


        public static string RemoveRepeatedChars(string _str)
        {
            char[] arrStr = _str.ToCharArray();
            Array.Sort(arrStr);
            StringBuilder str = new StringBuilder();
            int i;
            for (i = 0; i < arrStr.Length; i++)
                str.Append(arrStr[i].ToString());
            i = 0;
            while (i < str.Length - 1)
            {
                if (str[i + 1] == str[i])
                    str.Remove(i + 1, 1);
                else
                    i++;
            }
            return str.ToString();
        }

        public static bool IsValid(string Cadena)
        {
            if (!Regex.IsMatch(Cadena, "(?:.*[A-Z]){2}"))
            {
                Console.WriteLine("Error la contraseña debe tener al menos 2 letras mayúsculas.");
                return false;
            }


            if (!Regex.IsMatch(RemoveRepeatedChars(Cadena), @"(?:.*\d){3}"))
            {
                Console.WriteLine("Error la contraseña debe tener al menos 3 números (no repetidos).");
                return false;
            }


            if (!Regex.IsMatch(Cadena, "(?:.*[*|_|-|¿|¡|?|#|$])"))
            {
                Console.WriteLine("Error la contraseña debe tener al menos un carácter especial (* _ - ¿ ¡ ? # $ )");
                return false;
            }

            if (!Regex.IsMatch(Cadena, @"^\S+$"))
            {
                Console.WriteLine("Error la contraseña NO debe tener espacios en blanco.");
                return false;
            }


            if (!Regex.IsMatch(Cadena, "^.{8,15}$"))
            {
                Console.WriteLine("Error la contraseña requiere mínimo 8 carácteres, máximo 15 carácteres.");
                return false;
            }

            return true;
        }
    }


}
