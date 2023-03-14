using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace webString.Models
{
    public class logica
    {
        public string Contar(string data)
        {
            int result;
            string save_result;
            result = data.Count();
            save_result = $"{data} tiene {result} elementos";
            return save_result;
        }

        public string Mayuscula(string data)
        {
            string convert;
            convert = data.ToUpper();
            return convert;
        }
        public string Minuscula(string data)
        {
            string convert;
            convert = data.ToLower();
            return convert;
        }
        public string Concatenar(string data_1 , string data_2 , string data_3) 
        {
            string result;
            result = $"{data_1} {data_2} {data_3}";
            return result ;
        }

        public bool Validacion(string data_1 , string data_2)
        {
            bool result = false ;
            result = data_1.Contains(data_2) ;
            if(result) 
            {
                return true ;
            }
            else
            {
                return false ;
            }

        }

        public string Data_clear(string data) 
        {
            string result;
            result = data.Replace(",", "").Replace("/", "");
            return result;
        }

        public string Data_coma(string data) 
        {
            string result;
            char[] charTotrim = { ','};
            result = data.TrimEnd(charTotrim);
            return result ;
        }
        public string Espacio(string data)
        {
           
            string result;
            result = data.Trim('*');
            return result;
        }

        public bool Validar_word(string data)
        {
            bool result;
            result = data.StartsWith("Ti");

            return result;
        }

        public string Pad(string data)
        {
            string result;

            result = data.PadLeft(5, '0');

            return result; 
        }

        public string Data_mayus(string data) 
        {
            string result = "";
            string[] opera;
            opera = data.Split(' ');
            if (opera.Length > 0)
            {
                for (int i = 0; i < (opera.Length); i++)
                {
                    if (opera[i].Length > 0)
                    {
                        result += opera[i].Substring(0, 1).ToUpper() + opera[i].Substring(1).ToLower() + " ";
                    }
                    }
                result = result.Trim();
            }
            return result;
        }

        public string Data_alreves(string data)
        {
            string resul = "";
            for( int i = (data.Length - 1); i >= 0; i--) 
            {
                resul += data[i];
            }
            return resul;
        }

        public int Data_vocales(string data)
        {
            string result = data.ToLower();
            char[] vocal = { 'a' , 'e' , 'i' ,'o' , 'u'};
           
            int cuenta = 0;
            for (int i = 0; i <= (result.Length - 1); i++)
            {
                if (vocal.Contains(result[i]))
                {
                    cuenta++;
                }

            }
            return cuenta;
        }
    }
}