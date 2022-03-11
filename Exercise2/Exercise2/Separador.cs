using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2
{
    internal class Separador
    {
        private String Cadena;

        public Separador(String Cadena)
        {
            this.Cadena = Cadena;
        }

        public Separador()
        {
            Cadena = "";
        }



        public Separador(int[] ascii)
        {
            char c;
            int i;
            Cadena = "";
            for (i = 0; i < ascii.Length; i++)
            {
                c = (char)ascii[i];
                Cadena = Cadena + c.ToString();
            }
        }




        public Separador(char[] c)
        {
            int i;
            Cadena = "";
            for (i = 0; i < c.Length; i++)
            {
                Cadena = Cadena + c.ToString();
            }
        }


        public String GetCadena()
        {
            return Cadena;
        }

        public void SetString(String NuevaCadena)
        {
            Cadena = NuevaCadena;
        }
        private static int Letra(char c)
        {
            int i = -1;
            int ascii;
            ascii = (int)c;
            if (ascii != -1)
            {
                switch (ascii)
                {
                    case 97: 
                        i = 1;
                        break;
                    case 101:
                        i = 2;
                        break;
                    case 104:
                        i = 6;
                        break;
                    case 105: 
                        i = 4;
                        break;
                    case 111: 
                        i = 3;
                        break;
                    case 117:
                        i = 5;
                        break;
                    case 225:
                        i = 1;
                        break;
                    case 233: 
                        i = 2;
                        break;
                    case 237: 
                        i = 4;
                        break;
                    case 243: 
                        i = 3;
                        break;
                    case 250: 
                        i = 5;
                        break;
                    case 252: 
                        i = 5;
                        break;
                    default:
                        i = 19;
                        break;
                }
            }
            return i;
        }

        private static String Silaba(String str)
        {
            String temp = "";
            String s = "";
            char x, y, z;
            if (str.Length < 3)
            {
                if (str.Length == 2)
                {
                    x = str[0];
                    y = str[1];
                    if (Letra(x) < 6 && Letra(y) < 6)
                    {
                        if (H(x, y))
                            s = str.Substring(0, 1);
                        else
                            s = str;
                    }
                    else
                        s = str;
                }
                else
                    s = str;
            }
            else
            {
                x = str[0];
                y = str[1];
                z = str[2];
                if (Letra(x) < 6)
                { 
                    if (Letra(y) < 6)
                    {
                        if (Letra(z) < 6)
                        {  
                            if (H(x, y))
                            {
                                s = str.Substring(0, 1);
                            }
                            else
                            {
                                if (H(y, z))
                                {
                                    s = str.Substring(0, 2);
                                }
                                else
                                {
                                    s = str.Substring(0, 3);
                                }
                            }
                        }
                        else
                        { 
                            if (H(x, y))
                            {
                                s = str.Substring(0, 1);
                            }
                            else
                            {
                                s = str.Substring(0, 2);
                            }
                        }
                    }
                    else
                    { 
                        if (Letra(z) < 6)
                        {  
                            if (Letra(y) == 6)
                            { 
                                if (H(x, z))
                                {
                                    s = str.Substring(0, 1);
                                }
                                else
                                {
                                    s = str.Substring(0, 3);
                                }
                            }
                            else
                            {
                                s = str.Substring(0, 1);
                            }
                        }
                        else
                        { 
                            if (Consonates(y, z))
                            {
                                s = str.Substring(0, 1);
                            }
                            else
                            {
                                s = str.Substring(0, 2);
                            }
                        }
                    }
                }
                else
                { 
                    if (Letra(y) < 6)
                    { 
                        if (Letra(z) < 6)
                        { 
                            temp = str.Substring(0, 3);
                            if (temp.Equals("que") || temp.Equals("qui") || temp.Equals("gue") || temp.Equals("gui"))
                            {
                                s = str.Substring(0, 3);
                            }
                            else
                            {
                                if (H(y, z))
                                {
                                    s = str.Substring(0, 2);
                                }
                                else
                                {
                                    s = str.Substring(0, 3);
                                }
                            }
                        }
                        else
                        { 
                            s = str.Substring(0, 2);
                        }
                    }
                    else
                    { 
                        if (Letra(z) < 6)
                        { 
                            if (Consonates(x, y))
                            {
                                s = str.Substring(0, 3);
                            }
                            else
                            {
                                s = str.Substring(0, 1);
                            }
                        }
                        else
                        { 
                            if (Consonates(y, z))
                            {
                                s = str.Substring(0, 1);
                            }
                            else
                            {
                                s = str.Substring(0, 1);
                            }
                        }
                    }
                }
            }
            return s;
        }

        private static String RestoSilaba(String str)
        {
            String s2;
            s2 = Silaba(str);
            return str.Substring(s2.Length);
        }

        private static bool H(char v, char v2)
        {
            bool cer = false;
            if (Letra(v) < 4)
            { 
                if (Letra(v2) < 4) 
                    cer = true;
                else
                {
                        cer = false;
                   
                }
            }
            else
            { 
                if (Letra(v2) < 4)
                { 
                    
                        cer = false;
                    
                }
                else
                {
                    if (v == v2)
                    {
                        cer = true;
                    }
                    else
                        cer = false;
                }
            }
            return cer;
        }

        private static bool Consonates(char a, char b)
        {
            bool cer;
            cer = false;
            if (a == 'b' || a == 'c' || a == 'd' || a == 'f' || a == 'g' || a == 'p' || a == 'r' || a == 't')
            {
                if (b == 'r')
                {
                    cer = true;
                }
            }
            if (a == 'b' || a == 'c' || a == 'f' || a == 'g' || a == 'p' || a == 't' || a == 'l')
            {
                if (b == 'l')
                {
                    cer = true;
                }
            }
            if (b == 'h')
            {
                if (a == 'c')
                {
                    cer = true;
                }
            }
            return cer;
        }

        private static bool strConsonantes(String str)
        {
            bool cer;
            int i, k;
            char[] c;
            cer = false;
            k = 0;
            c = str.ToCharArray();
            for (i = 0; i < str.Length; i++)
            {
                if (Letra(c[i]) > 5)
                {
                    k = k + 1;
                }
            }
            if (k == str.Length)
            {
                cer = true;
            }
            return cer;
        }

        private static bool strVVstr(String s1, String s2)
        {
            bool cer;
            char c1, c2;
            c1 = s1[s1.Length - 1];
            c2 = s2[0];
            cer = false;
            if (Letra(c1) < 6 && Letra(c2) < 6)
            {
                if (H(c1, c2))
                {
                    cer = false;
                }
                else
                {
                    cer = true;
                }
            }
            return cer;
        }

        public String silabear()
        {
            String temp;
            String s = "";
            int i, k;
            k = Cadena.Length;
            temp = Cadena;
            for (i = 0; i < k; i++)
            {
                temp = Silaba(Cadena);
                if (i == 0)
                {
                    s = s + temp;
                }
                else
                {
                    if (strConsonantes(temp))
                    {
                        s = s + temp;
                    }
                    else
                    {
                        if (strVVstr(s, temp))
                        {
                            s = s + temp;
                        }
                        else
                        {
                            if (strConsonantes(s))
                            {
                                s = s + temp;
                            }
                            else
                            {
                                s = s + "-" + temp;
                            }
                        }
                    }
                }
                i = i + temp.Length - 1;
                Cadena = RestoSilaba(Cadena);
            }
            return s;
        }




    }
}
